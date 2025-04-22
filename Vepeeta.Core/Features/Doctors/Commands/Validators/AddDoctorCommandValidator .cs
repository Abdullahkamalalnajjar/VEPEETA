using FluentValidation;
using Microsoft.Extensions.Localization;
using Vepeeta.Core.Features.Doctors.Commands.Models;
using Vepeeta.Core.Resources;

namespace Vepeeta.Core.Features.Doctors.Commands.Validators
{
    public class AddDoctorCommandValidator : AbstractValidator<CreateDoctorCommand>
    {
        private readonly IStringLocalizer<SharedResources> _localizer;

        public AddDoctorCommandValidator(IStringLocalizer<SharedResources> localizer)
        {
            _localizer = localizer;
            ApplyAddUserValidator();
        }

        private void ApplyAddUserValidator()
        {
            RuleFor(e => e.Email)
                .NotEmpty().WithMessage(_localizer[SharedResourcesKeys.NotEmpty]);
            RuleFor(p => p.Password)
                .NotEmpty().WithMessage(_localizer[SharedResourcesKeys.NotEmpty]);
            RuleFor(p => p.ConfirmPassword)
                .NotEmpty().WithMessage(_localizer[SharedResourcesKeys.NotEmpty]);
            RuleFor(p => p.ConfirmPassword)
                .Equal(x => x.Password).WithMessage(_localizer[SharedResourcesKeys.ConfirmPasswordNotMatch]);
        }

    }
}