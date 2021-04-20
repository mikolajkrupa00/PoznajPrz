using PoznajRzeszow.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoznajRzeszow.Application.Commands.Users.AutheticateUser
{
    public class UserDto
    {
        public UserDto(Guid userId, string email, string username, Roles role, string token)
        {
            UserId = userId;
            Email = email;
            Username = username;
            Role = role;
            Token = token;
        }

        public Guid UserId { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public Roles Role { get; set; }
        public string Token { get; set; }
    }
}
