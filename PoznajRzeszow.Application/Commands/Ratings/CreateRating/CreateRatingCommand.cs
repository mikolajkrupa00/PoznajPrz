using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoznajRzeszow.Application.Commands.Ratings.CreateRating
{
    public class CreateRatingCommand : IRequest<RatingDto>
    {
        public DateTime RatingDate { get; set; }
        public string Comment { get; set; }
        public int Value { get; set; }
        public Guid PlaceId { get; set; }
        public Guid UserId { get; set; }
        public IFormFile File { get; set; }
    }
}