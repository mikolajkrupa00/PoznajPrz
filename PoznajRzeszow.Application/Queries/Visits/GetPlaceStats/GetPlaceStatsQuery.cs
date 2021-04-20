using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoznajRzeszow.Application.Queries.Visits.GetPlaceStats
{
    public class GetPlaceStatsQuery : IRequest<StatsDto>
    {
        public Guid PlaceId { get; set; }
        public int Days { get; set; }
    }
}
