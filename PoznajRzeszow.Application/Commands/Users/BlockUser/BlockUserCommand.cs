using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoznajRzeszow.Application.Commands.Users.BlockUser
{
    public class BlockUserCommand : IRequest<Unit>
    {
        public string Username { get; set; }
    }
}
