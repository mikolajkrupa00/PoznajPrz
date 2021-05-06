using MediatR;
using Microsoft.EntityFrameworkCore;
using PoznajRzeszow.Application.Queries.Ratings.GetRatingsStats;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PoznajRzeszow.Infrastructure.QueryHandlers.Ratings
{
    public class GetRatingsStatsQueryHandler : IRequestHandler<GetRatingsStatsQuery, List<RatingStatsDto>>
    {
        private readonly PoznajRzeszowContext _context;

        public GetRatingsStatsQueryHandler(PoznajRzeszowContext context)
        {
            _context = context;
        }

        public async Task<List<RatingStatsDto>> Handle(GetRatingsStatsQuery request, CancellationToken cancellationToken)
            => await (from r in _context.Ratings
                      where r.RatingDate > DateTime.UtcNow.AddDays(-request.Days)
                      group r by new { r.PlaceId, r.RatingDate,r.Value } into rates
                      select new RatingStatsDto(rates.Key.PlaceId, rates.Key.RatingDate, rates.Count(), rates.Average(val=>val.Value)))
            .ToListAsync();
    }
}