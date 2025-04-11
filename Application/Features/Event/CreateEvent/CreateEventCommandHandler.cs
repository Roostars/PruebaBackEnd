using Application.Interfaces;
using MediatR;

namespace Application.Features.Event.CreateEvent
{
    public class CreateEventCommandHandler : IRequestHandler<CreateEventCommand, string>
    {
        private readonly IEventRepository eventRepository;

        public CreateEventCommandHandler(IEventRepository eventRepository)
        {
            this.eventRepository = eventRepository;
        }

        public async Task<string> Handle(CreateEventCommand request, CancellationToken cancellationToken)
        {
            var eventEntity = new Domain.Entities.Event
            {
                Title = request.Title,                
                Start = request.Start,
                End = request.End,
                Type = request.Type,
                Description = request.Description,
            };

            eventEntity = await eventRepository.AddEventAsync(eventEntity);

            return eventEntity.Id;
        }
    }
}