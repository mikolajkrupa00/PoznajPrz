using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoznajRzeszow.Domain.Models
{
    public class Rating
    {
        public Rating(Guid ratingId, DateTime ratingDate, string comment, int value, Guid placeId, Guid userId, string filePath)
        {
            RatingId = ratingId;
            RatingDate = ratingDate;
            Comment = comment;
            Value = value;
            PlaceId = placeId;
            UserId = userId;
            FilePath = filePath;
        }

        public Guid RatingId { get; set; }
        public DateTime RatingDate { get; set; }
        public string Comment { get; set; }
        public int Value { get; set; }
        public Guid PlaceId { get; set; }
        public Guid UserId { get; set; }
        public string FilePath { get; set; }

        public static Rating Create(DateTime ratingDate, string comment, int value, Guid placeId, Guid userId, String filePath)
            => new Rating(Guid.NewGuid(), ratingDate, comment, value, placeId, userId, filePath);
    }
}
