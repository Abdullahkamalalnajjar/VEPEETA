using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vepeeta.Core.Bases;
using Vepeeta.Core.Features.Clinics.Queries.Models;
using Vepeeta.Core.Features.Clinics.Queries.Ruslt;
using Vepeeta.Core.Resources;
using Vepeeta.Core.Wrappers;
using Vepeeta.Data.Entity.Identity.Clinics;
using Vepeeta.Data.Entity.Identity;
using Microsoft.EntityFrameworkCore;

namespace Vepeeta.Core.Features.Clinics.Queries.Handlers
{
    public class ClinicQueryHandler : ResponseHandler,
 IRequestHandler<GetClinicPaginatedListQuery, PaginatedResult<GetClinicResponse>>,
      IRequestHandler<GetClinicByIdQuery, Response<GetClinicResponse>>
    {
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;
        private readonly IStringLocalizer<SharedResources> _localizer;

        public ClinicQueryHandler(IMapper mapper, UserManager<User> userManager, IStringLocalizer<SharedResources> localizer) : base(localizer)
        {
            _mapper = mapper;
            _userManager = userManager;
            _localizer = localizer;
        }

        public async Task<PaginatedResult<GetClinicResponse>> Handle(GetClinicPaginatedListQuery request, CancellationToken cancellationToken)
        {
            var users = _userManager.Users.OfType<Clinic>().AsQueryable();
            var paginatedList = await _mapper.ProjectTo<GetClinicResponse>(users)
                .ToPaginatedListAsync(request.PageNumber, request.PageSize);
            return paginatedList;
        }

        public async Task<Response<GetClinicResponse>> Handle(GetClinicByIdQuery request, CancellationToken cancellationToken)
        {
            var user = await _userManager.Users.OfType<Clinic>()
                                       .Include(c => c.ImageUrls)
                                      .Include(c => c.WorkingHours)
                                       .Include(c => c.ClinicServices)
           .ThenInclude(cs => cs.BaseServices)
       .FirstOrDefaultAsync(c => c.Id == request.ClinicId);
            if (user is null) return NotFound<GetClinicResponse>();
            //make mapping
            var userMapper = _mapper.Map<GetClinicResponse>(user);
            return Success(userMapper);
        }
    }
}
