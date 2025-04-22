using Vepeeta.Data.Entity.Identity;
using Vepeeta.Data.Helpers;

namespace Vepeeta.Service.Abstract;

public interface IAuthenticationService
{
    public Task<JwtAuthResult> GenerateTokenAsync(User user);
    public Task<string> ConfirmEmail(string? userId, string? code);

}