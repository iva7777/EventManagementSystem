using EventManagementSystem.Models.Entities;

namespace EventManagementSystem.Models.Factories
{
    //Concrete Factory; Реализира интерфейса IParticipantFactory, като предоставя методи за създаване на конкретни обекти като AttendeeParticipant и SpeakerParticipant.
    public class ParticipantFactory : IParticipantFactory
    {
        public Participant CreateParticipant(string name, string role)
        {
            if (role == "Speaker")
            {
                return new SpeakerParticipant { Name = name };
            }
            else
            {
                return new AttendeeParticipant { Name = name };
            }
        }
    }
}
