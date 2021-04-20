using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoznajRzeszow.Domain.Models
{
    public class Place
    {
        public Place(Guid placeId, decimal latitude, decimal attitude, string name, string description, string address, Guid categoryId, bool isConfirmed)
        {
            PlaceId = placeId;
            Latitude = latitude;
            Attitude = attitude;
            Name = name;
            Description = description;
            Address = address;
            CategoryId = categoryId;
            IsConfirmed = isConfirmed;
        }

        public Guid PlaceId { get; set; }
        public decimal Latitude { get; set; }
        public decimal Attitude { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Address { get; set; }
        public Guid CategoryId { get; set; }
        public bool IsConfirmed { get; set; }

        public static Place Create(decimal latitude, decimal attitude, string name, string description, string address, Guid categoryId)
            => new Place(Guid.NewGuid(), latitude, attitude, name, description, address, categoryId, false);
    }
}
