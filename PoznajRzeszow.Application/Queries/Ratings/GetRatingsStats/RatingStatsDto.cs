using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoznajRzeszow.Application.Queries.Ratings.GetRatingsStats
{
    public class RatingStatsDto
    {
        public RatingStatsDto(Guid placeId, int numOfComments, double averageValue, int numOfVisits, string name, string address, string description)
        {
            PlaceId = placeId;
            NumOfComments = numOfComments;
            AverageValue = averageValue;
            NumOfVisits = numOfVisits;
            Name = name;
            Address = address;
            Description = description;
        }

        public Guid PlaceId { get; set; }
        public int NumOfComments { get; set; }
        public double AverageValue { get; set; }
        public int NumOfVisits { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Description { get; set; }
    }
}
