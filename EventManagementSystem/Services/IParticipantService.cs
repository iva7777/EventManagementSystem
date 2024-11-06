using EventManagementSystem.Models.Entities;
using EventManagementSystem.Models.ViewModels;

namespace EventManagementSystem.Services
{
    /*
     Когато използваме интерфейси за дефиниране на абстракция (например IEventService), контролерите или други класове, 
    които зависят от този сървис, работят директно с интерфейса, а не с конкретната имплементация. 
    Това намалява зависимостта от конкретна имплементация и улеснява подмяната на сървиса при 
    необходимост от нова логика или промени.
     */
    public interface IParticipantService
    {
        Task<Participant> CreateParticipantAsync(ParticipantViewModel participantVM);
        Task<Participant> GetParticipantDetailsAsync(int id);
        Task<List<Participant>> GetAllParticipantsAsync();
        Task<List<Event>> GetAllEventsAsync();
        Task<bool> UpdateParticipantAsync(int id, ParticipantViewModel participantVM);
        Task<bool> DeleteParticipantAsync(int id);
        Task<bool> ParticipantExistsAsync(int id);
    }
}
