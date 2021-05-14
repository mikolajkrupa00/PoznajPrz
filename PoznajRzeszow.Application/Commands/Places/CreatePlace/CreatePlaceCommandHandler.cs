using MediatR;
using PoznajRzeszow.Domain.Interfaces.Repositories;
using PoznajRzeszow.Domain.Models;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PoznajRzeszow.Application.Commands.Places.CreatePlace
{
    class CreatePlaceCommandHandler : IRequestHandler<CreatePlaceCommand, PlaceDto>
    {
        private readonly IPlaceRepository _placeRepository;

        public CreatePlaceCommandHandler(IPlaceRepository placeRepository)
        {
            _placeRepository = placeRepository;
        }

        public async Task<PlaceDto> Handle(CreatePlaceCommand request, CancellationToken cancellationToken)
        {
            //creates new random ID for new place
            Guid placeID = Guid.NewGuid();

            //creates directory for new place to store images
            System.IO.Directory.CreateDirectory(@"../../Frontend/public/img/places/"+ placeID);

            string folderPath = "img/places/" + placeID;
            //save photos to already created direcotry
            if (request.Files != null)
            {
                int a = 140;
            }

            var place = Place.Create(request.Latitude, request.Longitude, request.Name, request.Description, request.Address, 
                                     request.CategoryId, request.MainPhoto);
            await _placeRepository.CreateAsync(place);
            //return new PlaceDto(place.PlaceId);
            return new PlaceDto(placeID);
        }
    }
}
