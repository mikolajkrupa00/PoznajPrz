using MediatR;
using PoznajRzeszow.Application.Queries.Places.GetRandomPlace;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace PoznajRzeszow.Infrastructure.QueryHandlers.Places
{
    public class GetRandomPlaceQueryHandler : IRequestHandler<GetRandomPlaceQuery, PlaceDto>
    {
        private readonly PoznajRzeszowContext _context;

        public GetRandomPlaceQueryHandler(PoznajRzeszowContext context)
        {
            _context = context;
        }

        public async Task<PlaceDto> Handle(GetRandomPlaceQuery request, CancellationToken cancellationToken)
        {
            Random rnd = new Random();
            List<PlaceDto> placeDtos = await (from p in _context.Places
                      join c in _context.Categories on p.CategoryId equals c.PlaceCategoryId
                      join ct in _context.CategoryTypes on c.CategoryTypeId equals ct.CategoryTypeId
                      select new PlaceDto(p.PlaceId, p.Latitude, p.Attitude, p.Name, p.Description,
                      p.Address, c.Name, p.Zoom, ct.Name))
            .ToListAsync();

            return placeDtos.ElementAt(rnd.Next(0, placeDtos.Count));
        }
            
    }
}
