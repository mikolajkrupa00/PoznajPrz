using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoznajRzeszow.Domain.Models
{
    public class CategoryType
    {
        public CategoryType( Guid categoryTypeId, string name)
        {
            Name = name;
            CategoryTypeId = categoryTypeId;
        }

        public Guid CategoryTypeId { get; set; }
        public string Name { get; set; }

        public static CategoryType Create(string name)
            => new CategoryType(Guid.NewGuid(), name);
    }
}
