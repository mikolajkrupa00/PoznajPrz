using MediatR;
using Microsoft.EntityFrameworkCore;
using PoznajRzeszow.Application.Queries.Visits.GetPlaceStats;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PoznajRzeszow.Infrastructure.QueryHandlers.Visits
{
    public class GetPlaceStatsQueryHandler : IRequestHandler<GetPlaceStatsQuery, StatsDto>
    {
        private readonly PoznajRzeszowContext _context;

        public GetPlaceStatsQueryHandler(PoznajRzeszowContext context)
        {
            _context = context;
        }

        public async Task<StatsDto> Handle(GetPlaceStatsQuery request, CancellationToken cancellationToken)
            => await (from v in _context.Visits
                      where v.VisitDate > DateTime.UtcNow.AddDays(-request.Days) && v.PlaceId == request.PlaceId
                      join p in _context.Places on v.PlaceId equals p.PlaceId into place
                      from pp in place.DefaultIfEmpty()
                      group v by new { pp.PlaceId, pp.Name } into visits
                      select new StatsDto(visits.Key.PlaceId, visits.Count(), visits.Key.Name))
            .FirstAsync();
    }
}
