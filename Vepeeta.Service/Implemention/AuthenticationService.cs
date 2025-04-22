using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using Vepeeta.Data.Entity.Identity;
using Vepeeta.Data.Helpers;
using Vepeeta.Service.Abstract;
namespace Vepeeta.Service.Implementation;
public class AuthenticationService : IAuthenticationService
{
    private readonly UserManager<User> _userManager;
    private readonly RoleManager<IdentityRole> _roleManager;
    private readonly JwtSettings _jwtSettings;

    public AuthenticationService(UserManager<User> userManager, RoleManager<IdentityRole> roleManager, JwtSettings jwtSettings)
    {
        _userManager = userManager;
        _roleManager = roleManager;
        _jwtSettings = jwtSettings;
    }

    public async Task<JwtAuthResult> GenerateTokenAsync(User user)
    {
        var claims = await GetClaims(user);
        var jwtToken = new JwtSecurityToken(
            issuer: _jwtSettings.Issuer,
            audience: _jwtSettings.Audience,
            claims: claims,
            expires: DateTime.Now.AddDays(_jwtSettings.AccessTokenExpireDate),
            signingCredentials: new SigningCredentials(
            new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_jwtSettings.Secret)), SecurityAlgorithms.HmacSha256)
        );
        var accessToken = new JwtSecurityTokenHandler().WriteToken(jwtToken);
        var refreshToken = GetRefreshToken(user.UserName);
        var response = new JwtAuthResult
        {
            AccessToken = accessToken,
            refreshToken = refreshToken,
        };
        return response;
    }
    private JwtAuthResult.RefreshToken GetRefreshToken(string username)
    {
        var refreshToken = new JwtAuthResult.RefreshToken
        {
            ExpireAt = DateTime.Now.AddDays(_jwtSettings.RefreshTokenExpireDate),
            UserName = username,
            TokenString = GenerateRefreshToken()
        };
        return refreshToken;
    }

    private string GenerateRefreshToken()
    {
        var randomNumber = new byte[32];
        var randomNumberGenerate = RandomNumberGenerator.Create();
        randomNumberGenerate.GetBytes(randomNumber);
        return Convert.ToBase64String(randomNumber);
    }

    private async Task<List<Claim>> GetClaims(User user)
    {
        var roles = await _userManager.GetRolesAsync(user);
        var userClaims = await _userManager.GetClaimsAsync(user);
        var claims = new List<Claim>()
        {
            new Claim(ClaimTypes.Name, user.UserName),
            new Claim(ClaimTypes.Email, user.Email),
            new Claim(nameof(UserClaimModel.PhoneNumber), user.PhoneNumber?? ""),
            new Claim(nameof(UserClaimModel.Id), user.Id)
        };
        foreach (var role in roles)
        {
            claims.Add(new Claim(ClaimTypes.Role, role));
        }

        foreach (var claim in userClaims)
        {
            claims.AddRange(userClaims);
        }

        return claims;
    }

    public async Task<string> ConfirmEmail(string? userId, string? code)
    {
        if (userId == null || code == null)
            return "ErrorWhenConfirmEmail";
        var user = await _userManager.FindByIdAsync(userId);
        var confirmEmail = await _userManager.ConfirmEmailAsync(user, code);
        if (!confirmEmail.Succeeded)
            return "ErrorWhenConfirmEmail";
        return "Success";
    }
}