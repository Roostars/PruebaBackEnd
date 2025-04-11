using Domain.Entities;

namespace Application.Interfaces
{
    public interface IEventRepository
    {
        Task<Event> AddEventAsync(Event @event);
        Task<Event?> GetEventByIdAsync(string id);
        Task<IEnumerable<Event>> GetAllEventsAsync();
        Task<Event> UpdateEventAsync(Event @event);
        Task<bool> DeleteEventAsync(string id);
    }
}