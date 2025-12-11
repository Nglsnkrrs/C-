using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace Games_DB_Version4.Models
{
    public class GameContext : DbContext
    {
        public DbSet<Games> Games { get; set; }
        public DbSet<Studio> Studios { get; set; }

        // Представления
        public DbSet<TopStudiosByGames> TopStudiosByGames { get; set; }
        public DbSet<TopStylesByGames> TopStylesByGames { get; set; }
        public DbSet<TopStylesBySales> TopStylesBySales { get; set; }
        public DbSet<TopSingleplayerGames> TopSingleplayerGames { get; set; }
        public DbSet<TopMultiplayerGames> TopMultiplayerGames { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=Games.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Настройка представлений
            modelBuilder.Entity<TopStudiosByGames>(entity =>
            {
                entity.HasNoKey();
                entity.ToView("TopStudiosByGames");
            });

            modelBuilder.Entity<TopStylesByGames>(entity =>
            {
                entity.HasNoKey();
                entity.ToView("TopStylesByGames");
            });

            modelBuilder.Entity<TopStylesBySales>(entity =>
            {
                entity.HasNoKey();
                entity.ToView("TopStylesBySales");
            });

            modelBuilder.Entity<TopSingleplayerGames>(entity =>
            {
                entity.HasNoKey();
                entity.ToView("TopSingleplayerGames");
            });

            modelBuilder.Entity<TopMultiplayerGames>(entity =>
            {
                entity.HasNoKey();
                entity.ToView("TopMultiplayerGames");
            });
        }

        // Метод для создания представлений и процедур
        public void CreateViewsAndProcedures()
        {
            Database.ExecuteSqlRaw(@"
                -- Удаляем существующие представления
                DROP VIEW IF EXISTS TopStudiosByGames;
                DROP VIEW IF EXISTS TopStylesByGames;
                DROP VIEW IF EXISTS TopStylesBySales;
                DROP VIEW IF EXISTS TopSingleplayerGames;
                DROP VIEW IF EXISTS TopMultiplayerGames;

                -- 1. Представление: Топ-3 студий по количеству игр
                CREATE VIEW IF NOT EXISTS TopStudiosByGames AS
                SELECT 
                    s.Id,
                    s.Name AS StudioName,
                    COUNT(g.Id) AS GameCount
                FROM Studios s
                LEFT JOIN Games g ON s.Id = g.StudioId
                GROUP BY s.Id, s.Name
                ORDER BY GameCount DESC;

                -- 2. Представление: Топ-3 стилей по количеству игр
                CREATE VIEW IF NOT EXISTS TopStylesByGames AS
                SELECT 
                    PlayingStyle AS StyleName,
                    COUNT(*) AS GameCount
                FROM Games
                WHERE PlayingStyle IS NOT NULL AND PlayingStyle != ''
                GROUP BY PlayingStyle
                ORDER BY GameCount DESC;

                -- 3. Представление: Топ-3 стилей по количеству продаж
                CREATE VIEW IF NOT EXISTS TopStylesBySales AS
                SELECT 
                    PlayingStyle AS StyleName,
                    SUM(CopiesSold) AS TotalSales
                FROM Games
                WHERE PlayingStyle IS NOT NULL AND PlayingStyle != ''
                GROUP BY PlayingStyle
                ORDER BY TotalSales DESC;

                -- 4. Представление: Топ однопользовательских игр по продажам
                CREATE VIEW IF NOT EXISTS TopSingleplayerGames AS
                SELECT 
                    Id,
                    Name,
                    StudioId,
                    PlayingStyle,
                    CopiesSold,
                    GameMode,
                    DateRealise
                FROM Games
                WHERE GameMode LIKE '%Singleplayer%' 
                   OR GameMode LIKE '%Однопользователь%'
                   OR GameMode LIKE '%Single%'
                ORDER BY CopiesSold DESC;

                -- 5. Представление: Топ многопользовательских игр по продажам
                CREATE VIEW IF NOT EXISTS TopMultiplayerGames AS
                SELECT 
                    Id,
                    Name,
                    StudioId,
                    PlayingStyle,
                    CopiesSold,
                    GameMode,
                    DateRealise
                FROM Games
                WHERE GameMode LIKE '%Multiplayer%' 
                   OR GameMode LIKE '%Многопользователь%'
                   OR GameMode LIKE '%Multi%'
                ORDER BY CopiesSold DESC;
            ");
        }

        // Хранимые процедуры для удаления игр
        public int DeleteGamesWithZeroSales()
        {
            return Database.ExecuteSqlRaw("DELETE FROM Games WHERE CopiesSold = 0");
        }

        public int DeleteGamesWithSales(int salesThreshold)
        {
            return Database.ExecuteSqlRaw("DELETE FROM Games WHERE CopiesSold = {0}", salesThreshold);
        }
    }
}