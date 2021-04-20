using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoznajRzeszow.Application.Queries.Visits.GetStats
{
    public class StatsDto
    {
        public StatsDto(Guid placeId, int numOfVisits, string categoryName, string address, string description)
        {
            PlaceId = placeId;
            NumOfVisits = numOfVisits;
            CategoryName = categoryName;
            Address = address;
            Description = description;
        }

        public Guid PlaceId { get; set; }
        public int NumOfVisits { get; set; }
        public string CategoryName { get; set; }
        public string Address { get; set; }
        public string Description { get; set; }
    }
}
