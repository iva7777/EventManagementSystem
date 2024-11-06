using System.ComponentModel.DataAnnotations;

namespace EventManagementSystem.Models.Entities
{
    //Product of IParticipantFactory;базов клас за всички участници. Конкретни реализации като AttendeeParticipant и SpeakerParticipant наследяват този клас.
    public class Participant
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Role { get; set; }

        public int EventId { get; set; }

        public virtual Event Event { get; set; }
    }
}
