namespace UkraineSvoNews.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public List<Publication> Publications { get; set; }
    }
}
