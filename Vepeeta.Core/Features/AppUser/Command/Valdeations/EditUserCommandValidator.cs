using FluentValidation;
using Microsoft.Extensions.Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vepeeta.Core.Features.AppUser.Command.Models;
using Vepeeta.Core.Resources;
using Vepeeta.Service.Abstract;

namespace Vepeeta.Core.Features.AppUser.Command.Valdeations
{
    public class EditUserCommandValidator : AbstractValidator<EditUserCommand>
    {
        private readonly IAppUserService _appUserService;
        private readonly IStringLocalizer<SharedResources> _localizer;

        public EditUserCommandValidator(IAppUserService appUserService, IStringLocalizer<SharedResources> localizer)
        {
            _appUserService = appUserService;
            _localizer = localizer;
        }

        public void EditUserValidator()
        {
            RuleFor(e => e.Email).MustAsync(async (model, Key, CancellationToken) =>
                !await _appUserService.IsEmailExistExcludeSelf(model.Id, model.Email)).WithMessage(_localizer[SharedResourcesKeys.IsExist]);
        }
    }
}
