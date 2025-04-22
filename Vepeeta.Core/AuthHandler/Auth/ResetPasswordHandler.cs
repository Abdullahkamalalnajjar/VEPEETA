using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vepeeta.Core.Bases;
using Vepeeta.Core.Dtos.Auth;
using Vepeeta.Data.Entity.Identity;

namespace Vepeeta.Service.Handler.Auth
{
    public class ResetPasswordHandler
    {
        private readonly UserManager<User> _userManager;
        private readonly ResponseHandler _responseHandler; // ✅ أضف هذا المتغير

        public ResetPasswordHandler(UserManager<User> userManager, ResponseHandler responseHandler)
        {
            _userManager = userManager;
            _responseHandler = responseHandler; // ✅ استقبل ResponseHandler عبر الـ Constructor
        }

        public async Task<Response<string>> Handle(ResetPasswordRequest request)
        {
            var user = await _userManager.FindByEmailAsync(request.Email);
            if (user == null)
                return _responseHandler.Fail<string>("Invalid request"); // ✅ الحل الصحيح

            var result = await _userManager.ResetPasswordAsync(user, request.Token, request.NewPassword);
            if (!result.Succeeded)
                return _responseHandler.Fail<string>(result.Errors.FirstOrDefault()?.Description);

            return _responseHandler.Success("Password has been reset successfully.");
        }
    }

}
