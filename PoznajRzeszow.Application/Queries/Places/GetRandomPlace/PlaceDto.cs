using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoznajRzeszow.Application.Queries.Places.GetRandomPlace
{
    public class PlaceDto
    {
        public PlaceDto(Guid placeId, decimal latitude, decimal longitude, string name, string description, string address,
            string categoryName, int zoom, string categoryTypeName, string directoryPath, string mainPhoto)
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
            Photos = getAllFilesFromDirectory(directoryPath, PlaceId);
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

        public string[] getAllFilesFromDirectory(string path, Guid placeID)
        {

            if (Directory.Exists(@"../../Frontend/public/img/places/" + placeID) == false) return null;

            string[] files = Directory.GetFiles(@"../../Frontend/public/img/places/" + placeID);


            int index = 0;
            foreach (string file in files)
            {
                if (path != null)
                {
                    files[index] = path + "/" + Path.GetFileName(file);
                }
                else
                {
                    files[index] = null;
                }

                index += 1;
            }

            return files;
        }
    }
}
