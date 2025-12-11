using System;

namespace Games_DB_Version4.Models
{
    // Представление: Топ студий по количеству игр
    public class TopStudiosByGames
    {
        public int Id { get; set; }
        public string StudioName { get; set; }
        public int GameCount { get; set; }
    }

    // Представление: Топ стилей по количеству игр
    public class TopStylesByGames
    {
        public string StyleName { get; set; }
        public int GameCount { get; set; }
    }

    // Представление: Топ стилей по количеству продаж
    public class TopStylesBySales
    {
        public string StyleName { get; set; }
        public int TotalSales { get; set; }
    }

    // Представление: Топ однопользовательских игр
    public class TopSingleplayerGames
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int StudioId { get; set; }
        public string PlayingStyle { get; set; }
        public int CopiesSold { get; set; }
        public string GameMode { get; set; }
        public DateTime DateRealise { get; set; }
    }

    // Представление: Топ многопользовательских игр
    public class TopMultiplayerGames
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int StudioId { get; set; }
        public string PlayingStyle { get; set; }
        public int CopiesSold { get; set; }
        public string GameMode { get; set; }
        public DateTime DateRealise { get; set; }
    }
}