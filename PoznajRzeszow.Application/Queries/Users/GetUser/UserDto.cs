using PoznajRzeszow.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoznajRzeszow.Application.Queries.Users.GetUser
{
    public class UserDto
    {
        public UserDto(Guid userId, string email, string username, Roles role)
        {
            UserId = userId;
            Email = email;
            Username = username;
            Role = role;
        }

        public Guid UserId { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public Roles Role { get; set; }
    }
}
