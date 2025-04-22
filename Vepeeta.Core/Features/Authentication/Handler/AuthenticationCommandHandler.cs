using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Localization;
using Vepeeta.Core.Bases;
using Vepeeta.Core.Features.Authentication.Model;
using Vepeeta.Core.Features.Authentication.Results;
using Vepeeta.Core.Resources;
using Vepeeta.Data.Entity.Identity;
using Vepeeta.Data.Entity.Identity.Doctor;
using Vepeeta.Service.Abstract;

namespace Vepeeta.Core.Features.Authentication.Handler;

public class AuthenticationCommandHandler : ResponseHandler,
    IRequestHandler<SignInCommand, Response<SignInResponse>>
{
    private readonly IAuthenticationService _authenticationService;
    private readonly SignInManager<User> _signInManager;
    private readonly UserManager<User> _userManager;
    private readonly IStringLocalizer<SharedResources> _stringLocalizer;

    public AuthenticationCommandHandler(
        IAuthenticationService authenticationService,
        SignInManager<User> signInManager,
        UserManager<User> userManager,
        IStringLocalizer<SharedResources> stringLocalizer) : base(stringLocalizer)
    {
        _authenticationService = authenticationService;
        _signInManager = signInManager;
        _userManager = userManager;
        _stringLocalizer = stringLocalizer;
    }

    public async Task<Response<SignInResponse>> Handle(SignInCommand request, CancellationToken cancellationToken)
    {
        var result = new SignInResponse();

        var user = await _userManager.Users.FirstOrDefaultAsync(u => u.Email == request.Email);

        if (user == null)
            return NotFound<SignInResponse>("Email Not Found");

        // التحقق من كلمة المرور
        var signinResult = await _signInManager.CheckPasswordSignInAsync(user, request.Password, false);
        if (!signinResult.Succeeded)
            return BadRequest<SignInResponse>("Password Incorrect");

        var roles = await _userManager.GetRolesAsync(user);
        var jwtAuthResult = await _authenticationService.GenerateTokenAsync(user);
        if (jwtAuthResult == null)
            return BadRequest<SignInResponse>("Failed to generate token");

        // استخراج FullName بناءً على نوع المستخدم
        string? fullName = user switch
        {
            Doctor doctor => doctor.FullName,
            PetOwner petOwner => petOwner.FullName,
            _ => "Unknown User" // لو حصل أي حاجة غير متوقعة
        };

        // تعيين القيم إلى كائن الاستجابة
        result.JwtAuthResult = jwtAuthResult;
        result.UserName = user.UserName;
        result.UserId = user.Id;
        result.Email = user.Email;
        result.FullName = fullName; // ✅ دلوقتي بيجيب FullName بشكل صحيح
        result.Roles = roles.Select(role => new UserRole { RoleName = role }).ToList();

        return Success(result);
    }
}
