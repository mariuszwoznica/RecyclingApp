using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RecyclingApp.Application.Models;
using RecyclingApp.Application.Users.Commands;
using RecyclingApp.Application.Users.Models;
using RecyclingApp.Application.Users.Queries;
using System.Threading;
using System.Threading.Tasks;

namespace RecyclingApp.WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UsersController : ControllerBase
{
    private readonly IMediator _mediator;

    public UsersController(IMediator mediator)
        => _mediator = mediator;

    [HttpGet]
    [ProducesResponseType(typeof(PagedResponse<UserResponse>), StatusCodes.Status200OK)]
    public async Task<PagedResponse<UserResponse>> GetUsers(
        [FromQuery] int pageNumber,
        [FromQuery] int pageSize,
        [FromQuery] string? firstName,
        [FromQuery] string? lastName,
        [FromQuery] string[]? sorting,
        CancellationToken cancellationToken)
        => await _mediator.Send(
            request: new GetUsers(
                Page: pageNumber,
                PageSize: pageSize,
                FirstName: firstName,
                LastName: lastName,
                Sorting: sorting),
            cancellationToken: cancellationToken);

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public async Task<IActionResult> RegisterUser([FromBody] RegisterUserDto request, CancellationToken cancellationToken)
    {
        await _mediator.Send(
            request: new RegisterUser(
                FirstName: request.FirstName,
                LastName: request.LastName),
            cancellationToken: cancellationToken);
        return Created(string.Empty, cancellationToken);
    }
}