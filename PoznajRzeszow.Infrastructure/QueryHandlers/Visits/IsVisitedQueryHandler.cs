using MediatR;
using Microsoft.EntityFrameworkCore;
using PoznajRzeszow.Application.Queries.Visits.CheckIsVisited;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PoznajRzeszow.Infrastructure.QueryHandlers.Visits
{
    public class IsVisitedQueryHandler : IRequestHandler<IsVisitedQuery, IsVisitedDto>
    {

        private readonly PoznajRzeszowContext _context;

        public IsVisitedQueryHandler(PoznajRzeszowContext context)
        {
            _context = context;
        }

        public async Task<IsVisitedDto> Handle(IsVisitedQuery request, CancellationToken cancellationToken)
        {

            var count = (from v in _context.Visits
                         where v.PlaceId == request.PlaceId && v.VisitedById == request.UserId
                         select v).Count();

            return new IsVisitedDto(count);

        }
    }
}



