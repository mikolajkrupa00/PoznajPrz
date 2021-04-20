using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoznajRzeszow.Infrastructure.Entities
{
    public class DbFriend
    {
        public Guid User1Id { get; set; }
        public virtual DbUser User1 { get; set; }
        public Guid User2Id { get; set; }
        public virtual DbUser User2 { get; set; }
        public bool IsAccepted { get; set; }

        public static DbFriend Create(Guid User1Id, Guid User2Id)
            => new DbFriend
            {
                IsAccepted = false,
                User1Id = User1Id,
                User2Id = User2Id
            };
    }
}
