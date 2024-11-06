using EventManagementSystem.Models;
using EventManagementSystem.Models.Entities;
using EventManagementSystem.Models.Factories;
using EventManagementSystem.Models.Observers;
using EventManagementSystem.Models.Strategies;
using Microsoft.EntityFrameworkCore;

namespace EventManagementSystem.Services
{
    public class EventService : IEventService
    {
        private readonly ApplicationDbContext _context;
        private ISortingStrategy _strategy;
        private readonly EventNotifier _eventNotifier;
        private readonly EventFactory _eventFactory;

        public EventService(ApplicationDbContext context, EventNotifier eventNotifier)
        {
            _context = context;
            _eventNotifier = eventNotifier;
        }

        public List<Event> GetEventsSortedByTitle()
        {
            _strategy = new SortByTitleStrategy();
            
            return GetEvents();
        }

        public void AddObserver(IObserver observer)
        {
            _eventNotifier.AddObserver(observer);
        }

        public void RemoveObserver(IObserver observer)
        {
            _eventNotifier.RemoveObserver(observer);
        }


        public List<Event> GetEventsSortedByDate()
        {
            _strategy = new SortByDateStrategy();
            
            return GetEvents();
        }

        private List<Event> GetEvents()
        {
            var events = _context.Events.ToList();

            return _strategy.Sort(events).ToList();
        }

        public async Task<Event> CreateEventAsync(string eventType, string title, DateTime date, string location)
        {
            EventFactory factory;

            if (eventType == "Seminar")
            {
                factory = new SeminarEventFactory(); //създава се конкретна реализация на Event
            }

            else if (eventType == "Conference")
            {
                factory = new ConferenceEventFactory(); //създава се конкретна реализация на Event
            }

            else
            {
                throw new ArgumentException("Invalid event type");
            }

            var newEvent = factory.CreateEvent(title, date, location);

            _context.Events.Add(newEvent);
            await _context.SaveChangesAsync();
            _eventNotifier.NotifyObservers(newEvent);

            return newEvent;
        }


        public async Task<Event> GetEventDetailsAsync(int id)
        {
            return await _context.Events
                              .Include(e => e.Participants) // Include the participants related to the event
                              .FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task<List<Participant>> GetAllParticipantsAsync()
        {
            return await _context.Participants.ToListAsync();
        }

        public async Task<Event> UpdateEventAsync(int id, Event e, List<int> participantIds)
        {
            var existingEvent = await _context.Events.Include(e => e.Participants).FirstOrDefaultAsync(e => e.Id == id);

            if (existingEvent == null)
            {
                return null;
            }

            existingEvent.Title = e.Title;
            existingEvent.Date = e.Date;
            existingEvent.Location = e.Location;

            existingEvent.Participants.Clear();

            // Fetch the selected participants
            var selectedParticipants = await _context.Participants.Where(p => participantIds.Contains(p.Id)).ToListAsync();

            
            foreach (var participant in selectedParticipants)
            {
                existingEvent.Participants.Add(participant);
            }

            _context.Update(existingEvent);
            await _context.SaveChangesAsync();
            _eventNotifier.NotifyObservers(existingEvent);

            return existingEvent;
        }

        public async Task<bool> DeleteEventAsync(int id)
        {
            var eventToDelete = await _context.Events.Include(e => e.Participants).FirstOrDefaultAsync(e => e.Id == id);

            if (eventToDelete == null)
            {
                return false;
            }

            _context.Events.Remove(eventToDelete);
            await _context.SaveChangesAsync();
            _eventNotifier.NotifyObservers(eventToDelete);

            return true;
        }

        public async Task<bool> EventExistsAsync(int id)
        {
            return await _context.Events.AnyAsync(e => e.Id == id);
        }
    }
}
