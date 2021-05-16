using MediatR;
using Microsoft.EntityFrameworkCore;
using PoznajRzeszow.Application.Queries.Users.GetUsersList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using PoznajRzeszow.Domain.Enums;

namespace PoznajRzeszow.Infrastructure.QueryHandlers.Users
{
    public class GetUsersListQueryHandler : IRequestHandler<GetUsersListQuery, List<UsersListDto>>
    {
        public readonly PoznajRzeszowContext _context;

        public GetUsersListQueryHandler(PoznajRzeszowContext context)
        {
            _context = context;
        }

        public async Task<List<UsersListDto>> Handle(GetUsersListQuery request, CancellationToken cancellationToken)
        => await(from u in _context.Users
                  where u.Role == Roles.RestrictedUser
                 select new UsersListDto(u.UserId, u.Email, u.Username, u.Role)).ToListAsync();
    }
}
