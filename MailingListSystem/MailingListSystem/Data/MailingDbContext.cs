using MailingListSystem.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace MailingListSystem.Data
{
    public class MailingDbContext : DbContext
    {
        public DbSet<Subscriber> Subscribers { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Promotion> Promotions { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<SubscriberCategory> SubscriberCategories { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=mailinglist.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           
            modelBuilder.Entity<SubscriberCategory>()
                .HasKey(sc => new { sc.SubscriberId, sc.CategoryId });


            modelBuilder.Entity<Subscriber>()
                .HasOne(s => s.Country)
                .WithMany(c => c.Subscribers)
                .HasForeignKey(s => s.CountryId);

            modelBuilder.Entity<Subscriber>()
                .HasOne(s => s.City)
                .WithMany(c => c.Subscribers)
                .HasForeignKey(s => s.CityId);

            modelBuilder.Entity<City>()
                .HasOne(c => c.Country)
                .WithMany(c => c.Cities)
                .HasForeignKey(c => c.CountryId);

            modelBuilder.Entity<Promotion>()
                .HasOne(p => p.Category)
                .WithMany(c => c.Promotions)
                .HasForeignKey(p => p.CategoryId);

            modelBuilder.Entity<Promotion>()
                .HasOne(p => p.Country)
                .WithMany(c => c.Promotions)
                .HasForeignKey(p => p.CountryId);
        }
    }
}
