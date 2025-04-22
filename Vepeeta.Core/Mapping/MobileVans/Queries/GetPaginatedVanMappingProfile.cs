using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vepeeta.Core.Features.MobileVans.Queries.Results;
using Vepeeta.Data.Entity.MobileVan.MobileVanService;
using Vepeeta.Data.Entity.MobileVan;

namespace Vepeeta.Core.Mapping.MobileVans
{
    public partial class MobileVanProfile
    {
        public void GetPaginatedVanMappingProfile()
        {
            CreateMap<Van, GetVanResponse>()
           
             .ForMember(dest => dest.VanServices, opt => opt.MapFrom(src => src.VanServices))
             .ForMember(dest => dest.WorkingHours, opt => opt.MapFrom(src => src.WorkingHours));

            CreateMap<VanServices, VanServiceDto>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.NameAr, opt => opt.MapFrom(src => src.BaseServices.NameAr))
                .ForMember(dest => dest.NameEn, opt => opt.MapFrom(src => src.BaseServices.NameEn));

            CreateMap<VanWorkingHour, Van_WorkingHoursDto>();

        }
    }
}

