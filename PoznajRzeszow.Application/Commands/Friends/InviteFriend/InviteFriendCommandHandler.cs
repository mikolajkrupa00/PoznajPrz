using MediatR;
using PoznajRzeszow.Domain.Interfaces.Repositories;
using PoznajRzeszow.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PoznajRzeszow.Application.Commands.Friends.InviteFriend
{
    public class InviteFriendCommandHandler : IRequestHandler<InviteFriendCommand, Unit>
    {
        private readonly IFriendRepository _friendRepository;

        public InviteFriendCommandHandler(IFriendRepository friendRepository)
        {
            _friendRepository = friendRepository;
        }

        public async Task<Unit> Handle(InviteFriendCommand request, CancellationToken cancellationToken)
        {
            var invite = Friend.Create(request.User1Id, request.User2Id);
            await _friendRepository.CreateAsync(invite);
            return Unit.Value;
        }
    }
}
