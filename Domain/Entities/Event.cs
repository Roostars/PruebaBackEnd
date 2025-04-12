using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Enums;

namespace Domain.Entities
{
    public class Event
    {
        public string? Id { get; set;} = null!;
        public string? Title  { get; set; } = null!;
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public EventTypeEnum Type { get; set; }
        public string? Description { get; set; }

    }
}