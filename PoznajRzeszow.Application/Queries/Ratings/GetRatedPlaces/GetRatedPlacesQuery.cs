using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoznajRzeszow.Application.Queries.Ratings.GetRatedPlaces
{
    public class GetRatedPlacesQuery : IRequest<List<RatedPlacesDto>>
    {
        public Guid UserId { get; set; }
        
    }
}
