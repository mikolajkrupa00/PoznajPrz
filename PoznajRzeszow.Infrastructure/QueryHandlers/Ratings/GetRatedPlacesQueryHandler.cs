using MediatR;
using Microsoft.EntityFrameworkCore;
using PoznajRzeszow.Application.Queries.Ratings.GetRatedPlaces;
using PoznajRzeszow.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PoznajRzeszow.Infrastructure.QueryHandlers.Ratings
{
    public class GetRatedPlacesQueryHandler : IRequestHandler<GetRatedPlacesQuery, List<RatedPlacesDto>>
    {
        private readonly PoznajRzeszowContext _context;

        public GetRatedPlacesQueryHandler(PoznajRzeszowContext context)
        {
            _context = context;
        }

        public async Task<List<RatedPlacesDto>> Handle(GetRatedPlacesQuery request, CancellationToken cancellationToken)
             => await (from r in _context.Ratings
                       where r.UserId == request.UserId
                       join p in _context.Places on r.PlaceId equals p.PlaceId into place
                       from pp in place.DefaultIfEmpty()
                       select new RatedPlacesDto(pp.PlaceId, pp.Name, pp.Address, pp.DirectoryPath, r.Comment, r.Value))
            .ToListAsync();
    }
}