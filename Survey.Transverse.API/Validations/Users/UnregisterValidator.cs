using FluentValidation;
using Survey.Transverse.Contract.Users.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Survey.Transverse.API.Validations.Users
{
    public class UnregisterValidator : AbstractValidator<UnregisterRequest>
    {
        public UnregisterValidator()
        {
            RuleFor(x => x.Reason)
         .NotEmpty()
         .WithMessage("Delete reason is mandatory.");
        }
    }
}
