using FluentValidation;
using Survey.Transverse.Contract.Features.Requests;

namespace Survey.Transverse.API.Validations.Features
{
    public class EditFeatureValidator : AbstractValidator<EditFeatureRequest>
    {
        public EditFeatureValidator()
        {
            RuleFor(x => x.Action)
             .NotEmpty()
             .WithMessage("Action is mandatory.");

            RuleFor(x => x.Label)
             .NotEmpty()
             .WithMessage("Action is mandatory.");

        }
    }
}
