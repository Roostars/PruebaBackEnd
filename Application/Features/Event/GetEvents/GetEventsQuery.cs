using MediatR;

namespace Application.Features.Event.GetEvents
{
    public class GetEventsQuery : IRequest<List<Domain.Entities.Event>>
    {
        
    }
}