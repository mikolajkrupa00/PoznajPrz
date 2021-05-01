using MediatR;
using Microsoft.EntityFrameworkCore;
using PoznajRzeszow.Application.Queries.Ratings.GetRatings;
using PoznajRzeszow.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PoznajRzeszow.Infrastructure.QueryHandlers.Ratings
{
    public class GetRatingsQueryHandler : IRequestHandler<GetRatingsQuery, List<RatingDto>>
    {
        private readonly PoznajRzeszowContext _context;

        public GetRatingsQueryHandler(PoznajRzeszowContext context)
        {
            _context = context;
        }

        public async Task<List<RatingDto>> Handle(GetRatingsQuery request, CancellationToken cancellationToken)
            => await (from r in _context.Ratings
                      join u in _context.Users on r.UserId equals u.UserId
                      where r.PlaceId == request.PlaceId
                      select new RatingDto(r.RatingId, r.RatingDate, r.Comment, r.Value, u.Username, u.Role != Roles.RestrictedUser, r.FilePath))
            .ToListAsync();
    }
}