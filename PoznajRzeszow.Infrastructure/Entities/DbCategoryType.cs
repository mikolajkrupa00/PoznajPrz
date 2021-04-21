using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoznajRzeszow.Infrastructure.Entities
{
    public class DbCategoryType
    {
        public DbCategoryType()
        {
            Categories = new HashSet<DbPlaceCategory>();
        }

        public Guid CategoryTypeId { get; set; }
        public string Name { get; set; }
        public virtual ICollection<DbPlaceCategory> Categories { get; set; }
    }
}
