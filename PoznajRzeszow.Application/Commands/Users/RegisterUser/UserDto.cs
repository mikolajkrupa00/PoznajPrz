using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoznajRzeszow.Application.Commands.Users.RegisterUser
{
    public class UserDto
    {
        public UserDto(Guid userId, string token)
        {
            UserId = userId;
            Token = token;
        }

        public Guid UserId { get; set; }
        public string Token { get; set; }
    }
}
