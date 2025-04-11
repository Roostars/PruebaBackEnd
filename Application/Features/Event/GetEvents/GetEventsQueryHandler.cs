using Application.Interfaces;
using MediatR;

namespace Application.Features.Event.GetEvents
{
    public class GetEventsQueryHandler : IRequestHandler<GetEventsQuery, List<Domain.Entities.Event>>
    {
        private readonly IEventRepository eventRepository;

        public GetEventsQueryHandler(IEventRepository eventRepository)
        {
            this.eventRepository = eventRepository;
        }

        public async Task<List<Domain.Entities.Event>> Handle(GetEventsQuery request, CancellationToken cancellationToken)
        {
            var events = await eventRepository.GetAllEventsAsync();
            return events.ToList();
        }
    }
}