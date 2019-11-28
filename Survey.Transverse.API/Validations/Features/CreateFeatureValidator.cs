using FluentValidation;
using Survey.Transverse.Contract.Features.Requests;

namespace Survey.Transverse.API.Validations.Features
{
    public class CreateFeatureValidator : AbstractValidator<CreateFeatureRequest>
    {
        public CreateFeatureValidator()
        {
            RuleFor(x => x.Label)
             .NotEmpty()
             .WithMessage("Label is mandatory.");

            RuleFor(x => x.Action)
             .NotEmpty()
             .WithMessage("Action is mandatory.");

        }
    }
}
