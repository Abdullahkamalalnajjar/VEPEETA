using MediatR;
using Vepeeta.Core.Bases;

namespace Vepeeta.Core.Features.Rates.Commands.Models
{
    public class UpdateRateCommand : IRequest<Response<string>>
    {
        public int Id { get; set; }
        public double Rate { get; set; }
        public string? Comments { get; set; }
        public string DoctorId { get; set; }
    }
}
