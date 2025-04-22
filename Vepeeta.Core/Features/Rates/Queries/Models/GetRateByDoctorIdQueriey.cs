using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vepeeta.Core.Bases;
using Vepeeta.Core.Features.Doctors.Queries.Results;
using Vepeeta.Core.Features.Rates.Queries.Results;

namespace Vepeeta.Core.Features.Rates.Queries.Models
{
    public class GetRateByDoctorIdQueriey : IRequest<Response<GetRateByDoctorIdResponse>>
    {
        public string DoctorId { get; set; }
    }
}
