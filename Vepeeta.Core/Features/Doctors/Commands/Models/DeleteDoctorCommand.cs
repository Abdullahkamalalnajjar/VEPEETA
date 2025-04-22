using MediatR;
using Vepeeta.Core.Bases;

namespace Vepeeta.Core.Features.Doctors.Commands.Models
{
    public class DeleteDoctorCommand : IRequest<Response<string>>
    {
        public string Id { get; set; }
    }
}
