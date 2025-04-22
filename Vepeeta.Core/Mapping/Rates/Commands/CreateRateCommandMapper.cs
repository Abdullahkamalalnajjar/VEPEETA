using Vepeeta.Core.Features.Rates.Commands.Models;
using Vepeeta.Data.Entity;

namespace Vepeeta.Core.Mapping.Rates
{
    public partial class RateProfile
    {
        public void CreateRateCommand_Mapping()
        {
            CreateMap<CreateRateCommand, Rateing>();
        }
    }
}
