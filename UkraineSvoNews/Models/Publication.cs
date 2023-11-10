﻿namespace UkraineSvoNews.Models
{
    public class Publication
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public User User { get; set; }
        public int UserId { get; set; }
    }
}
