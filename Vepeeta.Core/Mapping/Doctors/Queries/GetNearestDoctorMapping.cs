using Vepeeta.Core.Features.Doctors.Queries.Results;
using Vepeeta.Data.Entity.Identity.Doctor;

namespace Vepeeta.Core.Mapping.Doctors
{
    public partial class DoctorProfile
    {
        public void GetNearestDoctorMapping()
        {
            CreateMap<Doctor, GetDoctorByIdResponse>()
    .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
    .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
    .ForMember(dest => dest.PhoneNumber, opt => opt.MapFrom(src => src.PhoneNumber))
    .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => src.FullName))
    .ForMember(dest => dest.Specialization, opt => opt.MapFrom(src => src.Specialization))
    .ForMember(dest => dest.MedicalLicenseNumber, opt => opt.MapFrom(src => src.MedicalLicenseNumber))
    .ForMember(dest => dest.PhotosOfMedicalLicense, opt => opt.MapFrom(src => src.PhotosOfMedicalLicense))
    .ForMember(dest => dest.ProfilePicture, opt => opt.MapFrom(src => src.ProfilePicture))
    .ForMember(dest => dest.MedicalCollege, opt => opt.MapFrom(src => src.MedicalCollege))
    .ForMember(dest => dest.Certificates, opt => opt.MapFrom(src => src.Certificates))
    .ForMember(dest => dest.NameOfClinicOrHospital, opt => opt.MapFrom(src => src.NameOfClinicOrHospital))
    .ForMember(dest => dest.MedicalPracticeAddress, opt => opt.MapFrom(src => src.MedicalPracticeAddress))
    .ForMember(dest => dest.ConsultationFees, opt => opt.MapFrom(src => src.ConsultationFees))
    .ForMember(dest => dest.Address, opt => opt.MapFrom(src => src.Address))
    .ForMember(dest => dest.isVideoCallAvailable, opt => opt.MapFrom(src => src.isVideoCallAvailable))
    .ForMember(dest => dest.isVisitHomeAvailable, opt => opt.MapFrom(src => src.isVisitHomeAvailable))
    .ForMember(dest => dest.isAudioCallAvailable, opt => opt.MapFrom(src => src.isAudioCallAvailable))
    .ForMember(dest => dest.WorkHours, opt => opt.MapFrom(src => src.WorkHours));

            // Main response
            CreateMap<Doctor, GetNerestDoctorResponse>();

            // Mapping for the DoctorDto
            CreateMap<Doctor, DoctorDto>()
                .ForMember(dest => dest.Data, opt => opt.MapFrom(src => src)); // map Doctor to GetDoctorByIdResponse

            // Inner mapping for nested data
            CreateMap<Doctor, GetDoctorByIdResponse>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => src.FullName));
            CreateMap<DoctorCertificate, DoctorCertificateDto>();
            CreateMap<WorkingHours, WorkingHoursDto>();
        }

    }
}