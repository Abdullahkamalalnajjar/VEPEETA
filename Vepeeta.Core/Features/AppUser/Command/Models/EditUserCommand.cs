using MediatR;
using Microsoft.AspNetCore.Http;
using Vepeeta.Core.Bases;

namespace Vepeeta.Core.Features.AppUser.Command.Models
{
    public class EditUserCommand : IRequest<Response<string>>
    {
        public string Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Animalname { get; set; }
        public IFormFile Image { get; set; }
        public int Age { get; set; }
        public decimal Weight { get; set; }

    }
}
