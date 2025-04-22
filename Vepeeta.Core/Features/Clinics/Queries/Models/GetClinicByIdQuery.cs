using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vepeeta.Core.Bases;
using Vepeeta.Core.Features.Clinics.Queries.Ruslt;

namespace Vepeeta.Core.Features.Clinics.Queries.Models
{
    public class GetClinicByIdQuery : IRequest<Response<GetClinicResponse>>
    {
        public string ClinicId { get; set; }

    }
}
