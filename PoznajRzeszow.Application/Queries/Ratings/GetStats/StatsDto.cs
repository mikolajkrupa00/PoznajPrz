using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoznajRzeszow.Application.Queries.Ratings.GetStats
{
    public class StatsDto
    {
        public StatsDto(Guid placeId, int numOfComments, double averageValue, string name, string address, string description, string directoryPath, string mainPhoto)
        {
            PlaceId = placeId;
            NumOfComments = numOfComments;
            AverageValue = averageValue;
            Name = name;
            Address = address;
            Description = description;
            DirectoryPath = directoryPath;
            MainPhoto = mainPhoto;
        }

        public Guid PlaceId { get; set; }
        public int NumOfComments { get; set; }
        public double AverageValue { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Description { get; set; }
        public string DirectoryPath { get; set; }
        public string MainPhoto { get; set; }
    }
}
