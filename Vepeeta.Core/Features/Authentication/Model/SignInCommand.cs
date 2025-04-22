using MediatR;
using Vepeeta.Core.Bases;
using Vepeeta.Core.Features.Authentication.Results;

namespace Vepeeta.Core.Features.Authentication.Model;

public class SignInCommand : IRequest<Response<SignInResponse>>
{
    public string Email { get; set; }
    public string Password { get; set; }
}