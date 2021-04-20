using PoznajRzeszow.Domain.Enums;
using PoznajRzeszow.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoznajRzeszow.Infrastructure.Entities
{
    public class DbUser
    {
        public DbUser()
        {
            Friends = new HashSet<DbFriend>();
            Visits = new HashSet<DbVisit>();
            Ratings = new HashSet<DbRating>();
            MainUserFriends = new HashSet<DbFriend>();
        }

        public Guid UserId { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Salt { get; set; }
        public Roles Role { get; set; }
        public virtual ICollection<DbFriend> MainUserFriends { get; set; }
        public virtual ICollection<DbFriend> Friends { get; set; }
        public virtual ICollection<DbVisit> Visits { get; set; }
        public virtual ICollection<DbRating> Ratings { get; set; }

        public static DbUser Create(User user)
            => new DbUser
            {
                Salt = user.Salt,
                Email = user.Email,
                Password = user.Password,
                Role = user.Role,
                UserId = user.UserId,
                Username = user.Username
            };
    }
}
