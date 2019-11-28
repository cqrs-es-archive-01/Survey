using AutoMapper;
using CSharpFunctionalExtensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Survey.Common.Messages;
using Survey.Transverse.Contract;
using Survey.Transverse.Contract.Users.Requests;
using Survey.Transverse.Contract.Users.Responses;
using Survey.Transverse.Domain.Users.Commands;
using Survey.Transverse.Domain.Users.Queries;
using System;
using System.Collections.Generic;

namespace Survey.Transverse.API.Controllers
{
    [ApiController]
    //[Authorize]
    [EnableCors("AllowOrigin")]
    public class UsersController : BaseController
    {
        private readonly IMapper _mapper;
        private readonly Dispatcher _dispatcher;

        public UsersController(Dispatcher dispatcher,
                               IMapper mapper)
        {
            _mapper = mapper;
            _dispatcher = dispatcher;
        }


        [HttpPost(ApiRoutes.Users.Register)]
        public IActionResult Register(UserRegistrationRequest registerRequest)
        {
            var registerCommand = _mapper.Map<RegisterUserCommand>(registerRequest);
            Result result = _dispatcher.Dispatch(registerCommand);
            return FromResult(result);
        }


        [HttpGet(ApiRoutes.Users.QueryAll)]
        public IActionResult GetList()
        {
            List<UserListResponse> list = _dispatcher.Dispatch(new GetListUsersQuery());
            return Ok(list);
        }


        [HttpGet(ApiRoutes.Users.QueryById)]
        public IActionResult GetById(Guid id)
        {
            var user = _dispatcher.Dispatch(new GetUserByIdQuery(id));
            if (user == null)
                return NotFound("user not found");
            var userModel = _mapper.Map<UserResponse>(user);
            return Ok(userModel);
        }


        [HttpPost(ApiRoutes.Users.Unregister)]
        public IActionResult Unregister(Guid id, UnregisterRequest unregisterRequest)
        {
            var result = _dispatcher.Dispatch(new UnregisterUserCommand(id, unregisterRequest.By, unregisterRequest.Reason));

            return FromResult(result);
        }

        [HttpPost(ApiRoutes.Users.EditeInfo)]
        public IActionResult EditInfo(Guid id, EditUserRequest request)
        {
            var command = new EditUserCommand(id, request.FirstName, request.LastName,request.Email, request.Permissions,
                                              request.DeleteExistingPermissions);

            var result = _dispatcher.Dispatch(command);

            return FromResult(result);
        }

    }

}
