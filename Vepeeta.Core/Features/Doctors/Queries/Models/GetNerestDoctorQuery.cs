using MediatR;
using Vepeeta.Core.Bases;
using Vepeeta.Core.Features.Doctors.Queries.Results;

namespace Vepeeta.Core.Features.Doctors.Queries.Models
{
    public class GetNerestDoctorQuery : IRequest<Response<GetNerestDoctorResponse>>
    {

        public string? PetOwnerLatitude { get; set; }
        public string? PetOwnerLongitude { get; set; }

    }
}
