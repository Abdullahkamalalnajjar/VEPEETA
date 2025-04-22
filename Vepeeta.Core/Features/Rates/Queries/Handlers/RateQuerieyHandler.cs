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
using Vepeeta.Core.Features.Rates.Commands.Models;
using Vepeeta.Core.Features.Rates.Queries.Models;
using Vepeeta.Core.Features.Rates.Queries.Results;
using Vepeeta.Core.Resources;
using Vepeeta.Data.Entity;
using Vepeeta.Data.Entity.Identity;
using Vepeeta.Service.Abstract;

namespace Vepeeta.Core.Features.Rates.Queries.Handlers
{
    public class RateQuerieyHandler : ResponseHandler,
        IRequestHandler<GetRateByDoctorIdQueriey, Response<GetRateByDoctorIdResponse>>
    {
        private readonly IStringLocalizer<SharedResources> _localizer;
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;
        private readonly IRateService _rateService;
        private readonly ResponseHandler _responseHandler;

        public RateQuerieyHandler(IStringLocalizer<SharedResources> localizer, IMapper mapper, UserManager<User> userManager, IRateService rateService,ResponseHandler responseHandler) :base(localizer)
        {
            _localizer = localizer;
            _mapper = mapper;
            _userManager = userManager;
            _rateService = rateService;
            _responseHandler = responseHandler;
        }
        public  async Task<Response<GetRateByDoctorIdResponse>> Handle(GetRateByDoctorIdQueriey request, CancellationToken cancellationToken)
        {
            var doctor = await _userManager.FindByIdAsync(request.DoctorId);
            if (doctor == null)
                return NotFound<GetRateByDoctorIdResponse>(_localizer["Doctor Not Found"]);

            var ratings = await _rateService.GetAllRatesByDoctorIdAsync(request.DoctorId);

            if (ratings == null || !ratings.Any())
            {
                return Success(new GetRateByDoctorIdResponse
                {
                    Avaragerate = 0,
                    Comments = new List<RateCommentDto>()
                });
            }

            var averageRate = ratings.Average(r => r.Rate);

            var comments = ratings
                .Select(r => new RateCommentDto
                {
                    Rate = r.Rate,
                    Comment = r.Comments
                }).ToList();

            var result = new GetRateByDoctorIdResponse
            {
                Avaragerate = Math.Round(averageRate,1),
                Comments = comments
            };

            return Success(result);


        }
    }
}
