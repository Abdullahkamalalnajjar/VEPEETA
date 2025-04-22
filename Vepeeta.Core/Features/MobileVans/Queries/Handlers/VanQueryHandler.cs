using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vepeeta.Core.Bases;
using Vepeeta.Core.Features.Clinics.Queries.Models;
using Vepeeta.Core.Features.Clinics.Queries.Ruslt;
using Vepeeta.Core.Features.MobileVans.Queries.Models;
using Vepeeta.Core.Features.MobileVans.Queries.Results;
using Vepeeta.Core.Resources;
using Vepeeta.Core.Wrappers;
using Vepeeta.Data.Entity.Identity;
using Vepeeta.Data.Entity.Identity.Clinics;
using Vepeeta.Data.Entity.MobileVan;

namespace Vepeeta.Core.Features.MobileVans.Queries.Handlers
{
    public class VanQueryHandler : ResponseHandler,
 IRequestHandler<GetVanPaginatedListQuery, PaginatedResult<GetVanResponse>>,
 IRequestHandler<GetVanByIdQuery, Response<GetVanResponse>>
    {
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;
        private readonly IStringLocalizer<SharedResources> _localizer;

        public VanQueryHandler(IMapper mapper, UserManager<User> userManager, IStringLocalizer<SharedResources> localizer) : base(localizer)
        {
            _mapper = mapper;
            _userManager = userManager;
            _localizer = localizer;
        }

        public async Task<PaginatedResult<GetVanResponse>> Handle(GetVanPaginatedListQuery request, CancellationToken cancellationToken)
        {
            var users = _userManager.Users.OfType<Van>().AsQueryable();
            var paginatedList = await _mapper.ProjectTo<GetVanResponse>(users)
                .ToPaginatedListAsync(request.PageNumber, request.PageSize);
            return paginatedList;
        }

        public async Task<Response<GetVanResponse>> Handle(GetVanByIdQuery request, CancellationToken cancellationToken)
        {
            var user = await _userManager.Users.OfType<Van>()
                          .Include(c => c.WorkingHours)
                           .Include(c => c.VanServices)
                       .ThenInclude(cs => cs.BaseServices)
                   .FirstOrDefaultAsync(c => c.Id == request.VanId);
                  if (user is null) return NotFound<GetVanResponse>();
            //make mapping
               var userMapper = _mapper.Map<GetVanResponse>(user);
               return Success(userMapper);
        }
    }
}
