using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

using Survey.Transverse.API.Util;
using CSharpFunctionalExtensions;
using AutoMapper;
using Survey.Common.Messages;

namespace Survey.Transverse.API.Controllers
{
    public class BaseController : Controller
    {

        public BaseController()
        {
        }

        protected new IActionResult Ok()
        {
            return base.Ok(Envelope.Ok());
        }

        protected IActionResult Ok<T>(T result)
        {
            return base.Ok(Envelope.Ok(result));
        }

        protected IActionResult Error(string errorMessage)
        {
            return BadRequest(Envelope.Error(errorMessage));
        }

        protected IActionResult FromResult(Result result)
        {
            return result.IsSuccess ? Ok() : Error(result.Error);
        }
        protected IActionResult NotFound(string errorMessage)
        {
            return NotFound(Envelope.Error(errorMessage));
        }
    }
}
