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

            string directoryPathDB = "img/places/" + placeID;
            string mainPhotoPathDB = "img/places/" + placeID + "/main_photo";
            string filePath;

            //save main_photo to already created direcotry
            if (request.MainPhoto != null)
            {
                var extension = System.IO.Path.GetExtension(request.MainPhoto.FileName);
                string fileName = "main_photo";
                filePath = Path.Combine(@"../../Frontend/public/img/places/" + placeID, fileName);
                filePath = Path.ChangeExtension(filePath, extension);

                using (var stream = System.IO.File.Create(filePath))
                {
                    await request.MainPhoto.CopyToAsync(stream);
                }
            }

            //save photos to already created direcotry
            if (request.Photos != null)
            {

                foreach (var photo in request.Photos)
                {
                    var extension = System.IO.Path.GetExtension(photo.FileName);
                    string fileName = Path.GetRandomFileName();     
                    filePath = Path.Combine(@"../../Frontend/public/img/places/"+ placeID, fileName);
                    filePath = Path.ChangeExtension(filePath, extension);

                    using (var stream = System.IO.File.Create(filePath))
                    {
                        await photo.CopyToAsync(stream);
                    }
                }              
                
            }

            var place = Place.Create(placeID, request.Latitude, request.Longitude, request.Name, request.Description, request.Address, 
                                     request.CategoryId, directoryPathDB, mainPhotoPathDB);
            await _placeRepository.CreateAsync(place);
            return new PlaceDto(placeID);
        }
                
    }
}
