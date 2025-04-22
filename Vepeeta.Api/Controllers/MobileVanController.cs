using MediatR;
using Microsoft.AspNetCore.Mvc;
using Vepeeta.Api.Base;
using Vepeeta.Core.Features.Clinics.Commands.Models;
using Vepeeta.Core.Features.Clinics.Queries.Models;
using Vepeeta.Core.Features.MobileVans.Commands.Models;
using Vepeeta.Core.Features.MobileVans.Queries.Models;
using Vepeeta.Data.AppMetaData;

namespace Vepeeta.Api.Controllers
{

    public class MobileVanController : AppBaseController
    {
        [HttpPost(Router.VanRouting.Create)]
        public async Task<IActionResult> CreateVan([FromForm] CreateVanCommand command)
        {
            var response = await Mediator.Send(command);
            return NewResult(response);
        }
        [HttpGet(Router.VanRouting.Paginated)]
        public async Task<IActionResult> GetVanPaginated([FromQuery] GetVanPaginatedListQuery query)
        {
            var response = await Mediator.Send(query);
            return Ok(response);
        }
        [HttpGet(Router.VanRouting.GetById)]
        public async Task<IActionResult> GetVanById([FromRoute] string id)
        {
            var request = new GetVanByIdQuery() { VanId = id };
            var response = await Mediator.Send(request);
            return Ok(response);
        }
        [HttpDelete(Router.VanRouting.Delete)]
        public async Task<IActionResult> DeleteVan([FromRoute] string id)
        {
            Console.WriteLine($"🔍 Received Id for deletion: {id}");

            var response = await Mediator.Send(new DeleteVanCommand { Id = id });
            return NewResult(response);
        }
        [HttpPut(Router.VanRouting.Edit)]
        public async Task<IActionResult> EditVan([FromForm] EditVanCommand command)
        {
            var response = await Mediator.Send(command);
            return NewResult(response);
        }
    }


}
