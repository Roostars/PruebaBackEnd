using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;

namespace Application.Features.Event.GetEventById
{
    public class GetEventByIdQuery : IRequest<Domain.Entities.Event?>
    {
        public GetEventByIdQuery(string id) 
        {
            this.Id = id;
   
        }
            public string Id { get; set; } = null!;

    }
}