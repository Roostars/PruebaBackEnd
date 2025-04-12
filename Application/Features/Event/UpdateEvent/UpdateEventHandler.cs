using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Interfaces;
using MediatR;

namespace Application.Features.Event.UpdateEvent
{
   public class UpdateEventCommandHandler : IRequestHandler<UpdateEventCommand, string>
{
    private readonly IEventRepository eventRepository;

    public UpdateEventCommandHandler(IEventRepository eventRepository)
    {
        this.eventRepository = eventRepository;
    }

    public async Task<string> Handle(UpdateEventCommand request, CancellationToken cancellationToken)
    {
        var existingEvent = await eventRepository.GetEventByIdAsync(request.Id) ?? throw new Exception($"Evento con ID {request.Id} no encontrado.");
            existingEvent.Title = request.Title;
        existingEvent.Start = request.Start;
        existingEvent.End = request.End;
        existingEvent.Type = request.Type;
        existingEvent.Description = request.Description;

        await eventRepository.UpdateEventAsync(existingEvent);

        return existingEvent.Id;
    }
}


}