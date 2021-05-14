using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoznajRzeszow.Application.Queries.Places.GetPlaces
{
    public class PlaceDto
    {
        public PlaceDto(Guid placeId, decimal latitude, decimal longitude, string name, string description, string address,
            string categoryName, bool haveVisited, int zoom, string categoryTypeName, string folderPath, string mainPhoto)
        {
            PlaceId = placeId;
            Latitude = latitude;
            Longitude = longitude;
            Name = name;
            Description = description;
            Address = address;
            CategoryName = categoryName;
            HaveVisited = haveVisited;
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
        public bool HaveVisited { get; set; }
        public int Zoom { get; set; }
        public string CategoryTypeName { get; set; }
        public string[] Photos { get; set; }
        public string MainPhoto { get; set; }

        public string[] getAllFilesFromFolder(string path)
        {
            string[] files = Directory.GetFiles(@"../../Frontend/public/img/places/0552796e-a453-4d8e-b1bd-c3775df62046");

            int index = 0;
            foreach (string filename in files)
            {
                files[index] = Path.GetFileName(filename);
                index += 1;
            }

            return files;
        }
    }
}
