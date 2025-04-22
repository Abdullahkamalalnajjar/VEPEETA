using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Localization;
using Vepeeta.Core.Bases;
using Vepeeta.Core.Features.Rates.Commands.Models;
using Vepeeta.Core.Resources;
using Vepeeta.Data.Entity;
using Vepeeta.Data.Entity.Identity;
using Vepeeta.Service.Abstract;

namespace Vepeeta.Core.Features.Rates.Commands.Handlers
{
    public class RateingCommandHandler : ResponseHandler,
        IRequestHandler<CreateRateCommand, Response<string>>,
        IRequestHandler<UpdateRateCommand, Response<string>>,
        IRequestHandler<DeleteRateCommand, Response<string>>
    {
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;
        private readonly IRateService _rateService;

        public RateingCommandHandler(IStringLocalizer<SharedResources> localizer, IMapper mapper, UserManager<User> userManager, IRateService rateService) : base(localizer)
        {
            _mapper = mapper;
            _userManager = userManager;
            _rateService = rateService;
        }

        public async Task<Response<string>> Handle(CreateRateCommand request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByIdAsync(request.DoctorId);
            if (user is null) return NotFound<string>();
            var rate = _mapper.Map<Rateing>(request);
            var result = await _rateService.CreateRateAsync(rate);
            if (result == "Created") return Created<string>(result);
            return BadRequest<string>(result);

        }

        public async Task<Response<string>> Handle(UpdateRateCommand request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByIdAsync(request.DoctorId);
            if (user is null) return NotFound<string>();
            var rate = _mapper.Map<Rateing>(request);
            var result = await _rateService.UpdateRateAsync(rate);
            if (result == "Updated") return Updated<string>(result);
            return BadRequest<string>(result);
        }

        public async Task<Response<string>> Handle(DeleteRateCommand request, CancellationToken cancellationToken)
        {
            var rate = await _rateService.GetRateByIdAsync(request.Id);
            if (rate is null) return NotFound<string>();
            var result = await _rateService.DeleteRateAsync(rate);
            if (result == "Deleted") return Deleted<string>();
            return BadRequest<string>(result);
        }
    }
}
