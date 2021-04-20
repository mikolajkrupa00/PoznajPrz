using PoznajRzeszow.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoznajRzeszow.Infrastructure.Entities
{
    public class DbVisit
    {
        public Guid VisitId { get; set; }
        public DateTime VisitDate { get; set; }

        public Guid VisitedById { get; set; }
        public virtual DbUser VisitedBy { get; set; }
        public Guid PlaceId { get; set; }
        public virtual DbPlace Place { get; set; }

        public static DbVisit Create(Visit visit)
            => new DbVisit
            {
                VisitId = visit.VisitId,
                VisitDate = visit.VisitDate,
                VisitedById = visit.VisitedById,
                PlaceId = visit.PlaceId
            };
    }
}
