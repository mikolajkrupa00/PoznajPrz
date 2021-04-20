using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoznajRzeszow.Application.Commands.Friends.RemoveFriend
{
    public class RemoveFriendCommand : IRequest<Unit>
    {
        public Guid User1Id { get; set; }
        public Guid User2Id { get; set; }
    }
}
