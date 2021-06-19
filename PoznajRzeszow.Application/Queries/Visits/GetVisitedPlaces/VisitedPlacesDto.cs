using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoznajRzeszow.Application.Queries.Visits.GetVisitedPlaces
{

    public class VisitedPlacesDto
    {
        public VisitedPlacesDto(Guid placeId, string name, string address,string directoryPath)
        {
            PlaceId = placeId;
            Name = name;
            Address = address;
            DirectoryPath = directoryPath;
        }

        public Guid PlaceId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string DirectoryPath { get; set; }
    }
}