using System;
using System.IO;
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
                string dbPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data", "Games_v2.mdf");
                string dataDirectory = Path.GetDirectoryName(dbPath);

                // Создаем папку Data, если её нет
                Directory.CreateDirectory(dataDirectory);

                // Упрощенная строка подключения без Initial Catalog
                string connectionString = $@"Data Source=(LocalDB)\MSSQLLocalDB;
                                           AttachDbFilename={dbPath};
                                           Integrated Security=True;
                                           Connect Timeout=30;";

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

                // Добавляем конфигурацию для DateRealise
                entity.Property(e => e.DateRealise)
                    .IsRequired();

                entity.Property(e => e.GameMode)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasDefaultValue("Однопользовательская");

                entity.Property(e => e.CopiesSold)
                    .IsRequired()
                    .HasDefaultValue(0);
            });
        }
    }
}