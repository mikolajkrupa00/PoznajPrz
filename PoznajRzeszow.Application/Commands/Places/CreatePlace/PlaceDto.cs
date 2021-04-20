using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoznajRzeszow.Application.Commands.Places.CreatePlace
{
    public class PlaceDto
    {
        public PlaceDto(Guid placeId)
        {
            PlaceId = placeId;
        }

        public Guid PlaceId { get; set; }
    }
}
