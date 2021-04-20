using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PoznajRzeszow.Application.Commands.Friends.AcceptInvite;
using PoznajRzeszow.Application.Commands.Friends.InviteFriend;
using PoznajRzeszow.Application.Commands.Friends.RemoveFriend;
using PoznajRzeszow.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PoznajRzeszow.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FriendController : ControllerBase
    {
        private readonly IFriendRepository _friendRepository;
        private readonly IMediator _mediator;
        
        public FriendController(IFriendRepository friendRepository, IMediator mediator)
        {
            _friendRepository = friendRepository;
            _mediator = mediator;
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> CreateInvite([FromBody] InviteFriendCommand command)
            => Ok(await _mediator.Send(command));

        [HttpPut]
        [Authorize]
        public async Task<IActionResult> AcceptInvite([FromBody]AcceptInviteCommand command)
            => Ok(await _mediator.Send(command));

        [HttpDelete("{user1Id}/{user2Id}")]
        [Authorize]
        public async Task<IActionResult> RemoveFriend([FromRoute] Guid user1Id, [FromRoute] Guid user2Id)
            => Ok(await _mediator.Send(new RemoveFriendCommand
            {
                User1Id = user1Id,
                User2Id = user2Id
            }));
    }
}
