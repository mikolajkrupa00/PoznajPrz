using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoznajRzeszow.Application.Queries.Ratings.GetRatings
{
    public class GetRatingsQuery : IRequest<List<RatingDto>>
    {
        public Guid PlaceId { get; set; }
    }
}
