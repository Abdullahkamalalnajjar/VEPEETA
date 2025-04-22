using MediatR;
using Vepeeta.Core.Bases;

namespace Vepeeta.Core.Features.Rates.Commands.Models
{
    public class DeleteRateCommand : IRequest<Response<string>>
    {
        public int Id { get; set; }
    }
}
