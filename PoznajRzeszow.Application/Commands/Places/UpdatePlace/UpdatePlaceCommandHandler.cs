using MediatR;
using PoznajRzeszow.Domain.Interfaces.Repositories;
using PoznajRzeszow.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PoznajRzeszow.Application.Commands.Places.UpdatePlace
{
    public class UpdatePlaceCommandHandler : IRequestHandler<UpdatePlaceCommand, Unit>
    {
        private readonly IPlaceRepository _placeRepository;

        public UpdatePlaceCommandHandler(IPlaceRepository placeRepository)
        {
            _placeRepository = placeRepository;
        }

        public async Task<Unit> Handle(UpdatePlaceCommand request, CancellationToken cancellationToken)
        {
            var place = await _placeRepository.GetAsync(request.PlaceId);
            place.Latitude = request.Latitude;
            place.Attitude = request.Attitude;
            place.Name = request.Name;
            place.Description = request.Description;
            place.Address = request.Address;
            await _placeRepository.UpdateAsync(place);
            return Unit.Value;
        }
    }
}
