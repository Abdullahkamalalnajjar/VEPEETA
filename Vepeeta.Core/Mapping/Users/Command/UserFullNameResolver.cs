using AutoMapper;
using Vepeeta.Core.Features.AppUser.Command.Models;
using Vepeeta.Data.Entity.Identity;


namespace Vepeeta.Core.Mapping.Users.Command
{
    public class FirstNameResolver : IValueResolver<EditUserCommand, PetOwner, string>
    {
        public string Resolve(EditUserCommand source, PetOwner destination, string destMember, ResolutionContext context)
        {
            return source.FullName?.Split(' ', StringSplitOptions.RemoveEmptyEntries).FirstOrDefault() ?? "";
        }
    }

    public class LastNameResolver : IValueResolver<EditUserCommand, PetOwner, string>
    {
        public string Resolve(EditUserCommand source, PetOwner destination, string destMember, ResolutionContext context)
        {
            return source.FullName?.Split(' ', StringSplitOptions.RemoveEmptyEntries).Skip(1).FirstOrDefault() ?? "";
        }
    }
}