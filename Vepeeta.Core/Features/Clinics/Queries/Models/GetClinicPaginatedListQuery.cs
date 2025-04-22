using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vepeeta.Core.Features.Clinics.Queries.Ruslt;
using Vepeeta.Core.Wrappers;

namespace Vepeeta.Core.Features.Clinics.Queries.Models
{
    public class GetClinicPaginatedListQuery : IRequest<PaginatedResult<GetClinicResponse>>
    {
        public GetClinicPaginatedListQuery()
        {

        }
        public GetClinicPaginatedListQuery(int pageNumber, int pageSize)
        {
            PageNumber = pageNumber;
            PageSize = pageSize;
        }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }

    }
}
