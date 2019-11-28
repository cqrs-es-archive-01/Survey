using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CSharpFunctionalExtensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Survey.Common.Messages;
using Survey.Transverse.Contract;
using Survey.Transverse.Contract.Features.Requests;
using Survey.Transverse.Contract.Features.Responses;
using Survey.Transverse.Domain.Features.Commands;
using Survey.Transverse.Domain.Features.Queries;


namespace Survey.Transverse.API.Controllers
{
    [ApiController]
    //[Authorize]

    public class FeaturesController : BaseController
    {
        private readonly IMapper _mapper;
        private readonly Dispatcher _dispatcher;

        public FeaturesController(IMapper mapper,
                                  Dispatcher dispatcher)
        {
            _mapper = mapper;
            _dispatcher = dispatcher;
        }


        [HttpGet(ApiRoutes.Features.QueryAll)]
        [Produces("application/json")]
        public IActionResult Get()
        {
            List<FeatureListResponse> list = _dispatcher.Dispatch(new GetListFeaturesQuery());
            return Ok(list);
        }


        [HttpPost(ApiRoutes.Features.Create)]
        [Produces("application/json")]
        public IActionResult Post(CreateFeatureRequest request)
        {
            var command = new CreateFeatureCommand(request.Label, request.Description, request.Action, request.Controller,
                                                request.ControllerActionName, request.CreatedBy);
            Result result = _dispatcher.Dispatch(command);
            return FromResult(result);
        }


        [HttpPost(ApiRoutes.Features.Deactivate)]
        [Produces("application/json")]
        public IActionResult Post(Guid id,DeactivateFeatureRequest request)
        {
            var command = new DeactivateFeatureCommand(id, request.DeletedBy);
            Result result = _dispatcher.Dispatch(command);
            return FromResult(result);
        }

        [HttpPost(ApiRoutes.Features.Remove)]
        [Produces("application/json")]
        public IActionResult Remove(Guid id, RemoveFeatureRequest request)
        {
            var command = new RemoveFeatureCommand(id, request.DeletedBy,request.Reason);
            Result result = _dispatcher.Dispatch(command);
            return FromResult(result);
        }

        [HttpPost(ApiRoutes.Features.EditInfo)]
        public IActionResult EditInfo(Guid id, EditFeatureRequest request)
        {
            request.Id = id;
            var command = _mapper.Map<EditFeatureCommand>(request);

            var result = _dispatcher.Dispatch(command);

            return FromResult(result);
        }

    }
}
