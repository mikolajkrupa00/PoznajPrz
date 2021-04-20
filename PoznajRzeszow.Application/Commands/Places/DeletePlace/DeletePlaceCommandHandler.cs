using MediatR;
using PoznajRzeszow.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PoznajRzeszow.Application.Commands.Places.DeletePlace
{
    public class DeletePlaceCommandHandler : IRequestHandler<DeletePlaceCommand, Unit>
    {
        private readonly IPlaceRepository _placeRepository;

        public DeletePlaceCommandHandler(IPlaceRepository placeRepository)
        {
            _placeRepository = placeRepository;
        }

        public async Task<Unit> Handle(DeletePlaceCommand request, CancellationToken cancellationToken)
        {
            await _placeRepository.DeleteAsync(request.PlaceId);
            return Unit.Value;
        }
    }
}
