using PoznajRzeszow.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoznajRzeszow.Infrastructure.Entities
{
    public class DbEvent
    {
        public Guid EventId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime EventDate { get; set; }

        public virtual DbPlace Place { get; set; }
        public Guid PlaceId { get; set; }

        public static DbEvent Create(Event _event)
            => new DbEvent
            {
                Description = _event.Description,
                EventDate = _event.EventDate,
                EventId = _event.EventId,
                PlaceId = _event.PlaceId,
                Title = _event.Title
            };
    }
}
