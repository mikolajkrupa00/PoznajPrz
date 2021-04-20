using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoznajRzeszow.Application.Queries.Visits.GetStats
{
    public class GetStatsQuery : IRequest<List<StatsDto>>
    {
        public int Days { get; set; }
    }
}
