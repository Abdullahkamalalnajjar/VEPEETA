using Microsoft.AspNetCore.Mvc;
using Vepeeta.Api.Base;
using Vepeeta.Core.Features.MobileVans.Commands.Models;
using Vepeeta.Core.Features.MobileVans.Queries.Models;
using Vepeeta.Core.Features.Rates.Commands.Models;
using Vepeeta.Core.Features.Rates.Queries.Models;
using Vepeeta.Data.AppMetaData;

namespace Vepeeta.Api.Controllers
{

    public class RateController : AppBaseController
    {
        [HttpPost(Router.RateRouting.Create)]
        public async Task<IActionResult> CreateRate([FromBody] CreateRateCommand command)
        {
            var response = await Mediator.Send(command);
            return Ok(response);
        }

        [HttpPut(Router.RateRouting.Edit)]
        public async Task<IActionResult> EditRate([FromBody] UpdateRateCommand command)
        {
            var response = await Mediator.Send(command);
            return Ok(response);
        }
        [HttpDelete(Router.RateRouting.Delete)]
        public async Task<IActionResult> DeleteVan([FromRoute] int id)
        {
            Console.WriteLine($"🔍 Received Id for deletion: {id}");

            var response = await Mediator.Send(new DeleteRateCommand { Id = id });
            return NewResult(response);
        }
        [HttpGet(Router.RateRouting.GetById)]
        public async Task<IActionResult> GetDoctorRateByDoctorId([FromRoute]   string id)
        {
            var response = await Mediator.Send( new GetRateByDoctorIdQueriey { DoctorId = id });
            return Ok(response);
        }
    }
}
