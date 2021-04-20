using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoznajRzeszow.Application.Commands.Ratings.CreateRating
{
    public class RatingDto
    {
        public RatingDto(Guid ratingId)
        {
            RatingId = ratingId;
        }

        public Guid RatingId { get; set; }
    }
}
