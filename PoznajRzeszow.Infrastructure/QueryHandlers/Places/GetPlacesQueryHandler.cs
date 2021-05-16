using MediatR;
using Microsoft.EntityFrameworkCore;
using PoznajRzeszow.Application.Queries.Places.GetPlaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PoznajRzeszow.Infrastructure.QueryHandlers.Places
{
    public class GetPlacesQueryHandler : IRequestHandler<GetPlacesQuery, List<PlaceDto>>
    {
        private readonly PoznajRzeszowContext _context;

        public GetPlacesQueryHandler(PoznajRzeszowContext context)
        {
            _context = context;
        }

        public async Task<List<PlaceDto>> Handle(GetPlacesQuery request, CancellationToken cancellationToken)
            => await (from p in _context.Places
                      where p.IsConfirmed
                      join c in _context.Categories on p.CategoryId equals c.PlaceCategoryId
                      join ct in _context.CategoryTypes on c.CategoryTypeId equals ct.CategoryTypeId
                      join v in _context.Visits.Where(x => x.VisitedById == request.UserId) on p.PlaceId equals v.PlaceId into visit
                      from subv in visit.DefaultIfEmpty()
                      select new PlaceDto(p.PlaceId, Convert.ToDecimal(p.Latitude), Convert.ToDecimal(p.Longitude), p.Name, p.Description, p.Address, c.Name, 
                          subv != null, p.Zoom, ct.Name, p.DirectoryPath, p.MainPhoto))
            .ToListAsync();
    }
}
