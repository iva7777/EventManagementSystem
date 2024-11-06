using System.ComponentModel.DataAnnotations;

namespace EventManagementSystem.Models.ViewModels
{
    public class ParticipantViewModel
    {
        /*
         Домейн моделите обикновено съдържат логиката за бизнес процесите и директната работа с базата данни, 
        докато View Models са насочени към специфичното представяне на данни. Това разграничение прави кода 
        по-ясен и поддръжката по-лесна, тъй като всяка част на приложението има своите отговорности.
         */
        public int Id { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "Name cannot be longer than 100 characters.")]
        public string Name { get; set; }

        [Required]
        [EmailAddress(ErrorMessage = "Invalid Email Address.")]
        public string Email { get; set; }

        [Required]
        public string Role { get; set; }

        [Required(ErrorMessage = "Please select an event.")]
        public int EventId { get; set; }

        // Optional property for displaying the event title in the view
        public string? EventTitle { get; set; }
    }
}
