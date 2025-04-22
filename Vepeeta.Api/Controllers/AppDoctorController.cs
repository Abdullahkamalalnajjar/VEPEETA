using Microsoft.AspNetCore.Mvc;
using Vepeeta.Api.Base;
using Vepeeta.Core.Features.Doctors.Commands.Models;
using Vepeeta.Core.Features.Doctors.Queries.Models;
using Vepeeta.Data.AppMetaData;

namespace Vepeeta.Api.Controllers
{


    public class AppDoctorController : AppBaseController
    {
        [HttpPost(Router.DoctorRouting.Create)]
     //   [Consumes("multipart/form-data")]  // لتحديد أننا نقبل طلبات multipart

        public async Task<IActionResult> CreateDoctor([FromBody] CreateDoctorCommand command)
        {
            var response = await Mediator.Send(command);
            return NewResult(response);
        }

        //GET Pagination
        [HttpGet(Router.DoctorRouting.Paginated)]
        public async Task<IActionResult> GetDoctorAsPaginated([FromQuery] GetDoctorPaginatedListQuery query)
        {
            var response = await Mediator.Send(query);
            return Ok(response);
        }

        //GET DoctorById
        [HttpGet(Router.DoctorRouting.GetById)]
        public async Task<IActionResult> GetUserById([FromRoute] string id)
        {
            var request = new GetDoctorByIdQuery() { DoctorId = id };
            var response = await Mediator.Send(request);
            return Ok(response);
        }
        //PUT EditDoctor
        [HttpPut(Router.DoctorRouting.Edit)]
        public async Task<IActionResult> EditDoctor([FromForm] EditDoctorCommand command)
        {
            var response = await Mediator.Send(command);
            return NewResult(response);
        }

        //Delete DeleteDoctor
        [HttpDelete(Router.DoctorRouting.Delete)]
        public async Task<IActionResult> DeleteDoctor([FromRoute] string id)
        {
            Console.WriteLine($"🔍 Received Id for deletion: {id}");

            var response = await Mediator.Send(new DeleteDoctorCommand { Id = id });
            return NewResult(response);
        }

        //GET Pagination
        [HttpGet(Router.DoctorRouting.NearestDoctor)]
        public async Task<IActionResult> GetNerestDoctor([FromQuery] GetNerestDoctorQuery query)
        {
            var response = await Mediator.Send(query);
            return Ok(response);
        }


    }
}
