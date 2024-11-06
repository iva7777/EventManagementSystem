using EventManagementSystem.Models.Entities;

namespace EventManagementSystem.Models.Factories
{
    //Abstract Factory; Определя интерфейс за създаване на различни типове събития - Conference, Seminar.
    public abstract class EventFactory
    {
        /*
         Използваме Factory pattern за създаване на различни типове събития, напр. конференции, семинари и други.
         */
        public abstract Event CreateEvent(string title, DateTime date, string location);
    }
}
