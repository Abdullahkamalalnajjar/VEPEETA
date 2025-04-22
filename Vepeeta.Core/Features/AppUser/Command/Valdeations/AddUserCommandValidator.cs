using FluentValidation;
using Microsoft.Extensions.Localization;
using Vepeeta.Core.Features.AppUser.Command.Models;
using Vepeeta.Core.Resources;

namespace Vepeeta.Core.Features.AppUser.Command.Valdeations
{
    public class AddUserCommandValidator : AbstractValidator<CreateUserCommand>
    {
        private readonly IStringLocalizer<SharedResources> _localizer;

        public AddUserCommandValidator(IStringLocalizer<SharedResources> localizer)
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