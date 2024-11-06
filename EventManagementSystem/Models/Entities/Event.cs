using System.ComponentModel.DataAnnotations;

namespace EventManagementSystem.Models.Entities
{
    //Product of EventFactory; базов клас за всички видове събития. Какъв вид ще бъде събитието се определя в условна конструкция в EventService
    public class Event
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Title { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        public string Location { get; set; }

        public virtual ICollection<Participant> Participants { get; set; }

        public Event()
        {
            Participants = new List<Participant>();
        }
    }
}
