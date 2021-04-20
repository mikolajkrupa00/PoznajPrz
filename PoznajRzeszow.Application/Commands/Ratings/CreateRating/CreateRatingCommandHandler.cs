using MediatR;
using PoznajRzeszow.Domain.Interfaces.Repositories;
using PoznajRzeszow.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PoznajRzeszow.Application.Commands.Ratings.CreateRating
{
    public class CreateRatingCommandHandler : IRequestHandler<CreateRatingCommand, RatingDto>
    {
        private readonly IRatingRepository _ratingRepository;

        public CreateRatingCommandHandler(IRatingRepository ratingRepository)
        {
            _ratingRepository = ratingRepository;
        }

        public async Task<RatingDto> Handle(CreateRatingCommand request, CancellationToken cancellationToken)
        {
            var rating = Rating.Create(request.RatingDate, request.Comment, request.Value, request.PlaceId, request.UserId);
            await _ratingRepository.CreateAsync(rating);
            return new RatingDto(rating.RatingId);
        }
    }
}
