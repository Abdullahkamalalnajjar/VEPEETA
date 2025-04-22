using Vepeeta.Core.Features.Doctors.Commands.Models;
using Vepeeta.Data.Entity.Identity.Doctor;
using Vepeeta.Data.Helpers;

namespace Vepeeta.Core.Mapping.Doctors
{
    public partial class DoctorProfile
    {
        public void CreateDoctorCommand_Mapping()
        {

            CreateMap<CreateDoctorCommand, Doctor>()
             .ForMember(dest => dest.PhotosOfMedicalLicense, opt => opt.Ignore())
             .ForMember(dest => dest.Certificates, opt => opt.Ignore())
             .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.Email))
             .ForMember(dest => dest.Address, opt => opt.MapFrom(src => src.Address))
             .ForMember(dest => dest.Longitude, opt => opt.MapFrom(src => src.Longitude))
             .ForMember(dest => dest.Latitude, opt => opt.MapFrom(src => src.Latitude))
             .ForMember(dest => dest.ProfilePicture, opt => opt.MapFrom(src => FileHelper.SaveFile(src.ProfilePicture, "ProfileImageOFDoctor")))
             .ForMember(dest => dest.PhotosOfMedicalLicense, opt => opt.MapFrom(src => FileHelper.SaveFile(src.PhotosOfMedicalLicense, "PhotosOfMedicalLicenses")))
             .ForMember(dest => dest.WorkHours, opt => opt.MapFrom(src => src.WorkHours))
             .ForMember(dest => dest.DoctorServices, opt => opt.MapFrom(src =>
                 src.Services.Select(serviceId => new DoctorService
                 {
                     MedicalServiceId = serviceId
                 }).ToList()
             ));

            CreateMap<CreateWorkingHoursDto, WorkingHours>();
            // تحويل الـ CreateClinicCommand إلى ClinicServices
            CreateMap<CreateDoctorCommand, DoctorService>()
                .ForMember(dest => dest.MedicalServiceId, opt => opt.MapFrom(src => src.Services))
                .ForMember(dest => dest.DoctorId, opt => opt.Ignore())
                .ForMember(dest => dest.MedicalService, opt => opt.Ignore());

        }
    }
}
