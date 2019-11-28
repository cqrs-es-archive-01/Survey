using FluentValidation;
using Survey.Transverse.Contract.Identity.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Survey.Transverse.API.Validations.Authentication
{
    public class SignInValidator : AbstractValidator<SignInRequest>
    {
        public SignInValidator()
        {
            RuleFor(x => x.Email)
           .NotEmpty()
           .WithMessage("Email is mandatory.");

            RuleFor(x => x.Password)
           .NotEmpty()
           .WithMessage("Password is mandatory.");
        }
    }
}
