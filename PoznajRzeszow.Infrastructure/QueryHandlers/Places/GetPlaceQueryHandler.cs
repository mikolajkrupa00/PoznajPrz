using MediatR;
using PoznajRzeszow.Application.Queries.Places.GetPlace;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace PoznajRzeszow.Infrastructure.QueryHandlers.Places
{
    public class GetPlaceQueryHandler : IRequestHandler<GetPlaceQuery, PlaceDto>
    {
        private readonly PoznajRzeszowContext _context;

        public GetPlaceQueryHandler(PoznajRzeszowContext context)
        {
            _context = context;
        }

        public async Task<PlaceDto> Handle(GetPlaceQuery request, CancellationToken cancellationToken)
            => await (from p in _context.Places
                      join c in _context.Categories on p.CategoryId equals c.PlaceCategoryId
                      where p.PlaceId == request.PlaceId
                      select new PlaceDto(p.PlaceId, p.Latitude, p.Attitude, p.Name, p.Description,
                      p.Address, c.Name, p.Zoom))
            .FirstAsync();
    }
}
