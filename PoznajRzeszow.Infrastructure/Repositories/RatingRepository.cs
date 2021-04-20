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
    public class RatingRepository : IRatingRepository
    {
        private readonly PoznajRzeszowContext _context;

        public RatingRepository(PoznajRzeszowContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(Rating rating)
        {
            await _context.Ratings.AddAsync(DbRating.Create(rating));
            await _context.SaveChangesAsync();
        }
        public async Task DeleteAsync(Guid ratingId)
        {
            var rating = await (from r in _context.Ratings
                                where r.RatingId == ratingId
                                select r).FirstAsync();
            _context.Ratings.Remove(rating);
            await _context.SaveChangesAsync();
        }
        public async Task<Rating> GetAsync(Guid ratingId)
            => await (from r in _context.Ratings
                      where r.RatingId == ratingId
                      select new Rating(r.RatingId, r.RatingDate, r.Comment, r.Value, r.PlaceId, r.UserId))
            .FirstAsync();

        public async Task UpdateAsync(Rating rating)
        {
            var _rating = await (from r in _context.Ratings
                                 where r.RatingId == rating.RatingId
                                 select r).FirstAsync();
            _rating.Comment = rating.Comment;
            _rating.Value = rating.Value;
            await _context.SaveChangesAsync();
        }
    }
}
