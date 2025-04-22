using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Vepeeta.Api.Base;
using Vepeeta.Api.Helpers;
using Vepeeta.Core.Dtos.Auth;
using Vepeeta.Core.Features.Authentication.Model;
using Vepeeta.Data.AppMetaData;
using Vepeeta.Data.Entity.Identity;
using Vepeeta.Service.Handler.Auth;

namespace Vepeeta.Api.Controllers;

public class AuthenticationController : AppBaseController
{
    private readonly ForgotPasswordHandler _forgotPasswordHandler;
    private readonly ResetPasswordHandler _resetPasswordHandler;
    private readonly VerifyOTPHandler _verifyOTPHandler;
    private readonly UserManager<User> _userManager;
    private readonly IMemoryCache _memoryCache;
    private readonly EmailHelper _emailHelper;

    public AuthenticationController(ForgotPasswordHandler forgotPasswordHandler,
                                    ResetPasswordHandler resetPasswordHandler,
                                    VerifyOTPHandler verifyOTPHandler, UserManager<User> userManager, IMemoryCache memoryCache, EmailHelper emailHelper)
    {
        _forgotPasswordHandler = forgotPasswordHandler;
        _resetPasswordHandler = resetPasswordHandler;
        _verifyOTPHandler = verifyOTPHandler;
        _userManager = userManager;
        _memoryCache = memoryCache;
        _emailHelper = emailHelper;
    }

    [HttpPost("forgot-password")]
    public async Task<IActionResult> ForgotPassword([FromBody] ForgotPasswordRequest model)
    {
        var response = await _forgotPasswordHandler.Handle(model);
        return response.Succeeded ? Ok(response) : BadRequest(response);
    }

    // إرسال OTP
    [HttpPost("send-otp")]
    public async Task<ActionResult> SendOtp([FromQuery] string email)
    {
        var user = await _userManager.FindByEmailAsync(email);
        if (user == null)
        {
            return BadRequest("Invalid email address.");
        }

        var otp = new Random().Next(100000, 999999).ToString();
        _memoryCache.Set(email, otp, TimeSpan.FromMinutes(10)); // Cache the OTP for 10 minutes

        var subject = "Your OTP Code";
        var body = $"<p>Your OTP code is: <strong>{otp}</strong> to reset your password</p>";

        try
        {
            await _emailHelper.SendEmailAsync(email, subject, body);
            var response = "OTP has been sent to your email.";
            return Ok(response);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Error sending OTP: {ex.Message}");
        }
    }
    // التحقق من OTP
    [HttpPost("verify-otp")]
    public ActionResult VerifyOtp([FromQuery] string email, [FromQuery] string otp)
    {
        if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(otp))
        {
            return BadRequest("Email and OTP are required.");
        }

        // استرجاع الـ OTP المخزن في الكاش
        if (_memoryCache.TryGetValue(email, out string cachedOtp))
        {
            if (cachedOtp == otp)
            {
                // حذف OTP بعد التحقق الناجح لمنع إعادة استخدامه
                _memoryCache.Remove(email);
                var response = new { StatusCode = 200, Message = "OTP is valid." };
                return Ok(response);
            }
            else
            {
                var response = new { StatusCode = 400, Message = "Invalid OTP." };
                return BadRequest(response);
            }
        }
        var faild = new { StatusCode = 400, Message = "OTP has expired or is invalid." };
        return BadRequest(faild);
    }

    // إعادة تعيين كلمة المرور
    [HttpPost("reset-password")]
    public async Task<ActionResult> ResetPassword([FromBody] ResetPasswordDto resetPasswordDto)
    {
        var user = await _userManager.FindByEmailAsync(resetPasswordDto.Email);
        if (user == null)
        {
            return BadRequest("Invalid email address.");
        }

        if (!_memoryCache.TryGetValue(resetPasswordDto.Email, out string cachedOtp) || cachedOtp != resetPasswordDto.Otp)
        {
            return BadRequest("Invalid or expired OTP.");
        }

        var token = await _userManager.GeneratePasswordResetTokenAsync(user);
        var resetResult = await _userManager.ResetPasswordAsync(user, token, resetPasswordDto.NewPassword);
        if (!resetResult.Succeeded)
        {
            return BadRequest(resetResult.Errors.FirstOrDefault()?.Description ?? "Failed to reset password.");
        }

        _memoryCache.Remove(resetPasswordDto.Email);
        var response = (200, "Password has been reset successfully.", user);
        return Ok(response);
    }

    [HttpPost(Router.AuthenticationRouting.SginIn)]
    public async Task<IActionResult> SignIn([FromBody] SignInCommand command)
    {
        var response = await Mediator.Send(command);
        return Ok(response);
    }
    // فئة لإعادة تعيين كلمة المرور
    public class ResetPasswordDto
    {
        public string Email { get; set; }
        public string Otp { get; set; }
        public string NewPassword { get; set; }
    }

}