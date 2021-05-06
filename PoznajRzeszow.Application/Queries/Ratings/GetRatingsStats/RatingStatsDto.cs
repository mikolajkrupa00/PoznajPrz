using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoznajRzeszow.Application.Queries.Ratings.GetRatingsStats
{
    public class RatingStatsDto
    {
        public RatingStatsDto(Guid placeId, DateTime ratingDate, int numOfComments, double averageValue)
        {
            PlaceId = placeId;
            RatingDate = ratingDate;
            NumOfComments = numOfComments;
            AverageValue = averageValue;
        }

        public Guid PlaceId { get; set; }
        public DateTime RatingDate { get; set; }
        public int NumOfComments { get; set; }
        public double AverageValue { get; set; }
    }
}
