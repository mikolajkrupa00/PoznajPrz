using MediatR;
using PoznajRzeszow.Domain.Interfaces.Repositories;
using PoznajRzeszow.Domain.Models;
using System;
using System.Collections.Generic;
using System.IO;
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
            string filePath = null;
            string filePathDB = null;

            if (request.File != null)
            {
                var extension = System.IO.Path.GetExtension(request.File.FileName);
                string fileName = Path.GetRandomFileName();
                filePath = Path.Combine(".\\../../Frontend/public/img/ratings\\", fileName);
                filePath = Path.ChangeExtension(filePath, extension);
                filePathDB = "img/ratings/" + Path.ChangeExtension(fileName, extension);

                System.IO.Directory.CreateDirectory(".\\../../Frontend/public/img/ratings\\");
                

                using (var stream = System.IO.File.Create(filePath))
                {
                    await request.File.CopyToAsync(stream);
                }
            }

            var rating = Rating.Create(
                request.RatingDate, request.Comment,
                request.Value, request.PlaceId,
                request.UserId, request.File != null ? filePathDB : null
            );
            await _ratingRepository.CreateAsync(rating);
            return new RatingDto(rating.RatingId);
        }
    }
}
