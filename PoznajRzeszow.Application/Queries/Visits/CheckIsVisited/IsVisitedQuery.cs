using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoznajRzeszow.Application.Queries.Visits.CheckIsVisited
{
    public class IsVisitedQuery : IRequest<IsVisitedDto>
    {
       
        public Guid PlaceId { get; set; }
        public Guid UserId { get; set; }
    }
}









