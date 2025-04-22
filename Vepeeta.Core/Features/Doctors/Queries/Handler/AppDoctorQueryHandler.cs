using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Localization;
using Vepeeta.Core.Bases;
using Vepeeta.Core.Features.Doctors.Queries.Models;
using Vepeeta.Core.Features.Doctors.Queries.Results;
using Vepeeta.Core.Resources;
using Vepeeta.Core.Wrappers;
using Vepeeta.Data.Entity.Identity;
using Vepeeta.Data.Entity.Identity.Doctor;

namespace Vepeeta.Core.Features.Doctors.Quers.Handler
{
    public class AppDoctorQueryHandler : ResponseHandler,
     IRequestHandler<GetDoctorPaginatedListQuery, PaginatedResult<GetDoctorPaginatedListResponse>>,
    IRequestHandler<GetDoctorByIdQuery, Response<GetDoctorByIdResponse>>,
    IRequestHandler<GetNerestDoctorQuery, Response<GetNerestDoctorResponse>>

    {
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;
        private readonly IStringLocalizer<SharedResources> _localizer;

        public AppDoctorQueryHandler(IMapper mapper, UserManager<User> userManager, IStringLocalizer<SharedResources> localizer) : base(localizer)
        {
            _mapper = mapper;
            _userManager = userManager;
            _localizer = localizer;
        }

        public async Task<PaginatedResult<GetDoctorPaginatedListResponse>> Handle(GetDoctorPaginatedListQuery request, CancellationToken cancellationToken)
        {
            var users = _userManager.Users.OfType<Doctor>().AsQueryable();
            var paginatedList = await _mapper.ProjectTo<GetDoctorPaginatedListResponse>(users)
                .ToPaginatedListAsync(request.PageNumber, request.PageSize);
            return paginatedList;
        }

        public async Task<Response<GetDoctorByIdResponse>> Handle(GetDoctorByIdQuery request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByIdAsync(request.DoctorId);
            if (user is null) return NotFound<GetDoctorByIdResponse>();
            //make mapping
            var userMapper = _mapper.Map<GetDoctorByIdResponse>(user);
            return Success(userMapper);
        }

        public async Task<Response<GetNerestDoctorResponse>> Handle(GetNerestDoctorQuery request, CancellationToken cancellationToken)
        {
            var doctorsAvailable = await _userManager.Users
                .OfType<Doctor>()
                .Where(x => x.isVisitHomeAvailable == true)
                .Include(x => x.WorkHours)
                .Include(x => x.Certificates)
                .Include(x => x.Rateing)
                .ToListAsync();

            if (doctorsAvailable is null || !doctorsAvailable.Any())
                return NotFound<GetNerestDoctorResponse>();

            if (!double.TryParse(request.PetOwnerLatitude, out double ownerLat) ||
                !double.TryParse(request.PetOwnerLongitude, out double ownerLon))
            {
                return Fail<GetNerestDoctorResponse>("Invalid coordinates provided.");
            }

            // حساب المسافة باستخدام Haversine Formula
            var nearestDoctors = doctorsAvailable
                .Select(doc => new
                {
                    Doctor = doc,
                    Distance = GetDistance(ownerLat, ownerLon, doc.Latitude, doc.Longitude)
                })
                .OrderBy(x => x.Distance)
                .Take(10)
                .ToList();

            var result = new GetNerestDoctorResponse
            {
                Doctors = nearestDoctors.Select(d => new DoctorDto
                {
                    Id = d.Doctor.Id,
                    FullName = d.Doctor.FullName,
                    Latitude = d.Doctor.Latitude,
                    Longitude = d.Doctor.Longitude,
                    DistanceInKm = Math.Round(d.Distance, 2),
                    Data = _mapper.Map<GetDoctorByIdResponse>(d.Doctor)
                }).ToList(),


            };

            return Success(result);
        }

        private double GetDistance(double lat1, double lon1, double? lat2, double? lon2)
        {
            var R = 6371; // نصف قطر الأرض بالكيلومتر
            var dLat = DegreesToRadians(lat2 - lat1);
            var dLon = DegreesToRadians(lon2 - lon1);
            var a =
                Math.Sin(dLat / 2) * Math.Sin(dLat / 2) +
                Math.Cos(DegreesToRadians(lat1)) * Math.Cos(DegreesToRadians(lat2)) *
                Math.Sin(dLon / 2) * Math.Sin(dLon / 2);
            var c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));
            return R * c;
        }

        private double DegreesToRadians(double? deg)
        {
            return deg * (Math.PI / 180) ?? 0;
        }

    }
}
