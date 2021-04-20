using PoznajRzeszow.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoznajRzeszow.Infrastructure.Entities
{
    public class DbPlaceCategory
    {
        public DbPlaceCategory()
        {
            Places = new HashSet<DbPlace>();
        }

        public Guid PlaceCategoryId { get; set; }
        public string Name { get; set; }
        public virtual ICollection<DbPlace> Places { get; set; }

        public static DbPlaceCategory Create(Category category)
            => new DbPlaceCategory
            {
                PlaceCategoryId = category.PlaceCategoryId,
                Name = category.Name
            };
    }
}
