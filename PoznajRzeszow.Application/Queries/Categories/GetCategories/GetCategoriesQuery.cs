using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoznajRzeszow.Application.Queries.Categories.GetCategories
{
    public class GetCategoriesQuery : IRequest<List<CategoryDto>>
    {
    }
}
