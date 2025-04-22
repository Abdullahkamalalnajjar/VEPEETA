using Microsoft.AspNetCore.Mvc;
using Vepeeta.Api.Base;
using Vepeeta.Core.Features.AppUser.Command.Models;
using Vepeeta.Core.Features.AppUser.Quers.Modles;
using Vepeeta.Data.AppMetaData;

namespace Vepeeta.Api.Controllers
{

    public class AppUserController : AppBaseController
    {
        //POST Create User
        [HttpPost(Router.UserRouting.Create)]
        public async Task<IActionResult> CreateUser([FromForm] CreateUserCommand command)
        {
            var response = await Mediator.Send(command);
            return NewResult(response);
        }
        //GET Pagination
        [HttpGet(Router.UserRouting.Paginated)]
        public async Task<IActionResult> GetUserAsPaginated([FromQuery] GetUserPaginatedListQuery query)
        {
            var response = await Mediator.Send(query);
            return Ok(response);
        }


        //GET UserById
        [HttpGet(Router.UserRouting.GetById)]
        public async Task<IActionResult> GetUserById([FromRoute] string id)
        {
            var request = new GetUserByIdQuery() { UserId = id };
            var response = await Mediator.Send(request);
            return Ok(response);
        }


        //PUT EditUser
        [HttpPut(Router.UserRouting.Edit)]
        public async Task<IActionResult> EditUser([FromForm] EditUserCommand command)
        {
            var response = await Mediator.Send(command);
            return NewResult(response);
        }
        //Delete DeleteAppUser
        [HttpDelete(Router.UserRouting.Delete)]
        public async Task<IActionResult> DeleteUser([FromRoute] string id)
        {
            Console.WriteLine($"🔍 Received Id for deletion: {id}");

            var response = await Mediator.Send(new DeleteUserCommand { Id = id });
            return NewResult(response);
        }
    }
}