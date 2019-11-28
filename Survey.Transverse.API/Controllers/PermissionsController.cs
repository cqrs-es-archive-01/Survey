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
using Survey.Transverse.Contract.Permissions.Requests;
using Survey.Transverse.Contract.Permissions.Responses;
using Survey.Transverse.Domain.Features.Commands;
using Survey.Transverse.Domain.Features.Queries;
using Survey.Transverse.Domain.Permissions.Commands;

namespace Survey.Transverse.API.Controllers
{
    [ApiController]
    //[Authorize]

    public class PermissionsController : BaseController
    {
        private readonly IMapper _mapper;
        private readonly Dispatcher _dispatcher;

        public PermissionsController(IMapper mapper,
                                  Dispatcher dispatcher)
        {
            _mapper = mapper;
            _dispatcher = dispatcher;
        }
        [HttpGet(ApiRoutes.Permissions.QueryAll)]
        [Produces("application/json")]
        public IActionResult Get()
        {
            List<PermissionListResponse> list = _dispatcher.Dispatch(new GetListPermissionQuery());
            return Ok(list);
        }


        [HttpPost(ApiRoutes.Permissions.Create)]
        [Produces("application/json")]
        public IActionResult Post(CreatePermissionRequest request)
        {
            var command = new CreatePermissionCommand(request.Label, request.Description, request.CreatedBy,request.Features);
            Result result = _dispatcher.Dispatch(command);
            return FromResult(result);
        }


        [HttpPost(ApiRoutes.Permissions.Deactivate)]
        [Produces("application/json")]
        public IActionResult Post(Guid id, DeactivatePermissionRequest request)
        {
            var command = new DeactivatePermissionCommand(id, request.DeletedBy);
            Result result = _dispatcher.Dispatch(command);
            return FromResult(result);
        }

        [HttpPost(ApiRoutes.Permissions.Remove)]
        [Produces("application/json")]
        public IActionResult Remove(Guid id, RemovePermissionRequest request)
        {
            var command = new RemovePermissionCommand(id, request.DeletedBy, request.Reason);
            Result result = _dispatcher.Dispatch(command);
            return FromResult(result);
        }

        [HttpPost(ApiRoutes.Permissions.Edit)]
        public IActionResult EditInfo(Guid id, EditPermissionRequest request)
        {
            var command = new EditPermissionCommand(id, request.Label, request.Description, 
                                                    request.Features, request.DeleteExistingFeatures);
            //_mapper.Map<EditPermissionCommand>(request);

            var result = _dispatcher.Dispatch(command);

            return FromResult(result);
        }

    }
}
