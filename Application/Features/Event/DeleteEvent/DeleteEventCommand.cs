using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;

namespace Application.Features.Event.DeleteEvent
{
    public class DeleteEventCommand : IRequest<bool>
    {
        public DeleteEventCommand(string id)
        {
            Id = id;
        }

        public string Id { get; set; } = null!;
    }
}