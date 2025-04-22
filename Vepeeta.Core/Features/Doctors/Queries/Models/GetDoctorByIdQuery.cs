using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vepeeta.Core.Bases;
using Vepeeta.Core.Features.AppUser.Quers.Response;
using Vepeeta.Core.Features.Doctors.Queries.Results;

namespace Vepeeta.Core.Features.Doctors.Queries.Models
{
    public class GetDoctorByIdQuery : IRequest<Response<GetDoctorByIdResponse>>
    {
        public string DoctorId { get; set; }
    }
}