using Games_DB.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace Games_DB
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine();

            try
            {
                Console.WriteLine("\n1. Создание/обновление базы данных...");

                using (var context = new GameContext())
                {
                    bool created = context.Database.EnsureCreated();
                    Console.WriteLine($"База данных {(created ? "создана" : "уже существует")}");

                }

                Console.WriteLine("\n2. Добавление игр в базу данных...");

                using (var context = new GameContext())
                {
                    

                    var games = new[]
                    {
                        new Games
                        {
                            Name = "The Witcher 3: Wild Hunt",
                            Studio = "CD Projekt Red",
                            PlayingStyle = "RPG",
                            GameMode = "Singleplayer",
                            CopiesSold = 50000000,
                            DateRealise = new DateTime(2015, 5, 19)
                        },
                        new Games
                        {
                            Name = "Cyberpunk 2077",
                            Studio = "CD Projekt Red",
                            PlayingStyle = "RPG",
                            GameMode = "Singleplayer",
                            CopiesSold = 25000000,
                            DateRealise = new DateTime(2020, 12, 10)
                        },
                        new Games
                        {
                            Name = "Minecraft",
                            Studio = "Mojang Studios",
                            PlayingStyle = "Sandbox",
                            GameMode = "Multiplayer",
                            CopiesSold = 300000000,
                            DateRealise = new DateTime(2011, 11, 18)
                        },
                        new Games
                        {
                            Name = "Counter-Strike 2",
                            Studio = "Valve",
                            PlayingStyle = "FPS",
                            GameMode = "Multiplayer",
                            CopiesSold = 0,
                            DateRealise = new DateTime(2023, 9, 27)
                        }
                    };

                    context.AddRange(games);
                    context.SaveChanges();
                    Console.WriteLine($"{games.Length} игр добавлено в базу данных!");
                }

                Console.WriteLine("\n3. Список всех игр в базе данных:");
                using (var context = new GameContext())
                {
                    var games = context.Games.OrderBy(g => g.Id).ToList();

                    if (games.Any())
                    {
                        Console.WriteLine($"\nВсего игр в базе: {games.Count}");
                        Console.WriteLine(new string('-', 130));
                        Console.WriteLine($"| {"ID",3} | {"Название",25} | {"Студия",18} | {"Стиль",10} | {"Режим",15} | {"Продано",12} | {"Дата выхода",12} |");
                        Console.WriteLine(new string('-', 130));

                        foreach (var game in games)
                        {
                            Console.WriteLine($"| {game.Id,3} | {game.Name,25} | {game.Studio,18} | {game.PlayingStyle,10} | {game.GameMode,15} | {game.CopiesSold,12:N0} | {game.DateRealise:yyyy-MM-dd} |");
                        }
                        Console.WriteLine(new string('-', 130));
                    }
                    else
                    {
                        Console.WriteLine("В базе данных нет игр.");
                    }
                }


                Console.WriteLine("\n4. Статистика по играм:");
                using (var context = new GameContext())
                {
                    var totalCopiesSold = context.Games.Sum(g => g.CopiesSold);
                    var singleplayerCount = context.Games.Count(g => g.GameMode == "Singleplayer");
                    var multiplayerCount = context.Games.Count(g => g.GameMode == "Multiplayer");

                    Console.WriteLine($"Всего продано копий: {totalCopiesSold:N0}");
                    Console.WriteLine($"Однопользовательских игр: {singleplayerCount}");
                    Console.WriteLine($"Многопользовательских игр: {multiplayerCount}");
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }

            Console.WriteLine("\nНажмите любую клавишу для выхода...");
            Console.ReadKey();
        }
    }
}