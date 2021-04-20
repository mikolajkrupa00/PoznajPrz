using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoznajRzeszow.Application.Commands.Visits.CreateVisit
{
    public class CreateVisitCommand : IRequest<VisitDto>
    {
        public Guid UserId { get; set; }
        public Guid PlaceId { get; set; }
        public DateTime VisitDate { get; set; }
    }
}
