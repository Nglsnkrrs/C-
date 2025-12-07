using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;

namespace Games_DB.Models
{
    public class GameContext : DbContext
    {
        public DbSet<Games> Games { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                string dbPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data", "Games.mdf");
                Directory.CreateDirectory(Path.GetDirectoryName(dbPath));

                string connectionString = $@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename={dbPath};Initial Catalog=GamesDB;Integrated Security=True;Connect Timeout=30;";


                optionsBuilder.UseSqlServer(connectionString);

            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Games>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Studio)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.PlayingStyle)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.GameMode)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasDefaultValue("Singleplayer");

                entity.Property(e => e.CopiesSold)
                    .IsRequired()
                    .HasDefaultValue(0);
            });
        }
    }
}