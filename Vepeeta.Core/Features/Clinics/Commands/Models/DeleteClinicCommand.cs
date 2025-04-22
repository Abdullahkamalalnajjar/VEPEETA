using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vepeeta.Core.Bases;

namespace Vepeeta.Core.Features.Clinics.Commands.Models
{
    public class DeleteClinicCommand : IRequest<Response<String>>
    {
        public string Id { get; set; }
    }
}
