using System.ComponentModel.DataAnnotations;

namespace EventManagementSystem.Models.ViewModels
{
    /*
     View Models предоставят допълнителен слой между потребителския интерфейс и домейн логиката,
    който позволява по-добър контрол, повишава сигурността и прави кода по-модулен и лесен за поддръжка.
    */
    public class EventViewModel
    {
        [Required]
        [StringLength(100)]
        public string Title { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        public string Location { get; set; }

        public string EventType { get; set; }
    }
}
