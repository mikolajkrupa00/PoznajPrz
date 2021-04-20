using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoznajRzeszow.Application.Commands.Visits.CreateVisit
{
    public class VisitDto
    {
        public VisitDto(Guid visitId)
        {
            VisitId = visitId;
        }

        public Guid VisitId { get; set; }
    }
}
