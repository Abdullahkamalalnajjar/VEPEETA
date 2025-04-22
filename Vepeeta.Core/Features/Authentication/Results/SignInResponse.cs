using Vepeeta.Data.Helpers;

namespace Vepeeta.Core.Features.Authentication.Results
{
    public class SignInResponse
    {
        public string UserId { get; set; }
        public string UserName { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public List<UserRole> Roles { get; set; }
        public JwtAuthResult JwtAuthResult { get; set; }
    }
    public class UserRole
    {
        public string RoleName { get; set; }
    }
}
