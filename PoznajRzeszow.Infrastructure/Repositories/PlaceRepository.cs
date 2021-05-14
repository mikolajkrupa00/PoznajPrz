using Microsoft.EntityFrameworkCore;
using PoznajRzeszow.Domain.Interfaces.Repositories;
using PoznajRzeszow.Domain.Models;
using PoznajRzeszow.Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoznajRzeszow.Infrastructure.Repositories
{
    public class PlaceRepository : IPlaceRepository
    {
        private readonly PoznajRzeszowContext _context;

        public PlaceRepository(PoznajRzeszowContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(Place place)
        {
            await _context.AddAsync(DbPlace.Create(place));
            await _context.SaveChangesAsync();
        }

        public async Task<Place> GetAsync(Guid placeId)
            => await (from p in _context.Places
                      where p.PlaceId == placeId
                      select new Place(p.PlaceId, p.Latitude, p.Longitude, p.Name, p.Description, p.Address, p.CategoryId, p.IsConfirmed, p.DirectoryPath, p.MainPhoto))
                      .FirstAsync();

        public async Task UpdateAsync(Place place)
        {
            var _place = await (from p in _context.Places
                                where p.PlaceId == place.PlaceId
                                select p).FirstAsync();
            _place.Latitude = place.Latitude;
            _place.Name = place.Name;
            _place.Address = place.Address;
            _place.Longitude = place.Longitude;
            _place.CategoryId = place.CategoryId;
            _place.IsConfirmed = place.IsConfirmed;
            _place.Description = place.Description;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid placeId)
        {
            var place = await (from p in _context.Places
                               where p.PlaceId == placeId
                               select p).FirstAsync();
            _context.Places.Remove(place);
            await _context.SaveChangesAsync();
        }
    }
}
