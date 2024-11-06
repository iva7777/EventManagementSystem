namespace EventManagementSystem.Models.Entities
{
    //Concrete Product of IParticipantFactory; наследява базовия Participant.
    public class AttendeeParticipant : Participant
    {
        public AttendeeParticipant()
        {
            Role = "Attendee";
        }
    }
}
