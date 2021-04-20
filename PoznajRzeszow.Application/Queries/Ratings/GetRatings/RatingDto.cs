using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoznajRzeszow.Application.Queries.Ratings.GetRatings
{
    public class RatingDto
    {
        public RatingDto(Guid ratingId, DateTime ratingDate, string comment, int value, string username, bool isVisible)
        {
            RatingId = ratingId;
            RatingDate = RatingDate;
            Comment = comment;
            Value = value;
            Username = username;
            IsVisible = isVisible;
        }

        public Guid RatingId { get; set; }
        public DateTime RatingDate { get; set; }
        public string Comment { get; set; }
        public int Value { get; set; }
        public string Username { get; set; }
        public bool IsVisible { get; set; }
    }
}
