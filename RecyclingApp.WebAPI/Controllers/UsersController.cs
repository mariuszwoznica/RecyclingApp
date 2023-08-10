using MediatR;
using Microsoft.AspNetCore.Mvc;
using RecyclingApp.Application.Commands;
using RecyclingApp.Application.Queries;
using RecyclingApp.Application.RequestParamiters;
using System.Threading.Tasks;

namespace RecyclingApp.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UsersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /*[HttpGet] TODO refactor
        public async Task<IActionResult> GetUsers([FromQuery] GetUsersRequest request)
        {
            return Ok(await _mediator.Send(new GetAllUsersQuery(request.Page, request.Limit, request.FirstName,
                request.LastName, request.OrderBy)));
        }

        [HttpPost]
        public async Task<IActionResult> RegisterUser([FromBody] RegisterUser request)
        {
            var user = Ok(await _mediator.Send(new RegisterUserCommand(request.FirstName, request.LastName)));
            return Created(string.Empty, user);
        }*/
    }
}
