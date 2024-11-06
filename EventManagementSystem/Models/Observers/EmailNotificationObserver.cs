using EventManagementSystem.Models.Entities;

namespace EventManagementSystem.Models.Observers
{
    //Concrete Observer; Реализира IObserver и предоставя конкретни действия при получаване на нотификация.
    //EmailNotificationObserver може да изпраща имейл.
    public class EmailNotificationObserver : IObserver
    {
        public void Update(Event e)
        {
            Console.WriteLine($"Email notification sent for event: {e.Title}");
        }
    }
}
