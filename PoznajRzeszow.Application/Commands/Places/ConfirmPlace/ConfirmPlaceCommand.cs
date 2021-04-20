using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoznajRzeszow.Application.Commands.Places.ConfirmPlace
{
    public class ConfirmPlaceCommand : IRequest<Unit>
    {
        public Guid PlaceId { get; set; }
    }
}
