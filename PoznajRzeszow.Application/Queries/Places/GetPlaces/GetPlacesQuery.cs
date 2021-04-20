using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoznajRzeszow.Application.Queries.Places.GetPlaces
{
    public class GetPlacesQuery : IRequest<List<PlaceDto>>
    {
        public Guid? UserId { get; set; }
    }
}
