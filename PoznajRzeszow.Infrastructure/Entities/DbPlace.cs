using PoznajRzeszow.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoznajRzeszow.Infrastructure.Entities
{
    public class DbPlace
    {
        public DbPlace()
        {
            Visits = new HashSet<DbVisit>();
            Events = new HashSet<DbEvent>();
            Ratings = new HashSet<DbRating>();
        }

        public Guid PlaceId { get; set; }
        public decimal Latitude { get; set; }
        public decimal Attitude { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Address { get; set; }
        public int Zoom { get; set; }
        public bool IsConfirmed { get; set; }

        public Guid CategoryId { get; set; }
        public virtual DbPlaceCategory Category { get; set; }
        public virtual ICollection<DbVisit> Visits { get; set; }
        public virtual ICollection<DbEvent> Events { get; set; }
        public virtual ICollection<DbRating> Ratings { get; set; }

        public static DbPlace Create(Place place)
            => new DbPlace
            {
                Address = place.Address,
                Attitude = place.Attitude,
                CategoryId = place.CategoryId,
                Description = place.Description,
                PlaceId = place.PlaceId,
                Name = place.Name,
                Latitude = place.Latitude,
                IsConfirmed = false
            };
    }
}
