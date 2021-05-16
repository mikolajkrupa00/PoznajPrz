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

        private Guid randomID;

        public GetRandomPlaceQueryHandler(PoznajRzeszowContext context)
        {
            _context = context;
            getRandomPlaceID();           
        }

        public async Task<PlaceDto> Handle(GetRandomPlaceQuery request, CancellationToken cancellationToken)
            => await (from p in _context.Places
                      join c in _context.Categories on p.CategoryId equals c.PlaceCategoryId
                      join ct in _context.CategoryTypes on c.CategoryTypeId equals ct.CategoryTypeId
                      where p.PlaceId == randomID
                      select new PlaceDto(randomID, Convert.ToDecimal(p.Latitude), Convert.ToDecimal(p.Longitude), p.Name, p.Description,
                      p.Address, c.Name, p.Zoom, ct.Name, p.DirectoryPath, p.MainPhoto))
            .FirstAsync();       

        public void getRandomPlaceID()
        {
            Random rnd = new Random();
            List<Guid> ListID = (from p in _context.Places select p.PlaceId).ToList();
            randomID = ListID.ElementAt(rnd.Next(0, ListID.Count));            
        }  

    }
}