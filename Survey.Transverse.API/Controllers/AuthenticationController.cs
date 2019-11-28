using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Survey.Common.Messages;
using Survey.Transverse.Contract;
using Survey.Transverse.Contract.Identity.Requests;
using Survey.Transverse.Domain.Users.Authentication.Commands;
using CSharpFunctionalExtensions;
using System;
using Survey.Transverse.Contract.Authentication.Requests;

namespace Survey.Transverse.API.Controllers
{
    [ApiController]
    [EnableCors("AllowOrigin")]
    public class AuthenticationController : BaseController
    {

        private readonly IMapper _mapper;
        private readonly Dispatcher _dispatcher;

        public AuthenticationController(IMapper mapper,
                                  Dispatcher dispatcher)
        {
            _mapper = mapper;
            _dispatcher = dispatcher;
        }
        [AllowAnonymous]
        [HttpPost(ApiRoutes.Identity.SignIn)]
        public IActionResult SignIn(SignInRequest loginRequest)
        {
            Result result = _dispatcher.Dispatch(new SignInCommand(loginRequest.Email,loginRequest.Password));
            return FromResult(result);

            /*
              var userModel = _identityService.SignIn(userLoginRequest);

            if (userModel == null)
            {
                return BadRequest(new AuthFailedResponse { Errors = new[] { "Email Et/Ou password incorrect" } });
            }

            var userFeatures = _featureService.GetByUser(userModel.Id);

            var authResult = GenerateAuthenticationResultForUser(userModel);

            return Ok(new UserFeatureResponse
            {
                Token = authResult.Token,
                RefreshToken = authResult.RefreshToken,
                Email = userModel.Email,
                FirstName = userModel.FirstName,
                LastName = userModel.LastName,
                UserFeatures = userFeatures
            });*/
        }
        [AllowAnonymous]
        [HttpPost(ApiRoutes.Identity.SignOut)]
        public IActionResult SignOut(Guid id)
        {
            Result result = _dispatcher.Dispatch(new SignOutCommand(id));
            return FromResult(result);
        }


        [HttpPost(ApiRoutes.Identity.ChangePassword)]
        public IActionResult ChangePassword(Guid id, ChangePasswordRequest request)
        {
            var command = new ChangePasswordCommand(id, request.OldPassword, request.NewPassword);
            Result result = _dispatcher.Dispatch(command);
            return FromResult(result);
        }




    }
}
