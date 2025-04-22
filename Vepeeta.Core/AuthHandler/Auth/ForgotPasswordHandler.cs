using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Caching.Memory;
using Vepeeta.Core.Bases;
using Vepeeta.Core.Dtos.Auth;
using Vepeeta.Data.Entity.Identity;
using Vepeeta.Service.Abstract;

namespace Vepeeta.Service.Handler.Auth
{
    /*/ public class ForgotPasswordHandler
     {
         private readonly UserManager<User> _userManager;
         private readonly IEmailService _emailService;
         private readonly ResponseHandler _responseHandler; 

         public ForgotPasswordHandler(UserManager<User> userManager, IEmailService emailService, ResponseHandler responseHandler)
         {
             _userManager = userManager;
             _emailService = emailService;
             _responseHandler = responseHandler; 
         }

         public async Task<Response<string>> Handle(ForgotPasswordRequest request)
         {
             var user = await _userManager.FindByEmailAsync(request.Email);
             if (user == null)
                 return _responseHandler.Fail<string>("Email not found");

             var resetToken = await _userManager.GeneratePasswordResetTokenAsync(user);
             await _emailService.SendEmailAsync(user.Email, "Reset Password", $"Your reset token: {resetToken}");

             return _responseHandler.Success("Reset token sent successfully."); 
         }
     }
 */

    public class ForgotPasswordHandler
    {
        private readonly UserManager<User> _userManager;
        private readonly IEmailService _emailService;
        private readonly IOTPService _otpService;
        private readonly ResponseHandler _responseHandler;

        public ForgotPasswordHandler(UserManager<User> userManager, IEmailService emailService, IOTPService otpService, ResponseHandler responseHandler)
        {
            _userManager = userManager;
            _emailService = emailService;
            _otpService = otpService;
            _responseHandler = responseHandler;
        }

        public async Task<Response<string>> Handle(ForgotPasswordRequest request)
        {
            var user = await _userManager.FindByEmailAsync(request.Email);
            if (user == null)
                return _responseHandler.Fail<string>("البريد الإلكتروني غير موجود");

            // 1️⃣ توليد كود OTP عشوائي من 6 أرقام
            string otp = _otpService.GenerateOTP(6);

            // 2️⃣ حفظ الـ OTP في قاعدة البيانات مع تاريخ انتهاء الصلاحية
            await _userManager.UpdateAsync(user);
    

            // 3️⃣ إرسال OTP إلى البريد الإلكتروني
            await _emailService.SendEmailAsync(user.Email, "رمز التحقق (OTP)", $"رمز التحقق الخاص بك: {otp}");

            return _responseHandler.Success("تم إرسال رمز OTP إلى بريدك الإلكتروني");
        }
    }

}
