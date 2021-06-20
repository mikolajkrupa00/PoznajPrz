using MediatR;
using Microsoft.EntityFrameworkCore;
using PoznajRzeszow.Application.Queries.Ratings.GetStats;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PoznajRzeszow.Infrastructure.QueryHandlers.Ratings
{
    public class GetStatsQueryHandler : IRequestHandler<GetStatsQuery, List<StatsDto>>
    {
        private readonly PoznajRzeszowContext _context;

        public GetStatsQueryHandler(PoznajRzeszowContext context)
        {
            _context = context;
        }

        public async Task<List<StatsDto>> Handle(GetStatsQuery request, CancellationToken cancellationToken)
            => await (from p in _context.Places
                      join r in (from rating in _context.Ratings
                                 where rating.RatingDate > DateTime.UtcNow.AddDays(-request.Days)
                                 group rating by rating.PlaceId into r
                                 select new
                                 {
                                     r.Key,
                                     NumOfComments = r.Count(),
                                     Average = r.Average(val => val.Value)
                                 })
                      on p.PlaceId equals r.Key

                      select new StatsDto(p.PlaceId, r.NumOfComments, r.Average, p.Name, p.Address, p.Description, p.DirectoryPath, p.MainPhoto))
            .ToListAsync();
    }
}