using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoznajRzeszow.Domain.Models
{
    public class Friend
    {
        public Friend(Guid user1Id, Guid user2Id, bool isAccepted)
        {
            User1Id = user1Id;
            User2Id = user2Id;
            IsAccepted = isAccepted;
        }

        public Guid User1Id { get; set; }
        public Guid User2Id { get; set; }
        public bool IsAccepted { get; set; }

        public static Friend Create(Guid user1Id, Guid user2Id)
            => new Friend(user1Id, user2Id, false);
    }
}
