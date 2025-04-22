using AutoMapper;
using Vepeeta.Core.Features.AppUser.Command.Models;
using Vepeeta.Data.Entity.Identity;

namespace Vepeeta.Core.Mapping.Users.Command
{


    public class AgeToBirthDateResolver : IValueResolver<EditUserCommand, PetOwner, DateTime>
    {
        public DateTime Resolve(EditUserCommand source, PetOwner destination, DateTime destMember, ResolutionContext context)
        {
            return DateTime.UtcNow.AddYears(-source.Age); // حساب تاريخ الميلاد بناءً على العمر
        }
    }
}
