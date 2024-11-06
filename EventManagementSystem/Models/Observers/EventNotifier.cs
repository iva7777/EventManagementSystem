using EventManagementSystem.Models.Entities;

namespace EventManagementSystem.Models.Observers
{
    //Subject; Поддържа списък с наблюдатели и уведомява всички тях при настъпване на събитие.
    //Този клас предоставя методи за добавяне и премахване на наблюдатели, както и метод за нотификация (NotifyObservers()).
    public class EventNotifier
    {
        private List<IObserver> _observers = new List<IObserver>();

        public void AddObserver(IObserver observer)
        {
            _observers.Add(observer);
        }

        public void RemoveObserver(IObserver observer)
        {
            _observers.Remove(observer);
        }

        public void NotifyObservers(Event e)
        {
            foreach (var observer in _observers)
            {
                observer.Update(e);
            }
        }
    }
}
