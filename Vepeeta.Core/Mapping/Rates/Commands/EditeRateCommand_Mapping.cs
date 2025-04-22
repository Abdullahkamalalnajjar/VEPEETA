using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vepeeta.Core.Features.Rates.Commands.Models;
using Vepeeta.Data.Entity;

namespace Vepeeta.Core.Mapping.Rates
{
    public partial class RateProfile
    {
        public void EditeRateCommand_Mapping()
        {
            CreateMap<UpdateRateCommand, Rateing>();
        }
    }
}