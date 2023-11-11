using System.ComponentModel.DataAnnotations;

namespace UkraineSvoNews.ViewModel
{
    public class CreatePublicationViewModel
    {
        [Required(ErrorMessage = "Это поле обязательно")]
        [MinLength(10, ErrorMessage = "Минимальная длина составляет {1}")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Это поле обязательно")]
        public string Description { get; set; }
    }
}
