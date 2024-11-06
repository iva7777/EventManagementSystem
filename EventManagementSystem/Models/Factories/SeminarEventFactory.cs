using EventManagementSystem.Models.Entities;

namespace EventManagementSystem.Models.Factories
{
    //Concrete Factory; SeminarEventFactory създава семинари.
    public class SeminarEventFactory : EventFactory
    {
        public override Event CreateEvent(string title, DateTime date, string location)
        {
            return new Event { Title = title, Date = date, Location = location };
        }
    }
}
