using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoznajRzeszow.Application.Queries.Visits.GetVisitedPlaces
{
    public class GetVisitedPlacesQuery : IRequest<List<VisitedPlacesDto>>
    {
        public Guid UserId { get; set; }
        
    }
}
