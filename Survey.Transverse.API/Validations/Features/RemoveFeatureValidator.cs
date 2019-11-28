using FluentValidation;
using Survey.Transverse.Contract.Features.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Survey.Transverse.API.Validations.Features
{
    public class RemoveFeatureValidator : AbstractValidator<RemoveFeatureRequest>
    {
        public RemoveFeatureValidator()
        {
            RuleFor(x => x.Reason)
           .NotEmpty()
           .WithMessage("Reason is mandatory.");

        }
    }
}
