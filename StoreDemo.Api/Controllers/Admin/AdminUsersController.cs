using MediatR;
using Microsoft.AspNetCore.Mvc;
using StoreDemo.Application.Features.Users.Commands.CreateUser;
using StoreDemo.Application.Features.Users.Commands.DeleteUser;
using StoreDemo.Application.Features.Users.Commands.UpdateUser;
using StoreDemo.Application.Features.Users.Queries.GetUser;
using StoreDemo.Application.Features.Users.Queries.GetUsers;
using StoreDemo.Domain.Entities;

namespace StoreDemo.Api.Controllers.Admin;


[Route("adminapi/v1/Users")]
public class AdminUsersController : Controller
{
    private readonly IMediator _mediator;

    public AdminUsersController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<IEnumerable<User>>> GetUsers()
    {
        var dtos = await _mediator.Send(new GetUsersListQuery());
        return Ok(dtos);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<User>> GetUser(int userId)
    {
        var query = new GetUserQuery() { UserId = userId };

        return Ok(await _mediator.Send(query));
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<User>> CreateUser(CreateUserCommand cmd)
    {
        var user = await _mediator.Send(cmd);
        return Ok(user);
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> UpdateUser(ulong id, UpdateUserCommand cmd)
    {
        if (id != cmd.UserId) return BadRequest();

        await _mediator.Send(cmd);
        return NoContent();
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> DeleteUser(int userId)
    {
        var cmd = new DeleteUserCommand() { UserId = userId };
        await _mediator.Send(cmd);
        return NoContent();
    }

}
