using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoznajRzeszow.Application.Queries.Categories.GetCategories
{
    public class CategoryDto
    {
        public CategoryDto(Guid categoryId, string name, string categoryTypeName)
        {
            CategoryId = categoryId;
            Name = name;
            CategoryTypeName = categoryTypeName;
        }

        public Guid CategoryId { get; set; }
        public string Name { get; set; }
        public string CategoryTypeName { get; set; }
    }
}
