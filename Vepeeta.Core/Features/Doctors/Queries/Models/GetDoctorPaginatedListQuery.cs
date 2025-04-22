using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vepeeta.Core.Features.AppUser.Quers.Response;
using Vepeeta.Core.Features.Doctors.Queries.Results;
using Vepeeta.Core.Wrappers;

namespace Vepeeta.Core.Features.Doctors.Queries.Models
{
    public class GetDoctorPaginatedListQuery : IRequest<PaginatedResult<GetDoctorPaginatedListResponse>>
    {
        public GetDoctorPaginatedListQuery()
        {

        }
        public GetDoctorPaginatedListQuery(int pageNumber, int pageSize)
        {
            PageNumber = pageNumber;
            PageSize = pageSize;
        }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }

    }
}
