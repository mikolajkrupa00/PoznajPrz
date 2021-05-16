using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoznajRzeszow.Application.Queries.Users.GetUsersList
{
    public class GetUsersListQuery : IRequest<List<UsersListDto>>
    {
    }
}
