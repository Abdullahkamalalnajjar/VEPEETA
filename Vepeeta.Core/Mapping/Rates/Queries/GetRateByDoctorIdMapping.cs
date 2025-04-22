using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vepeeta.Core.Features.Rates.Queries.Results;
using Vepeeta.Data.Entity;

namespace Vepeeta.Core.Mapping.Rates
{
    public partial class RateProfile
    {
        public void GetRateByDoctorIdMapping()
        {
            CreateMap<Rateing, RateCommentDto>()
           .ForMember(dest => dest.Rate, opt => opt.MapFrom(src => src.Rate))
           .ForMember(dest => dest.Comment, opt => opt.MapFrom(src => src.Comments));
        }
    }
}
