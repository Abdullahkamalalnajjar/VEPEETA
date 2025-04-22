using AutoMapper;

namespace Vepeeta.Core.Mapping.Rates
{
    public partial class RateProfile : Profile
    {
        public RateProfile()
        {
            CreateRateCommand_Mapping();
            EditeRateCommand_Mapping();
        }
    }
}
