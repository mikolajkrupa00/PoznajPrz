using MediatR;
using Microsoft.EntityFrameworkCore;
using PoznajRzeszow.Application.Queries.Visits.GetVisitedPlaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PoznajRzeszow.Infrastructure.QueryHandlers.Visits
{
    public class GetVisitedPlacesQueryHandler : IRequestHandler<GetVisitedPlacesQuery, List<VisitedPlacesDto>>
    {
        private readonly PoznajRzeszowContext _context;

        public GetVisitedPlacesQueryHandler(PoznajRzeszowContext context)
        {
            _context = context;
        }

        public async Task<List<VisitedPlacesDto>> Handle(GetVisitedPlacesQuery request, CancellationToken cancellationToken)
            => await (from v in _context.Visits
                      where v.VisitedById == request.UserId
                      join p in _context.Places on v.PlaceId equals p.PlaceId into place
                      from pp in place.DefaultIfEmpty()
                      select new VisitedPlacesDto(pp.PlaceId, pp.Name, pp.Address, pp.DirectoryPath))
            .ToListAsync();
    }
}
