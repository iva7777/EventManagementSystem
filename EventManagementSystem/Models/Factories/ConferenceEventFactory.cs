using EventManagementSystem.Models.Entities;

namespace EventManagementSystem.Models.Factories
{
    //Concrete Factory; ConferenceEventFactory създава конференции.
    public class ConferenceEventFactory : EventFactory
    {
        public override Event CreateEvent(string title, DateTime date, string location)
        {
            return new Event { Title = title, Date = date, Location = location };
        }
    }
}
