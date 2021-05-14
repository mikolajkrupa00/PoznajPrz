using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoznajRzeszow.Domain.Models
{
    public class Place
    {
        public Place(Guid placeId, decimal latitude, decimal longitude, string name, string description, string address, 
            Guid categoryId, bool isConfirmed, string mainPhoto)
        {
            PlaceId = placeId;
            Latitude = latitude;
            Longitude = longitude;
            Name = name;
            Description = description;
            Address = address;
            CategoryId = categoryId;
            IsConfirmed = isConfirmed;
            MainPhoto = mainPhoto;
        }

        public Guid PlaceId { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Address { get; set; }
        public Guid CategoryId { get; set; }
        public bool IsConfirmed { get; set; }
        public string FolderPath { get; set; }
        public string MainPhoto { get; set; }

        public static Place Create(decimal latitude, decimal longitude, string name, string description, string address, Guid categoryId, string mainPhoto)
            => new Place(Guid.NewGuid(), latitude, longitude, name, description, address, categoryId, false, mainPhoto);
    }
}
