using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Interfaces;
using Domain.Enums;
using MediatR;

namespace Application.Features.Event.UpdateEvent
{
 public class UpdateEventCommand : IRequest<string>
 {
    public string Id { get; set; } = null!;
    public string? Title { get; set; }
    public DateTime Start { get; set; }
    public DateTime End { get; set; }
    public EventTypeEnum Type { get; set; }
    public string? Description { get; set; }
 }
}