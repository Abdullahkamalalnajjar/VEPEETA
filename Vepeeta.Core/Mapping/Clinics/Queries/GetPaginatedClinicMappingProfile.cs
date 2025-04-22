using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vepeeta.Core.Features.Clinics.Queries.Ruslt;
using Vepeeta.Data.Entity.Identity.Clinics.Clinic_Services;
using Vepeeta.Data.Entity.Identity.Clinics;

namespace Vepeeta.Core.Mapping.Clinics
{
    public partial class ClinicProfile
    {
        public void GetPaginatedClinicMappingProfile()
        {
            // Clinic → GetClinicPaginatedListResponse
            CreateMap<Clinic, GetClinicResponse>();

            // ClinicServices → ClinicServiceDto (مع تفاصيل الخدمة من BaseServices)
            CreateMap<ClinicServices, ClinicServiceDto>()
                .ForMember(dest => dest.NameAr, opt => opt.MapFrom(src => src.BaseServices.NameAr))
                .ForMember(dest => dest.NameEn, opt => opt.MapFrom(src => src.BaseServices.NameEn));

            // ClincsImage → ClincsImageDto
            CreateMap<ClincsImage, ClincsImageDto>();

            // Clinics_WorkingHours → Clinics_WorkingHoursDto
            CreateMap<Clinics_WorkingHours, Clinics_WorkingHoursDto>();
        }
    }
}