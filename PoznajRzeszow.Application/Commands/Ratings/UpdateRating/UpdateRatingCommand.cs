using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoznajRzeszow.Application.Commands.Ratings.UpdateRating
{
    public class UpdateRatingCommand : IRequest<Unit>
    {
        public Guid RatingId { get; set; }
        public string Comment { get; set; }
        public int Value { get; set; }
        public Guid UserId { get; set; }
    }
}
