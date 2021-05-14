using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PoznajRzeszow.Application.Commands.Users.AutheticateUser;
using PoznajRzeszow.Application.Commands.Users.BlockUser;
using PoznajRzeszow.Application.Commands.Users.RegisterUser;
using PoznajRzeszow.Application.Queries.Users.GetUser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PoznajRzeszow.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> RegisterUser([FromBody] RegisterUserCommand command)
        {
            var id = await _mediator.Send(command);
            return Ok(id);
        }

        [HttpGet("{userId}")]
        public async Task<IActionResult> GetUser([FromRoute] Guid userId)
            => Ok(await _mediator.Send(new GetUserQuery
            {
                UserId = userId
            }));

        [HttpPut("blockUser/{username}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> BlockUser([FromRoute] string username)
            => Ok(await _mediator.Send(new BlockUserCommand
            {
                Username = username
            }));

        [HttpPost("authenticate")]
        public async Task<IActionResult> AuthenticateUser([FromBody] AutheticateUserCommand command)
        {
            try
            {
                return Ok(await _mediator.Send(command));
            }
            catch
            {
                return Unauthorized();
            }
        }
    }
}
