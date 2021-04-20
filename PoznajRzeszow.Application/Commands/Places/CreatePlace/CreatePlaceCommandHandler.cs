using MediatR;
using PoznajRzeszow.Domain.Interfaces.Repositories;
using PoznajRzeszow.Domain.Models;
using System;
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
            var place = Place.Create(request.Latitude, request.Attitude, request.Name, request.Description, request.Address, request.CategoryId);
            await _placeRepository.CreateAsync(place);
            return new PlaceDto(place.PlaceId);
        }
    }
}
