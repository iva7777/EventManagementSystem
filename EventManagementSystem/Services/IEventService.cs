using EventManagementSystem.Models.Entities;
using EventManagementSystem.Models.Observers;

namespace EventManagementSystem.Services
{
    /*Прехвърлянето на бизнес логиката към сървиси прави архитектурата на приложението по-структурирана и гъвкава, 
     * осигурява по-лесна поддръжка и тестируемост, както и по-добро разделение на отговорностите. 
     * Това е подход, който спомага за разработката на по-надеждни и мащабируеми приложения.*/
    public interface IEventService
    {
        List<Event> GetEventsSortedByTitle();
        List<Event> GetEventsSortedByDate();
        void AddObserver(IObserver observer);
        void RemoveObserver(IObserver observer);
        Task<Event> CreateEventAsync(string eventType, string title, DateTime date, string location);
        Task<Event> GetEventDetailsAsync(int id);
        Task<List<Participant>> GetAllParticipantsAsync();
        Task<Event> UpdateEventAsync(int id, Event e, List<int> participantIds);
        Task<bool> DeleteEventAsync(int id);
        Task<bool> EventExistsAsync(int id);
    }
}
