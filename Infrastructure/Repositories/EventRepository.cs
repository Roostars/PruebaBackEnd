using Application.Interfaces;
using Domain.Entities;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class EventRepository : IEventRepository
    {
        private readonly AppDbContext context;

        public EventRepository(AppDbContext context)
        {
            this.context = context;
        }

        public async Task<Event> AddEventAsync(Event @event)
        {
            context.Events.Add(@event);
            await context.SaveChangesAsync();
            return @event;
        }

        public async Task<bool> DeleteEventAsync(string id)
        {
            var @event = await context.Events.FindAsync(id);
            if (@event == null)
            {
                return false;
            }

            context.Events.Remove(@event);
            return context.SaveChanges() > 0;
        }

        public async Task<IEnumerable<Event>> GetAllEventsAsync()
        {
            return await context.Events.ToListAsync();
        }

        public async Task<Event?> GetEventByIdAsync(string id)
        {
            return await context.Events.FindAsync(id);
        }

        public async Task<Event> UpdateEventAsync(Event @event)
        {
            var existingEvent = await context.Events.FindAsync(@event.Id);
            if (existingEvent == null)
            {
                throw new KeyNotFoundException($"Event with ID {@event.Id} not found.");
            }

            context.Entry(existingEvent).CurrentValues.SetValues(@event);
            await context.SaveChangesAsync();
            return existingEvent;
        }
    }
}