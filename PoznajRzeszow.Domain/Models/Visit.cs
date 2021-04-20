using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoznajRzeszow.Domain.Models
{
    public class Visit
    {
        public Visit(Guid visitId, DateTime visitDate, Guid visitedById, Guid placeId)
        {
            VisitId = visitId;
            VisitDate = visitDate;
            VisitedById = visitedById;
            PlaceId = placeId;
        }

        public Guid VisitId { get; set; }
        public DateTime VisitDate { get; set; }
        public Guid VisitedById { get; set; }
        public Guid PlaceId { get; set; }

        public static Visit Create(DateTime visitDate, Guid visitedById, Guid placeId)
            => new Visit(Guid.NewGuid(), visitDate, visitedById, placeId);
    }
}
