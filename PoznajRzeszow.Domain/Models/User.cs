using PoznajRzeszow.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoznajRzeszow.Domain.Models
{
    public class User
    {
        public User(Guid userId, string email, string username, string password, string salt, Roles role)
        {
            UserId = userId;
            Email = email;
            Username = username;
            Password = password;
            Salt = salt;
            Role = role;
        }

        public Guid UserId { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Salt { get; set; }
        public Roles Role { get; set; }

        public static User Create(string email, string username, string password, string salt, Roles role)
            => new User(Guid.NewGuid(), email, username, password, salt, role);
    }
}
