using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoznajRzeszow.Application.Queries.Visits.GetPlaceStats
{

    public class StatsDto
    {
        public StatsDto(Guid placeId, int numOfVisits, string categoryName)
        {
            PlaceId = placeId;
            NumOfVisits = numOfVisits;
            CategoryName = categoryName;
        }

        public Guid PlaceId { get; set; }
        public int NumOfVisits { get; set; }
        public string CategoryName { get; set; }
    }
}
