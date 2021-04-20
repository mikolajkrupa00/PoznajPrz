using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoznajRzeszow.Application.Commands.Ratings.DeleteRating
{
    public class DeleteRatingCommand : IRequest<Unit>
    {
        public Guid RatingId { get; set; }
    }
}
