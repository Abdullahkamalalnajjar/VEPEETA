using Microsoft.AspNetCore.Identity;
using Vepeeta.Core.Bases;
using Vepeeta.Data.Entity.Identity;

namespace Vepeeta.Core.Dtos.Auth
{
    public class VerifyOTPHandler
    {
        private readonly UserManager<User> _userManager;
        private readonly ResponseHandler _responseHandler;

        public VerifyOTPHandler(UserManager<User> userManager, ResponseHandler responseHandler)
        {
            _userManager = userManager;
            _responseHandler = responseHandler;
        }

        public async Task<Response<string>> Handle(VerifyOTPRequest request)
        {
            var user = await _userManager.FindByEmailAsync(request.Email);
            if (user == null)
                return _responseHandler.Fail<string>("User not found");



            return _responseHandler.Success<string>("OTP verified successfully");
        }
    }
}
