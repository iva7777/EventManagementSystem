using EventManagementSystem.Models.Entities;

namespace EventManagementSystem.Models.Observers
{
    //Concrete Observer; наблюдава промените в статуса на участници в събития и предоставя съответната логика за обработка.
    public class ParticipantObserver : IObserver
    {
        private string _email;

        public ParticipantObserver(string email)
        {
            _email = email;
        }
        public void Update(Event e)
        {
            Console.WriteLine($"Notifying {_email} about event: {e.Title}");
        }
    }
}
