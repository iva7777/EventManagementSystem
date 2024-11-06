using EventManagementSystem.Models.Entities;

namespace EventManagementSystem.Models.Strategies
{
    //ConcreteStrategy; SortByTitleStrategy също реализира ISortingStrategy, но сортира събитията по заглавие.
    public class SortByTitleStrategy : ISortingStrategy
    {
        public IEnumerable<Event> Sort(IEnumerable<Event> events)
        {
            return events.OrderBy(e => e.Title);
        }
    }
}
