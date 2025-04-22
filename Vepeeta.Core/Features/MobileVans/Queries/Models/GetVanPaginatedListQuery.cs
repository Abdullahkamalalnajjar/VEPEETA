using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vepeeta.Core.Features.Clinics.Queries.Ruslt;
using Vepeeta.Core.Features.MobileVans.Queries.Results;
using Vepeeta.Core.Wrappers;

namespace Vepeeta.Core.Features.MobileVans.Queries.Models
{
    public class GetVanPaginatedListQuery : IRequest<PaginatedResult<GetVanResponse>>
    {
        public GetVanPaginatedListQuery()
        {

        }
        public GetVanPaginatedListQuery(int pageNumber, int pageSize)
        {
            PageNumber = pageNumber;
            PageSize = pageSize;
        }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }

    }
}
