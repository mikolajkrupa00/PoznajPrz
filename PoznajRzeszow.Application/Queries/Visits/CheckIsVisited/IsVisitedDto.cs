using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoznajRzeszow.Application.Queries.Visits.CheckIsVisited
{
    public class IsVisitedDto 
    {
        public IsVisitedDto(int isVisited)
        {
            IsVisited = isVisited;
        }

        public int IsVisited { get; set; }

    }
}



