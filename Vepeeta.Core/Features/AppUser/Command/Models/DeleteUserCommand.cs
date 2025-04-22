using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vepeeta.Core.Bases;

namespace Vepeeta.Core.Features.AppUser.Command.Models
{
    public class DeleteUserCommand : IRequest<Response<string>>
    {
        public string Id { get; set; }
    }
}
