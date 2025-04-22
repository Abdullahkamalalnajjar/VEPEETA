using Vepeeta.Core.Features.Doctors.Commands.Models;
using Vepeeta.Data.Entity.Identity.Doctor;
using Vepeeta.Data.Helpers;

namespace Vepeeta.Core.Mapping.Doctors
{
    public partial class DoctorProfile
    {
        public void Mapping_EditDoctorCommandMapping()
        {
            /*  CreateMap<EditDoctorCommand, Doctor>()
                  .ForMember(dest => dest.ProfilePicture, opt => opt.MapFrom(src => FileHelper.SaveFile(src.ProfilePicture, "ProfileImageOFDoctor")))
                  .ForMember(dest => dest.PhotosOfMedicalLicense, opt => opt.MapFrom(src => FileHelper.SaveFile(src.PhotosOfMedicalLicense, "PhotosOfMedicalLicenses")));
              CreateMap<EditDoctorCommand, DoctorCertificate>();
              CreateMap<EditDoctorCertificateDto, DoctorCertificate>()
                  .ForMember(dest => dest.Id, opt => opt.Ignore());
              CreateMap<EditWorkingHoursDto, WorkingHours>()
                  .ForMember(dest => dest.Id, opt => opt.Ignore());
              CreateMap<EditDoctorServiceDto, DoctorService>()
                  .ForMember(dest => dest.Id, opt => opt.Ignore());
            */
            CreateMap<EditDoctorCommand, Doctor>()
                 .ForMember(dest => dest.ProfilePicture, opt => opt.MapFrom(src =>
                     src.ProfilePicture != null ? FileHelper.SaveFile(src.ProfilePicture, "ProfileImageOFDoctor") : null))
                 .ForMember(dest => dest.PhotosOfMedicalLicense, opt => opt.MapFrom(src =>
                     src.PhotosOfMedicalLicense != null ? FileHelper.SaveFile(src.PhotosOfMedicalLicense, "PhotosOfMedicalLicenses") : null));

            CreateMap<EditDoctorCommand, DoctorCertificate>();

            CreateMap<EditDoctorCertificateDto, DoctorCertificate>()
                .ForMember(dest => dest.Id, opt => opt.Ignore());

            CreateMap<EditWorkingHoursDto, WorkingHours>()
                .ForMember(dest => dest.Id, opt => opt.Ignore());

            CreateMap<EditDoctorServiceDto, DoctorService>()
                .ForMember(dest => dest.Id, opt => opt.Ignore());

        }
    }

}
