using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoznajRzeszow.Application.Queries.Ratings.GetRatedPlaces
{

    public class RatedPlacesDto
    {
        public RatedPlacesDto(Guid placeId, string name, string address, string directoryPath, string comment, int value)
        {
            PlaceId = placeId;
            Name = name;
            Address = address;
            DirectoryPath = directoryPath;
            Comment = comment;
            Value = value;
        }

        public Guid PlaceId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string DirectoryPath { get; set; }
        public string Comment { get; set; }
        public int Value { get; set; }
    }
}