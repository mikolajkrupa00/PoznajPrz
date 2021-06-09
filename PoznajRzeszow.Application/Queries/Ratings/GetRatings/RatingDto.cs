using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoznajRzeszow.Application.Queries.Ratings.GetRatings
{
    public class RatingDto
    {
        public RatingDto(Guid ratingId, DateTime ratingDate, string comment, int value, string username, bool isVisible, string filePath)
        {
            RatingId = ratingId;
            RatingDate = ratingDate.ToString("MM/dd/yyyy HH:mm:ss");
            Comment = comment;
            Value = value;
            Username = username;
            IsVisible = isVisible;
            FilePath = filePath;
        }

        public Guid RatingId { get; set; }
        public string RatingDate { get; set; }
        public string Comment { get; set; }
        public int Value { get; set; }
        public string Username { get; set; }
        public bool IsVisible { get; set; }
        public string FilePath { get; set; }
    }
}
