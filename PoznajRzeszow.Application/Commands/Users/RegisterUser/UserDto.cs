using PoznajRzeszow.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoznajRzeszow.Application.Commands.Users.RegisterUser
{
    public class UserDto
    {
        public UserDto(Guid userId, string username, string token, Roles role)
        {
            UserId = userId;
            Username = username;
            Token = token;
            Role = role;
        }

        public Guid UserId { get; set; }
        public string Username { get; set; }
        public string Token { get; set; }
        public Roles Role { get; set; }
    }
}
