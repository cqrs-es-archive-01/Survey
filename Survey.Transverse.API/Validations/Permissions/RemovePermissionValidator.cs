using FluentValidation;
using Survey.Transverse.Contract.Features.Requests;
using Survey.Transverse.Contract.Permissions.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Survey.Transverse.API.Validations.Features
{
    public class RemovePermissionValidator : AbstractValidator<RemovePermissionRequest>
    {
        public RemovePermissionValidator()
        {
            RuleFor(x => x.Reason)
           .NotEmpty()
           .WithMessage("Reason is mandatory.");

        }
    }
}
