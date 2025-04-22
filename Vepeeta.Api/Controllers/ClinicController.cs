using Microsoft.AspNetCore.Mvc;
using Vepeeta.Api.Base;
using Vepeeta.Core.Features.Clinics.Commands.Models;
using Vepeeta.Core.Features.Clinics.Queries.Models;
using Vepeeta.Data.AppMetaData;

namespace Vepeeta.Api.Controllers
{

    public class ClinicController : AppBaseController
    {
        [HttpPost(Router.ClinicRouting.Create)]
        public async Task<IActionResult> CreateClinic([FromForm] CreateClinicCommand command)
        {
            var response = await Mediator.Send(command);
            return NewResult(response);
        }

        //GET Pagination
        [HttpGet(Router.ClinicRouting.Paginated)]
        public async Task<IActionResult> GetClinicPaginated([FromQuery] GetClinicPaginatedListQuery query)
        {
            var response = await Mediator.Send(query);
            return Ok(response);
        }
        //GET ClinicById
        [HttpGet(Router.ClinicRouting.GetById)]
        public async Task<IActionResult> GetClinicById([FromRoute] string id)
        {
            var request = new GetClinicByIdQuery() { ClinicId = id };
            var response = await Mediator.Send(request);
            return Ok(response);
        }
        [HttpDelete(Router.ClinicRouting.Delete)]
        public async Task<IActionResult> DeleteClinic([FromRoute] string id)
        {
            Console.WriteLine($"🔍 Received Id for deletion: {id}");

            var response = await Mediator.Send(new DeleteClinicCommand { Id = id });
            return NewResult(response);
        }
        [HttpPut(Router.ClinicRouting.Edit)]
        public async Task<IActionResult> EditClinic([FromForm] EditClinicCommand command)
        {
            var response = await Mediator.Send(command);
            return NewResult(response);
        }
    }
}
