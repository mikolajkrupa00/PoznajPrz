using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoznajRzeszow.Application.Queries.Places.GetPlace
{
    public class PlaceDto
    {
        public PlaceDto(Guid placeId, decimal latitude, decimal longitude, string name, string description, string address,
            string categoryName, int zoom, string categoryTypeName, string folderPath, string mainPhoto)
        {
            PlaceId = placeId;
            Latitude = latitude;
            Longitude = longitude;
            Name = name;
            Description = description;
            Address = address;
            CategoryName = categoryName;
            Zoom = zoom;
            CategoryTypeName = categoryTypeName;
            Photos = getAllFilesFromFolder(folderPath);
            MainPhoto = mainPhoto;
        }

        public Guid PlaceId { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Address { get; set; }
        public string CategoryName { get; set; }
        public int Zoom { get; set; }
        public string CategoryTypeName { get; set; }
        public string[] Photos { get; set; }
        public string MainPhoto { get; set; }

        public string[] getAllFilesFromFolder(string path)
        {
            string[] files = { "sample1.jpg", "sample2.jpg", "sample3.jpg" };

            return files;
        }
    }
}
