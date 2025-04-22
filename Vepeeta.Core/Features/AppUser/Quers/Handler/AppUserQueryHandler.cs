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
using Vepeeta.Core.Features.AppUser.Quers.Modles;
using Vepeeta.Core.Features.AppUser.Quers.Response;
using Vepeeta.Core.Resources;
using Vepeeta.Core.Wrappers;
using Vepeeta.Data.Entity.Identity;

namespace Vepeeta.Core.Features.AppUser.Quers.Handler
{
    public class AppUserQueryHandler : ResponseHandler,
     IRequestHandler<GetUserPaginatedListQuery,PaginatedResult<GetUserPaginatedListResponse>>,
    IRequestHandler<GetUserByIdQuery, Response<GetUserByIdResponse>>

    {
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;

        public AppUserQueryHandler(IMapper mapper, UserManager<User> userManager, IStringLocalizer<SharedResources> localizer) : base(localizer)
        {
            _mapper = mapper;
            _userManager = userManager;
        }

        public async Task<PaginatedResult<GetUserPaginatedListResponse>> Handle(GetUserPaginatedListQuery request, CancellationToken cancellationToken)
        {
         //  var users = _userManager.Users.AsQueryable();
           var users = _userManager.Users.OfType<PetOwner>().AsQueryable();
            var paginatedList = await _mapper.ProjectTo<GetUserPaginatedListResponse>(users)
                .ToPaginatedListAsync(request.PageNumber, request.PageSize);
            return paginatedList;
        }

        public async Task<Response<GetUserByIdResponse>> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByIdAsync(request.UserId);
            if (user is null) return NotFound<GetUserByIdResponse>();
            //make mapping
            var userMapper = _mapper.Map<GetUserByIdResponse>(user);
            return Success(userMapper);
        }
    }
}
