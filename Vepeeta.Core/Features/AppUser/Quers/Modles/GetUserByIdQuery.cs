using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vepeeta.Core.Bases;
using Vepeeta.Core.Features.AppUser.Quers.Response;

namespace Vepeeta.Core.Features.AppUser.Quers.Modles
{
    public class GetUserByIdQuery : IRequest<Response<GetUserByIdResponse>>
    {
        public string UserId { get; set; }
    }
}
