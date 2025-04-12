using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Interfaces;
using MediatR;

namespace Application.Features.Event.GetEventById
{
    public class GetEventByIdHandler : IRequestHandler<GetEventByIdQuery, Domain.Entities.Event?>
    {
        private readonly IEventRepository eventRepository;

        public GetEventByIdHandler(IEventRepository eventRepository)
        {
            this.eventRepository = eventRepository;
        }

        public async Task<Domain.Entities.Event?> Handle(GetEventByIdQuery request, CancellationToken cancellationToken)
        {
                       return await eventRepository.GetEventByIdAsync(request.Id);

        }
    }
}