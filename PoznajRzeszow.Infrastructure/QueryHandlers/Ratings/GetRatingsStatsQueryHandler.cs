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
            => await (from p in _context.Places
                      join r in (from rating in _context.Ratings
                                 where rating.RatingDate > DateTime.UtcNow.AddDays(-request.Days)
                                 group rating by rating.PlaceId into r
                                 select new { 
                                     r.Key, 
                                     NumOfComments = r.Count(), 
                                     Average = r.Average(val => val.Value) 
                                 })
                      on p.PlaceId equals r.Key

                      join v in (from visit in _context.Visits
                                 where visit.VisitDate > DateTime.UtcNow.AddDays(-request.Days)
                                 group visit by visit.PlaceId into v
                                 select new {
                                     v.Key,
                                     NumOfVisits = v.Count() 
                                 }) 
                      on p.PlaceId equals v.Key
                      
                      
                      select new RatingStatsDto(p.PlaceId, r.NumOfComments, r.Average, v.NumOfVisits, p.Name, p.Address, p.Description))
            .ToListAsync();
    }
}