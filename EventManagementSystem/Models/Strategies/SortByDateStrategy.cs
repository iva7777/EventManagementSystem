using EventManagementSystem.Models.Entities;

namespace EventManagementSystem.Models.Strategies
{
    //ConcreteStrategy; SortByDateStrategy реализира ISortingStrategy и предоставя логика за сортиране на събития по дата.
    //Използва се в EventController при Index endpoint-a за сортиране на събитията в табличен вид.
    public class SortByDateStrategy : ISortingStrategy
    {
        public IEnumerable<Event> Sort(IEnumerable<Event> events)
        {
            return events.OrderBy(e => e.Date);
        }
    }
}
