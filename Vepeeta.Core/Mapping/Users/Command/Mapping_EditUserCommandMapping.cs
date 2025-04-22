using Vepeeta.Core.Features.AppUser.Command.Models;
using Vepeeta.Core.Mapping.Users.Command;
using Vepeeta.Data.Entity.Identity;
using Vepeeta.Data.Helpers;

namespace Vepeeta.Core.Mapping.Users
{
    public partial class UserProfile
    {


        public void Mapping_EditUserCommandMapping()
        {
            CreateMap<EditUserCommand, PetOwner>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
               .ForMember(dest => dest.Image, opt => opt.MapFrom(src => FileHelper.SaveFile(src.Image, "ProfileImageOFUser")))
                .ForMember(dest => dest.AnimalBornDate, opt => opt.MapFrom(src => DateTime.UtcNow.AddYears(-src.Age))) // حساب تاريخ الميلاد
                .ForMember(dest => dest.Weight, opt => opt.MapFrom(src => src.Weight))
                .ForMember(dest => dest.Animalname, opt => opt.MapFrom(src => src.Animalname))
                .ForMember(dest => dest.PhoneNumber, opt => opt.MapFrom(src => src.PhoneNumber))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.Email)) // اجعل اسم المستخدم هو البريد الإلكتروني
                .ForMember(dest => dest.FristName, opt => opt.MapFrom<FirstNameResolver>()) // استخدام الـ Resolver للاسم الأول
                .ForMember(dest => dest.LastName, opt => opt.MapFrom<LastNameResolver>()); // استخدام الـ Resolver للاسم الأخير
            CreateMap<EditUserCommand, User>().ForMember(dest => dest.PhoneNumber, opt => opt.MapFrom(src => src.PhoneNumber));
        }

    }


}

