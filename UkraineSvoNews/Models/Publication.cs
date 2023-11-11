using System.ComponentModel.DataAnnotations;

namespace UkraineSvoNews.Models
{
    public class Publication
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Это поле обязательно")]
        [MinLength(10, ErrorMessage = "Минимальная длина составляет {1}")]
        public string Title { get; set; }
        [Required(ErrorMessage ="Это поле обязательно")]
        public string Description { get; set; }
        public User User { get; set; }
        public int UserId { get; set; }
    }
}
