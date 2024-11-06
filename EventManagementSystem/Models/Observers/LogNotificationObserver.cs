using EventManagementSystem.Models.Entities;

namespace EventManagementSystem.Models.Observers
{
    //Concrete Observer; Реализира IObserver и предоставя конкретни действия при получаване на нотификация.
    //LogNotificationObserver може да записва в лог.
    public class LogNotificationObserver : IObserver
    {
        public void Update(Event e)
        {
            Console.WriteLine($"Log entry created for event: {e.Title}");
        }
    }
}
