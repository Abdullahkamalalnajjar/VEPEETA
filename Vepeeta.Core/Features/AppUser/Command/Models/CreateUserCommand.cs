using MediatR;
using Microsoft.AspNetCore.Http;
using Vepeeta.Core.Bases;

namespace Vepeeta.Core.Features.AppUser.Command.Models
{
    public class CreateUserCommand : IRequest<Response<string>>
    {

        public string Email { get; set; }
        public string? PhoneNumber { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public string? Address { get; set; }
        public string? FristName { get; set; }
        public string? LastName { get; set; }
        public string? Animalname { get; set; }
        public string? AnimalGender { get; set; }
        public string? AnimalType { get; set; }
        public string? AnimalCategory { get; set; }
        public DateTime? AnimalBornDate { get; set; }
        public decimal? Weight { get; set; }
        public string? ReproductiveStatus { get; set; }
        public string? sensitivity { get; set; }
        public IFormFile? Image { get; set; }
        public string? Description { get; set; }
        public string? Otp { get; set; }
    }
}
