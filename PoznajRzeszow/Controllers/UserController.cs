using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PoznajRzeszow.Application.Commands.Users.AutheticateUser;
using PoznajRzeszow.Application.Commands.Users.ChangeUserDetails;
using PoznajRzeszow.Application.Commands.Users.BlockUser;
using PoznajRzeszow.Application.Commands.Users.UnblockUser;
using PoznajRzeszow.Application.Commands.Users.RegisterUser;
using PoznajRzeszow.Application.Queries.Users.GetUser;
using PoznajRzeszow.Application.Queries.Users.GetUsersList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PoznajRzeszow.Application.Commands.Users.ChangePassword;

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
            try
            {
                var registeredUser = await _mediator.Send(command);
                return Created($"api/User/{registeredUser.UserId}", registeredUser);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{userId}")]
        public async Task<IActionResult> GetUser([FromRoute] Guid userId)
            => Ok(await _mediator.Send(new GetUserQuery
            {
                UserId = userId
            }));

        [HttpGet("blockedUsers")]
        public async Task<IActionResult> GetUsersList()
            => Ok(await _mediator.Send(new GetUsersListQuery
            {
            }));

        [HttpPut("blockUser/{username}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> BlockUser([FromRoute] string username)
            => Ok(await _mediator.Send(new BlockUserCommand
            {
                Username = username
            }));

        [HttpPut("unblockUser/{username}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> UnblockUser([FromRoute] string username)
            => Ok(await _mediator.Send(new UnblockUserCommand
            {
                Username = username
            }));

        [HttpPut("changeUserDetails")]
        [Authorize]
        public async Task<IActionResult> ChangeUserDetails([FromBody] ChangeUserDetailsCommand command)
        {
            try
            {
                await _mediator.Send(command);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("changePassword")]
        [Authorize]
        public async Task<IActionResult> ChangePassword([FromBody] ChangePasswordCommand command)
        {
            try
            {
                await _mediator.Send(command);
                return NoContent();
            }
            catch (Exception ex)
            {
                if (ex.Message == "Wrong password") return Unauthorized(ex.Message);
                else return BadRequest(ex.Message);
            }
        }

        [AllowAnonymous]
        [HttpPost("authenticate")]
        public async Task<IActionResult> AuthenticateUser([FromBody] AuthenticateUserCommand command)
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
