using MediatR;
using Microsoft.EntityFrameworkCore;
using PoznajRzeszow.Application.Queries.Users.GetUser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PoznajRzeszow.Infrastructure.QueryHandlers.Users
{
    public class GetUserQueryHandler : IRequestHandler<GetUserQuery, UserDto>
    {
        public readonly PoznajRzeszowContext _context;

        public GetUserQueryHandler(PoznajRzeszowContext context)
        {
            _context = context;
        }

        public async Task<UserDto> Handle(GetUserQuery request, CancellationToken cancellationToken)
        {
            var user =  await (from u in _context.Users
                          where u.UserId == request.UserId
                          select new UserDto(u.UserId, u.Email, u.Username, u.Role)).FirstAsync();
            return user;
        }
    }
}
