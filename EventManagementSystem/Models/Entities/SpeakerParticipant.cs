namespace EventManagementSystem.Models.Entities
{
    //Concrete Product of IParticipantFactory; наследява базовия Participant.
    public class SpeakerParticipant : Participant
    {
        public SpeakerParticipant()
        {
            Role = "Speaker";
        }
    }
}
