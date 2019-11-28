using FluentValidation;
using Survey.Transverse.Contract.Users.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Survey.Transverse.API.Validations.Users
{
    public class EditUserValidator : AbstractValidator<EditUserRequest>
    {
        public EditUserValidator()
        {
            RuleFor(x => x.FirstName)
           .NotEmpty()
           .WithMessage("FirstName is mandatory.");

            RuleFor(x => x.LastName)
            .NotEmpty()
            .WithMessage("LastName is mandatory.");

            RuleFor(x => x.Email)
            .NotEmpty()
            .WithMessage("Email is mandatory.");
        }
    }
}
