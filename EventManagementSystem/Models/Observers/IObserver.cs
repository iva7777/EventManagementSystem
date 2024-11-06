using EventManagementSystem.Models.Entities;

namespace EventManagementSystem.Models.Observers
{
    //(Abstract) Observer; Дефинира метод за получаване на уведомления за промени в състоянието на събитията. 
    public interface IObserver
    {
        /*
         Описание: Шаблонът Observer позволява на един обект (EventNotifier) да уведомява множество наблюдатели (Observers), 
        когато настъпят промени в неговото състояние. Например, когато има промяна в събитие, EventNotifier може да изпрати 
        известие чрез EmailNotificationObserver или LogNotificationObserver.

        Причина за използване: Observer шаблонът е идеален за изпълнение на логика, която изисква известяване 
        на различни системи или модули при промяна на състоянието на основния обект (в случая събития и участници). 
        Това прави кода по-модулен и лесен за поддръжка, като добавянето на нови начини за уведомяване става лесно, 
        без да се променя основната логика.
         */

        /*
         За да уведомяваме участниците за нови събития или промени в тях.
         */

        //ConcreteObservers се използват в ParticipantService в CRUD операциите.
        void Update(Event e);
    }
}
