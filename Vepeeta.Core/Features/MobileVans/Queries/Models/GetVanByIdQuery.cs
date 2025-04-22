using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vepeeta.Core.Bases;
using Vepeeta.Core.Features.Clinics.Queries.Ruslt;
using Vepeeta.Core.Features.MobileVans.Queries.Results;

namespace Vepeeta.Core.Features.MobileVans.Queries.Models
{
    public class GetVanByIdQuery : IRequest<Response<GetVanResponse>>
    {
        public string  VanId { get; set; }

    }

}
