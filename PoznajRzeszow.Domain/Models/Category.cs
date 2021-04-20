using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoznajRzeszow.Domain.Models
{
    public class Category
    {
        public Category(Guid categoryId, string name)
        {
            PlaceCategoryId = categoryId;
            Name = name;
        }

        public Guid PlaceCategoryId { get; set; }
        public string Name { get; set; }

        public static Category Create(string name)
            => new Category(Guid.NewGuid(), name);
    }
}
