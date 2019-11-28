using FluentValidation;
using Survey.Transverse.Contract.Features.Requests;
using Survey.Transverse.Contract.Permissions.Requests;

namespace Survey.Transverse.API.Validations.Features
{
    public class CreatePermissionValidator : AbstractValidator<CreatePermissionRequest>
    {
        public CreatePermissionValidator()
        {
            RuleFor(x => x.Label)
             .NotEmpty()
             .WithMessage("Label is mandatory.");

        }
    }
}
