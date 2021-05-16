using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoznajRzeszow.Application.Queries.Ratings.GetRatingsStats
{
    public class GetRatingsStatsQuery : IRequest<List<RatingStatsDto>>
    {
        public int Days { get; set; }
    }
}
