using MediatR;
using PoznajRzeszow.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PoznajRzeszow.Application.Commands.Ratings.UpdateRating
{
    public class UpdateRatingCommandHandler : IRequestHandler<UpdateRatingCommand, Unit>
    {
        private readonly IRatingRepository _ratingRepository;

        public UpdateRatingCommandHandler(IRatingRepository ratingRepository)
        {
            _ratingRepository = ratingRepository;
        }

        public async Task<Unit> Handle(UpdateRatingCommand request, CancellationToken cancellationToken)
        {
            var rating = await _ratingRepository.GetAsync(request.RatingId);
            rating.Comment = request.Comment;
            rating.Value = request.Value;
            await _ratingRepository.UpdateAsync(rating);
            return Unit.Value;
        }
    }
}
