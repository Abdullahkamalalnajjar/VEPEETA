using MediatR;
using Vepeeta.Core.Bases;

namespace Vepeeta.Core.Features.Rates.Commands.Models
{
    public class CreateRateCommand : IRequest<Response<string>>
    {
        public double Rate { get; set; } = 0.0;
        public string? Comments { get; set; }
        public string DoctorId { get; set; }
    }
}
