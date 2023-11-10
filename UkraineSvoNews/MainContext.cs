using Microsoft.EntityFrameworkCore;
using UkraineSvoNews.Models;

namespace UkraineSvoNews
{
    public class MainContext : DbContext
    {
        public MainContext(DbContextOptions<MainContext> options)
            : base(options)
        {
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Publication> Publications { get; set; }
    }
}
