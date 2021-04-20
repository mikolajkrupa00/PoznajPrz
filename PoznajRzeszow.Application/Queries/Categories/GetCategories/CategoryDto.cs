using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoznajRzeszow.Application.Queries.Categories.GetCategories
{
    public class CategoryDto
    {
        public CategoryDto(Guid categoryId, string name)
        {
            CategoryId = categoryId;
            Name = name;
        }

        public Guid CategoryId { get; set; }
        public string Name { get; set; }
    }
}
