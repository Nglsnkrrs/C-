using Microsoft.EntityFrameworkCore;

namespace Games_DB_v3.Models
{
    public class GameContext : DbContext
    {
        public DbSet<Games> Games { get; set; }
        public DbSet<Studio> Studios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=Games.db");
        }
    }
}