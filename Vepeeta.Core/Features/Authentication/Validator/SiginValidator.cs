using FluentValidation;
using Vepeeta.Core.Features.Authentication.Model;

namespace Vepeeta.Core.Features.Authentication.Validator;

public class SiginValidator : AbstractValidator<SignInCommand>
{

    public SiginValidator()
    {
        AddSigninValidator();
    }

    public void AddSigninValidator()
    {
        RuleFor(x => x.Email)
            .NotEmpty().WithMessage("NotEmpty")
            .NotNull().WithMessage("NotNull");
        RuleFor(x => x.Password)
               .NotEmpty().WithMessage("NotEmpty")
            .NotNull().WithMessage("NotNull");
    }
}