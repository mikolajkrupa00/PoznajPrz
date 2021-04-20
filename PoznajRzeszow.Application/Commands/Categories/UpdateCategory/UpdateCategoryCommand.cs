using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoznajRzeszow.Application.Commands.Categories.UpdateCategory
{
    public class UpdateCategoryCommand : IRequest<Unit>
    {
        public Guid CategoryId { get; set; }
        public string Name { get; set; }
    }
}
