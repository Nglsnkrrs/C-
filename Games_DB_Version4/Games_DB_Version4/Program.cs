using Games_DB_Version4.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Games_DB
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                using var context = new GameContext();
                Console.Clear();
                Console.WriteLine("=== ИГРОВАЯ БАЗА ДАННЫХ ===");
                Console.WriteLine("1. Создание/обновление базы данных");
                Console.WriteLine("2. Управление играми");
                Console.WriteLine("3. Управление студиями");
                Console.WriteLine("4. Просмотр информации");
                Console.WriteLine("5. Статистика и отчеты");
                Console.WriteLine("6. Новые отчеты (Задания 1-3)");
                Console.WriteLine("7. Выход");
                Console.Write("Выберите действие: ");

                if (!int.TryParse(Console.ReadLine(), out var choiceMain))
                {
                    Console.WriteLine("Неверный ввод!");
                    continue;
                }

                switch (choiceMain)
                {
                    case 1:
                        CreateDatabase(context);
                        Console.ReadKey();
                        break;
                    case 2:
                        ManageGamesMenu(context);
                        break;
                    case 3:
                        ManageStudiosMenu(context);
                        break;
                    case 4:
                        ViewInformationMenu(context);
                        break;
                    case 5:
                        StatisticsMenu(context);
                        break;
                    case 6:
                        NewReportsMenu(context); // Новое меню
                        break;
                    case 7:
                        Console.WriteLine("Выход из программы...");
                        return;
                    default:
                        Console.WriteLine("Неверный выбор. Попробуйте снова.");
                        break;
                }
            }
        }

        // Основные меню
        static void ManageGamesMenu(GameContext context)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("=== УПРАВЛЕНИЕ ИГРАМИ ===");
                Console.WriteLine("1. Добавить новую игру");
                Console.WriteLine("2. Изменить данные игры");
                Console.WriteLine("3. Удалить игру");
                Console.WriteLine("4. Просмотр всех игр");
                Console.WriteLine("5. Вернуться в главное меню");
                Console.Write("Выберите действие: ");

                var choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        AddGames(context);
                        Console.ReadKey();
                        break;
                    case 2:
                        UpdateGame(context);
                        Console.ReadKey();
                        break;
                    case 3:
                        DeleteGame(context);
                        Console.ReadKey();
                        break;
                    case 4:
                        ViewAllGames(context);
                        Console.ReadKey();
                        break;
                    case 5:
                        return;
                }
            }
        }

        static void ManageStudiosMenu(GameContext context)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("=== УПРАВЛЕНИЕ СТУДИЯМИ ===");
                Console.WriteLine("1. Добавить новую студию");
                Console.WriteLine("2. Изменить данные студии");
                Console.WriteLine("3. Удалить студию");
                Console.WriteLine("4. Просмотр всех студий");
                Console.WriteLine("5. Показать страны присутствия");
                Console.WriteLine("6. Показать города с филиалами");
                Console.WriteLine("7. Вернуться в главное меню");
                Console.Write("Выберите действие: ");

                var choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        AddStudio(context);
                        Console.ReadKey();
                        break;
                    case 2:
                        UpdateStudio(context);
                        Console.ReadKey();
                        break;
                    case 3:
                        DeleteStudio(context);
                        Console.ReadKey();
                        break;
                    case 4:
                        ViewAllStudios(context);
                        Console.ReadKey();
                        break;
                    case 5:
                        ShowCountries(context);
                        Console.ReadKey();
                        break;
                    case 6:
                        ShowCities(context);
                        Console.ReadKey();
                        break;
                    case 7:
                        return;
                }
            }
        }

        static void ViewInformationMenu(GameContext context)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("=== ПРОСМОТР ИНФОРМАЦИИ ===");
                Console.WriteLine("1. Показать полную информацию об игре");
                Console.WriteLine("2. Список всех игр");
                Console.WriteLine("3. Поиск игр");
                Console.WriteLine("4. Однопользовательские игры");
                Console.WriteLine("5. Многопользовательские игры");
                Console.WriteLine("6. Вернуться в главное меню");
                Console.Write("Выберите действие: ");

                var choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        ShowFullGameInfo(context);
                        Console.ReadKey();
                        break;
                    case 2:
                        ViewAllGames(context);
                        Console.ReadKey();
                        break;
                    case 3:
                        SearchGame(context);
                        Console.ReadKey();
                        break;
                    case 4:
                        SingleplayerGame(context);
                        Console.ReadKey();
                        break;
                    case 5:
                        MultiplayerGame(context);
                        Console.ReadKey();
                        break;
                    case 6:
                        return;
                }
            }
        }

        static void StatisticsMenu(GameContext context)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("=== СТАТИСТИКА И ОТЧЕТЫ ===");
                Console.WriteLine("1. Общая статистика по играм");
                Console.WriteLine("2. Статистика по продажам");
                Console.WriteLine("3. Отображение количества однопользовательских игр");
                Console.WriteLine("4. Отображение количества многопользовательских игр");
                Console.WriteLine("5. Игра с максимальными продажами по стилю");
                Console.WriteLine("6. Топ-5 самых продаваемых игр по стилю");
                Console.WriteLine("7. Топ-5 самых непродаваемых игр по стилю");
                Console.WriteLine("8. Статистика по студиям и стилям");
                Console.WriteLine("9. Вернуться в главное меню");
                Console.Write("Выберите действие: ");

                var choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        GameDtatistics(context);
                        Console.ReadKey();
                        break;
                    case 2:
                        SalesStatistics(context);
                        Console.ReadKey();
                        break;
                    case 3:
                        ShowSingleplayerCount(context);
                        Console.ReadKey();
                        break;
                    case 4:
                        ShowMultiplayerCount(context);
                        Console.ReadKey();
                        break;
                    case 5:
                        ShowMaxSoldGameByStyle(context);
                        Console.ReadKey();
                        break;
                    case 6:
                        ShowTop5SoldByStyle(context);
                        Console.ReadKey();
                        break;
                    case 7:
                        ShowBottom5SoldByStyle(context);
                        Console.ReadKey();
                        break;
                    case 8:
                        ShowStudioStyleStats(context);
                        Console.ReadKey();
                        break;
                    case 9:
                        return;
                }
            }
        }

        // Базовые функции
        static void CreateDatabase(GameContext context)
        {
            try
            {
                context.Database.EnsureCreated();

                // Создаем представления и процедуры
                context.CreateViewsAndProcedures();

                Console.WriteLine("База данных создана/обновлена");
                Console.WriteLine("Представления и процедуры созданы");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }
        }

        // Новые функции для Задания 1
        static void ShowCountries(GameContext context)
        {
            var countries = context.Studios
                .Select(s => s.Country)
                .Distinct()
                .OrderBy(c => c)
                .ToList();

            Console.WriteLine("\n=== СТРАНЫ ПРИСУТСТВИЯ СТУДИЙ ===");
            if (countries.Any())
            {
                foreach (var country in countries)
                {
                    Console.WriteLine($"- {country}");
                }
            }
            else
            {
                Console.WriteLine("Нет данных о странах");
            }
        }

        static void ShowCities(GameContext context)
        {
            var cities = context.Studios
                .Where(s => !string.IsNullOrEmpty(s.City))
                .Select(s => s.City)
                .Distinct()
                .OrderBy(c => c)
                .ToList();

            Console.WriteLine("\n=== ГОРОДА С ФИЛИАЛАМИ СТУДИЙ ===");
            if (cities.Any())
            {
                foreach (var city in cities)
                {
                    var studiosInCity = context.Studios
                        .Where(s => s.City == city)
                        .Select(s => s.Name)
                        .ToList();

                    Console.WriteLine($"\n{city}:");
                    foreach (var studio in studiosInCity)
                    {
                        Console.WriteLine($"  - {studio}");
                    }
                }
            }
            else
            {
                Console.WriteLine("Нет данных о городах");
            }
        }

        // Новые функции для Задания 2
        static void ShowSingleplayerCount(GameContext context)
        {
            var count = context.Games
                .Count(g => g.GameMode == "Singleplayer" || g.GameMode.Contains("Однопользователь"));

            Console.WriteLine($"\nКоличество однопользовательских игр: {count}");
        }

        static void ShowMultiplayerCount(GameContext context)
        {
            var count = context.Games
                .Count(g => g.GameMode == "Multiplayer" || g.GameMode.Contains("Многопользователь"));

            Console.WriteLine($"\nКоличество многопользовательских игр: {count}");
        }

        static void ShowMaxSoldGameByStyle(GameContext context)
        {
            Console.Write("Введите стиль игры: ");
            var style = Console.ReadLine();

            var game = context.Games
                .Include(g => g.Studio)
                .Where(g => g.PlayingStyle.ToLower().Contains(style.ToLower()))
                .OrderByDescending(g => g.CopiesSold)
                .FirstOrDefault();

            if (game != null)
            {
                Console.WriteLine($"\nИгра с максимальными продажами в стиле '{style}':");
                DisplayGameInfo(game);
            }
            else
            {
                Console.WriteLine($"Игр в стиле '{style}' не найдено");
            }
        }

        static void ShowTop5SoldByStyle(GameContext context)
        {
            Console.Write("Введите стиль игры: ");
            var style = Console.ReadLine();

            var games = context.Games
                .Include(g => g.Studio)
                .Where(g => g.PlayingStyle.ToLower().Contains(style.ToLower()))
                .OrderByDescending(g => g.CopiesSold)
                .Take(5)
                .ToList();

            if (games.Any())
            {
                Console.WriteLine($"\nТоп-5 самых продаваемых игр в стиле '{style}':");
                for (int i = 0; i < games.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {games[i].Name} ({games[i].Studio.Name}) - {games[i].CopiesSold:N0} копий");
                }
            }
            else
            {
                Console.WriteLine($"Игр в стиле '{style}' не найдено");
            }
        }

        static void ShowBottom5SoldByStyle(GameContext context)
        {
            Console.Write("Введите стиль игры: ");
            var style = Console.ReadLine();

            var games = context.Games
                .Include(g => g.Studio)
                .Where(g => g.PlayingStyle.ToLower().Contains(style.ToLower()))
                .OrderBy(g => g.CopiesSold)
                .Take(5)
                .ToList();

            if (games.Any())
            {
                Console.WriteLine($"\nТоп-5 самых непродаваемых игр в стиле '{style}':");
                for (int i = 0; i < games.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {games[i].Name} ({games[i].Studio.Name}) - {games[i].CopiesSold:N0} копий");
                }
            }
            else
            {
                Console.WriteLine($"Игр в стиле '{style}' не найдено");
            }
        }

        static void ShowFullGameInfo(GameContext context)
        {
            Console.Write("Введите название игры: ");
            var name = Console.ReadLine();

            var game = context.Games
                .Include(g => g.Studio)
                .FirstOrDefault(g => g.Name.ToLower().Contains(name.ToLower()));

            if (game != null)
            {
                Console.WriteLine("\n=== ПОЛНАЯ ИНФОРМАЦИЯ ОБ ИГРЕ ===");
                Console.WriteLine($"Название: {game.Name}");
                Console.WriteLine($"Студия: {game.Studio?.Name ?? "Не указана"}");
                Console.WriteLine($"Страна студии: {game.Studio?.Country ?? "Не указана"}");
                Console.WriteLine($"Город студии: {game.Studio?.City ?? "Не указана"}");
                Console.WriteLine($"Филиалы: {game.Studio?.Branches ?? "Не указаны"}");
                Console.WriteLine($"Стиль игры: {game.PlayingStyle}");
                Console.WriteLine($"Режим игры: {game.GameMode}");
                Console.WriteLine($"Продано копий: {game.CopiesSold:N0}");
                Console.WriteLine($"Дата выхода: {game.DateRealise:yyyy-MM-dd}");
            }
            else
            {
                Console.WriteLine("Игра не найдена");
            }
        }

        static void ShowStudioStyleStats(GameContext context)
        {
            var studios = context.Studios
                .Include(s => s.Games)
                .ToList();

            Console.WriteLine("\n=== СТАТИСТИКА ПО СТУДИЯМ И СТИЛЯМ ===");

            foreach (var studio in studios)
            {
                if (studio.Games != null && studio.Games.Any())
                {
                    var mostCommonStyle = studio.Games
                        .GroupBy(g => g.PlayingStyle)
                        .OrderByDescending(g => g.Count())
                        .Select(g => g.Key)
                        .FirstOrDefault();

                    Console.WriteLine($"{studio.Name}: самый частый стиль - {mostCommonStyle ?? "Не определен"}");
                }
                else
                {
                    Console.WriteLine($"{studio.Name}: нет игр в базе");
                }
            }
        }

        // Функции для Задания 3 (Управление студиями)
        static void AddStudio(GameContext context)
        {
            try
            {
                Console.Write("Название студии: ");
                var name = Console.ReadLine();

                var existingStudio = context.Studios
                    .FirstOrDefault(s => s.Name.ToLower() == name.ToLower());

                if (existingStudio != null)
                {
                    Console.WriteLine($"Студия '{name}' уже существует!");
                    return;
                }

                Console.Write("Страна: ");
                var country = Console.ReadLine();

                Console.Write("Город: ");
                var city = Console.ReadLine();

                Console.Write("Филиалы (через запятую): ");
                var branches = Console.ReadLine();

                var studio = new Studio
                {
                    Name = name,
                    Country = country,
                    City = city,
                    Branches = branches
                };

                context.Studios.Add(studio);
                context.SaveChanges();
                Console.WriteLine($"Студия '{name}' добавлена (ID: {studio.Id})");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }
        }

        static void UpdateStudio(GameContext context)
        {
            Console.Write("Введите название студии: ");
            var name = Console.ReadLine();

            var studio = context.Studios
                .FirstOrDefault(s => s.Name.ToLower().Contains(name.ToLower()));

            if (studio == null)
            {
                Console.WriteLine("Студия не найдена");
                return;
            }

            Console.WriteLine("\nТекущие данные студии:");
            DisplayStudioInfo(studio);

            Console.WriteLine("\nВведите новые данные (оставьте пустым, чтобы оставить текущее):");

            Console.Write($"Название [{studio.Name}]: ");
            var newName = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(newName))
                studio.Name = newName;

            Console.Write($"Страна [{studio.Country}]: ");
            var newCountry = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(newCountry))
                studio.Country = newCountry;

            Console.Write($"Город [{studio.City}]: ");
            var newCity = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(newCity))
                studio.City = newCity;

            Console.Write($"Филиалы [{studio.Branches}]: ");
            var newBranches = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(newBranches))
                studio.Branches = newBranches;

            try
            {
                context.SaveChanges();
                Console.WriteLine("Данные студии обновлены");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }
        }

        static void DeleteStudio(GameContext context)
        {
            Console.Write("Введите название студии: ");
            var name = Console.ReadLine();

            var studio = context.Studios
                .Include(s => s.Games)
                .FirstOrDefault(s => s.Name.ToLower().Contains(name.ToLower()));

            if (studio == null)
            {
                Console.WriteLine("Студия не найдена");
                return;
            }

            Console.WriteLine("\nИнформация о студии:");
            DisplayStudioInfo(studio);

            if (studio.Games != null && studio.Games.Any())
            {
                Console.WriteLine($"\nВнимание! У студии есть {studio.Games.Count} игр.");
                Console.WriteLine("Удаление студии также удалит все связанные игры.");
            }

            Console.Write("\nВы уверены, что хотите удалить студию? (да/нет): ");
            var confirm = Console.ReadLine().ToLower();

            if (confirm == "да" || confirm == "д")
            {
                context.Studios.Remove(studio);
                context.SaveChanges();
                Console.WriteLine("Студия удалена");
            }
            else
            {
                Console.WriteLine("Удаление отменено");
            }
        }

        static void ViewAllStudios(GameContext context)
        {
            var studios = context.Studios
                .Include(s => s.Games)
                .OrderBy(s => s.Name)
                .ToList();

            if (studios.Any())
            {
                Console.WriteLine($"\nВсего студий: {studios.Count}");
                foreach (var studio in studios)
                {
                    Console.WriteLine("=================================");
                    Console.WriteLine($"ID: {studio.Id}");
                    Console.WriteLine($"Название: {studio.Name}");
                    Console.WriteLine($"Страна: {studio.Country ?? "Не указана"}");
                    Console.WriteLine($"Город: {studio.City ?? "Не указан"}");
                    Console.WriteLine($"Филиалы: {studio.Branches ?? "Не указаны"}");
                    Console.WriteLine($"Количество игр: {studio.Games?.Count ?? 0}");
                    Console.WriteLine("=================================");
                }
            }
            else
            {
                Console.WriteLine("Студий не найдено");
            }
        }

        // Обновленные функции для игр с учетом новой структуры
        static void AddGames(GameContext context)
        {
            try
            {
                Console.Write("Название игры: ");
                var name = Console.ReadLine();

                // Выбор студии
                var studios = context.Studios.ToList();
                if (!studios.Any())
                {
                    Console.WriteLine("Сначала добавьте студии!");
                    return;
                }

                Console.WriteLine("\nДоступные студии:");
                foreach (var studio in studios)
                {
                    Console.WriteLine($"{studio.Id}. {studio.Name}");
                }

                Console.Write("Выберите ID студии: ");
                var studioId = int.Parse(Console.ReadLine());

                var selectedStudio = context.Studios.Find(studioId);
                if (selectedStudio == null)
                {
                    Console.WriteLine("Студия не найдена!");
                    return;
                }

                Console.Write("Стиль игры: ");
                var playingstyle = Console.ReadLine();

                Console.Write("Копий продано: ");
                var copies = int.Parse(Console.ReadLine());

                Console.Write("Режим игры: ");
                var gamemode = Console.ReadLine();

                Console.Write("Дата выпуска (гггг-мм-дд): ");
                var dateString = Console.ReadLine();
                var dateRealise = DateTime.Parse(dateString);

                var game = new Games
                {
                    Name = name,
                    StudioId = studioId,
                    PlayingStyle = playingstyle,
                    CopiesSold = copies,
                    GameMode = gamemode,
                    DateRealise = dateRealise
                };

                context.Games.Add(game);
                context.SaveChanges();
                Console.WriteLine($"Игра '{name}' добавлена (ID: {game.Id})");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }
        }

        static void ViewAllGames(GameContext context)
        {
            var games = context.Games
                .Include(g => g.Studio)
                .OrderBy(g => g.Name)
                .ToList();

            if (games.Any())
            {
                Console.WriteLine($"\nВсего игр: {games.Count}");
                foreach (var game in games)
                {
                    Console.WriteLine($"|ID: {game.Id} |Название: {game.Name} |Студия: {game.Studio?.Name ?? "Не указана"} | " +
                        $"Стиль: {game.PlayingStyle} |Режим: {game.GameMode} |Продано: {game.CopiesSold} |Дата выхода: {game.DateRealise:yyyy-MM-dd} |");
                }
            }
            else
            {
                Console.WriteLine("Игр не найдено");
            }
        }

        // Вспомогательные функции
        static void DisplayGameInfo(Games game)
        {
            Console.WriteLine("=================================");
            Console.WriteLine($"ID: {game.Id}");
            Console.WriteLine($"Название: {game.Name}");
            Console.WriteLine($"Студия: {game.Studio?.Name ?? "Не указана"}");
            Console.WriteLine($"Стиль: {game.PlayingStyle}");
            Console.WriteLine($"Режим: {game.GameMode}");
            Console.WriteLine($"Продано копий: {game.CopiesSold:N0}");
            Console.WriteLine($"Дата выхода: {game.DateRealise:yyyy-MM-dd}");
            Console.WriteLine("=================================");
        }

        static void DisplayStudioInfo(Studio studio)
        {
            Console.WriteLine("=================================");
            Console.WriteLine($"ID: {studio.Id}");
            Console.WriteLine($"Название: {studio.Name}");
            Console.WriteLine($"Страна: {studio.Country ?? "Не указана"}");
            Console.WriteLine($"Город: {studio.City ?? "Не указан"}");
            Console.WriteLine($"Филиалы: {studio.Branches ?? "Не указаны"}");
            Console.WriteLine("=================================");
        }

        // Обновленные функции для работы с новой структурой данных
        static void GameDtatistics(GameContext context)
        {
            var totalCopiesSold = context.Games.Sum(g => g.CopiesSold);
            var singleplayerCount = context.Games.Count(g => g.GameMode == "Singleplayer" ||
                                                           g.GameMode.Contains("Однопользователь"));
            var multiplayerCount = context.Games.Count(g => g.GameMode == "Multiplayer" ||
                                                          g.GameMode.Contains("Многопользователь"));

            Console.WriteLine($"\n=== ОБЩАЯ СТАТИСТИКА ПО ИГРАМ ===");
            Console.WriteLine($"Всего продано копий: {totalCopiesSold:N0}");
            Console.WriteLine($"Однопользовательских игр: {singleplayerCount}");
            Console.WriteLine($"Многопользовательских игр: {multiplayerCount}");
            Console.WriteLine($"Всего игр в базе: {context.Games.Count()}");
            Console.WriteLine($"Количество студий: {context.Studios.Count()}");
        }

        static void SearchGame(GameContext context)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("=== ПОИСК ИГР ===");
                Console.WriteLine("1. Поиск по названию игры");
                Console.WriteLine("2. Поиск по названию студии");
                Console.WriteLine("3. Поиск по названию студии и игры");
                Console.WriteLine("4. Поиск по стилю");
                Console.WriteLine("5. Поиск по году релиза");
                Console.WriteLine("6. Поиск по диапазону продаж");
                Console.WriteLine("7. Поиск по режиму игры");
                Console.WriteLine("8. Вернуться в главное меню");
                Console.Write("Выберите поиск: ");

                if (!int.TryParse(Console.ReadLine(), out var choice))
                {
                    Console.WriteLine("Неверный ввод. Попробуйте снова.");
                    continue;
                }

                switch (choice)
                {
                    case 1:
                        SearchByName(context);
                        Console.ReadKey();
                        break;
                    case 2:
                        SearchByStudio(context);
                        Console.ReadKey();
                        break;
                    case 3:
                        SearchByNameAndStudio(context);
                        Console.ReadKey();
                        break;
                    case 4:
                        SearchByStyle(context);
                        Console.ReadKey();
                        break;
                    case 5:
                        SearchByReleaseYear(context);
                        Console.ReadKey();
                        break;
                    case 6:
                        SearchBySalesRange(context);
                        Console.ReadKey();
                        break;
                    case 7:
                        SearchByGameMode(context);
                        Console.ReadKey();
                        break;
                    case 8:
                        return;
                    default:
                        Console.WriteLine("Неверный выбор. Попробуйте снова.");
                        break;
                }
            }
        }

        static void SearchByName(GameContext context)
        {
            Console.Write("Введите название игры (можно часть названия): ");
            var searchName = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(searchName))
            {
                Console.WriteLine("Пустой поиск.");
                return;
            }

            var results = context.Games
                .Include(g => g.Studio)
                .Where(g => g.Name.ToLower().Contains(searchName.ToLower()))
                .OrderBy(g => g.Name)
                .ToList();

            DisplaySearchResults(results, $"по названию '{searchName}'");
        }

        static void SearchByStudio(GameContext context)
        {
            Console.Write("Введите название студии (можно часть названия): ");
            var searchStudio = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(searchStudio))
            {
                Console.WriteLine("Пустой поиск.");
                return;
            }

            var results = context.Games
                .Include(g => g.Studio)
                .Where(g => g.Studio.Name.ToLower().Contains(searchStudio.ToLower()))
                .OrderBy(g => g.Studio.Name)
                .ThenBy(g => g.Name)
                .ToList();

            DisplaySearchResults(results, $"по студии '{searchStudio}'");
        }

        static void SearchByNameAndStudio(GameContext context)
        {
            Console.Write("Введите название игры (можно часть названия): ");
            var searchName = Console.ReadLine();

            Console.Write("Введите название студии (можно часть названия): ");
            var searchStudio = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(searchName) && string.IsNullOrWhiteSpace(searchStudio))
            {
                Console.WriteLine("Пустой поиск.");
                return;
            }

            var query = context.Games.Include(g => g.Studio).AsQueryable();

            if (!string.IsNullOrWhiteSpace(searchName))
            {
                query = query.Where(g => g.Name.ToLower().Contains(searchName.ToLower()));
            }

            if (!string.IsNullOrWhiteSpace(searchStudio))
            {
                query = query.Where(g => g.Studio.Name.ToLower().Contains(searchStudio.ToLower()));
            }

            var results = query
                .OrderBy(g => g.Studio.Name)
                .ThenBy(g => g.Name)
                .ToList();

            DisplaySearchResults(results, $"по названию '{searchName}' и студии '{searchStudio}'");
        }

        static void SearchByStyle(GameContext context)
        {
            Console.Write("Введите стиль игры (Action, RPG, Strategy, Adventure, etc.): ");
            var searchStyle = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(searchStyle))
            {
                Console.WriteLine("Пустой поиск.");
                return;
            }

            var results = context.Games
                .Include(g => g.Studio)
                .Where(g => g.PlayingStyle.ToLower().Contains(searchStyle.ToLower()))
                .OrderBy(g => g.PlayingStyle)
                .ThenBy(g => g.Name)
                .ToList();

            DisplaySearchResults(results, $"по стилю '{searchStyle}'");
        }

        static void SearchByReleaseYear(GameContext context)
        {
            Console.Write("Введите год релиза: ");

            if (!int.TryParse(Console.ReadLine(), out int year))
            {
                Console.WriteLine("Неверный формат года.");
                return;
            }

            var results = context.Games
                .Include(g => g.Studio)
                .Where(g => g.DateRealise.Year == year)
                .OrderBy(g => g.DateRealise)
                .ThenBy(g => g.Name)
                .ToList();

            DisplaySearchResults(results, $"по году релиза '{year}'");
        }

        static void SearchBySalesRange(GameContext context)
        {
            Console.WriteLine("Поиск по диапазону продаж:");
            Console.Write("Минимальное количество продаж: ");

            if (!int.TryParse(Console.ReadLine(), out int minSales))
            {
                Console.WriteLine("Неверный формат числа.");
                return;
            }

            Console.Write("Максимальное количество продаж (0 для поиска всех выше минимального): ");

            if (!int.TryParse(Console.ReadLine(), out int maxSales))
            {
                Console.WriteLine("Неверный формат числа.");
                return;
            }

            IQueryable<Games> query = context.Games.Include(g => g.Studio);

            if (maxSales > 0)
            {
                query = query.Where(g => g.CopiesSold >= minSales && g.CopiesSold <= maxSales);
            }
            else
            {
                query = query.Where(g => g.CopiesSold >= minSales);
            }

            var results = query
                .OrderByDescending(g => g.CopiesSold)
                .ThenBy(g => g.Name)
                .ToList();

            string searchDescription = maxSales > 0
                ? $"по диапазону продаж от {minSales:N0} до {maxSales:N0}"
                : $"по продажам от {minSales:N0} и выше";

            DisplaySearchResults(results, searchDescription);
        }

        static void SearchByGameMode(GameContext context)
        {
            Console.WriteLine("Выберите режим игры:");
            Console.WriteLine("1. Singleplayer (Однопользовательский)");
            Console.WriteLine("2. Multiplayer (Многопользовательский)");
            Console.WriteLine("3. Оба режима");
            Console.Write("Выберите вариант: ");

            if (!int.TryParse(Console.ReadLine(), out int modeChoice))
            {
                Console.WriteLine("Неверный выбор.");
                return;
            }

            IQueryable<Games> query = context.Games.Include(g => g.Studio);
            string modeDescription = "";

            switch (modeChoice)
            {
                case 1:
                    query = query.Where(g => g.GameMode.ToLower().Contains("single") ||
                                            g.GameMode.ToLower().Contains("однопользователь"));
                    modeDescription = "однопользовательские";
                    break;
                case 2:
                    query = query.Where(g => g.GameMode.ToLower().Contains("multi") ||
                                            g.GameMode.ToLower().Contains("многопользователь"));
                    modeDescription = "многопользовательские";
                    break;
                case 3:
                    modeDescription = "всех режимов";
                    break;
                default:
                    Console.WriteLine("Неверный выбор.");
                    return;
            }

            var results = query
                .OrderBy(g => g.GameMode)
                .ThenBy(g => g.Name)
                .ToList();

            DisplaySearchResults(results, $"{modeDescription} игры");
        }

        static void DisplaySearchResults(List<Games> results, string searchDescription)
        {
            if (!results.Any())
            {
                Console.WriteLine($"Игры не найдены {searchDescription}.");
                return;
            }

            Console.WriteLine($"\nНайдено игр: {results.Count} {searchDescription}");

            foreach (var game in results)
            {
                Console.WriteLine($"|ID: {game.Id} |Название: {game.Name} |Студия: {game.Studio?.Name ?? "Не указана"} | " +
                    $"Стиль: {game.PlayingStyle} |Режим: {game.GameMode} |Продано: {game.CopiesSold:N0} |Дата выхода: {game.DateRealise:yyyy-MM-dd} |");
            }
        }

        static void SingleplayerGame(GameContext context)
        {
            var singleplayerGame = context.Games
                .Include(g => g.Studio)
                .Where(g => g.GameMode == "Singleplayer" || g.GameMode.Contains("Однопользователь"))
                .OrderBy(g => g.Name)
                .ToList();

            if (singleplayerGame.Any())
            {
                Console.WriteLine($"\n=== ОДНОПОЛЬЗОВАТЕЛЬСКИЕ ИГРЫ ===");
                Console.WriteLine($"Всего однопользовательских игр в базе: {singleplayerGame.Count}");
                foreach (var game in singleplayerGame)
                {
                    Console.WriteLine($"|ID: {game.Id} |Название: {game.Name} |Студия: {game.Studio?.Name ?? "Не указана"} | " +
                        $"Стиль: {game.PlayingStyle} |Режим: {game.GameMode} |Продано: {game.CopiesSold:N0} |Дата выхода: {game.DateRealise:yyyy-MM-dd} |");
                }
            }
            else
            {
                Console.WriteLine("Однопользовательских игр не найдено.");
            }
        }

        static void MultiplayerGame(GameContext context)
        {
            var multiplayerGames = context.Games
                .Include(g => g.Studio)
                .Where(g => g.GameMode == "Multiplayer" || g.GameMode.Contains("Многопользователь"))
                .OrderBy(g => g.Name)
                .ToList();

            if (multiplayerGames.Any())
            {
                Console.WriteLine($"\n=== МНОГОПОЛЬЗОВАТЕЛЬСКИЕ ИГРЫ ===");
                Console.WriteLine($"Всего многопользовательских игр в базе: {multiplayerGames.Count}");
                foreach (var game in multiplayerGames)
                {
                    Console.WriteLine($"|ID: {game.Id} |Название: {game.Name} |Студия: {game.Studio?.Name ?? "Не указана"} | " +
                        $"Стиль: {game.PlayingStyle} |Режим: {game.GameMode} |Продано: {game.CopiesSold:N0} |Дата выхода: {game.DateRealise:yyyy-MM-dd} |");
                }
            }
            else
            {
                Console.WriteLine("Многопользовательских игр не найдено.");
            }
        }

        static void SalesStatistics(GameContext context)
        {
            Console.WriteLine("\n=== СТАТИСТИКА ПО ПРОДАЖАМ ===");

            // Игра с максимальными продажами
            var maxSoldGame = context.Games
                .Include(g => g.Studio)
                .OrderByDescending(g => g.CopiesSold)
                .FirstOrDefault();

            if (maxSoldGame != null)
            {
                Console.WriteLine($"\nИгра с максимальным количеством продаж:");
                Console.WriteLine($"Название: {maxSoldGame.Name}");
                Console.WriteLine($"Студия: {maxSoldGame.Studio?.Name ?? "Не указана"}");
                Console.WriteLine($"Продано копий: {maxSoldGame.CopiesSold:N0}");
                Console.WriteLine($"Режим игры: {maxSoldGame.GameMode}");
            }

            // Игра с минимальными продажами
            var minSoldGame = context.Games
                .Include(g => g.Studio)
                .OrderBy(g => g.CopiesSold)
                .FirstOrDefault();

            if (minSoldGame != null)
            {
                Console.WriteLine($"\nИгра с минимальным количеством продаж:");
                Console.WriteLine($"Название: {minSoldGame.Name}");
                Console.WriteLine($"Студия: {minSoldGame.Studio?.Name ?? "Не указана"}");
                Console.WriteLine($"Продано копий: {minSoldGame.CopiesSold:N0}");
                Console.WriteLine($"Режим игры: {minSoldGame.GameMode}");
            }

            // Топ-3 самых продаваемых игр
            var top3SoldGames = context.Games
                .Include(g => g.Studio)
                .OrderByDescending(g => g.CopiesSold)
                .Take(3)
                .ToList();

            if (top3SoldGames.Any())
            {
                Console.WriteLine($"\nТоп-3 самых продаваемых игр:");
                for (int i = 0; i < top3SoldGames.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {top3SoldGames[i].Name} ({top3SoldGames[i].Studio?.Name ?? "Не указана"}) - {top3SoldGames[i].CopiesSold:N0} копий");
                }
            }

            // Топ-3 самых непродаваемых игр
            var bottom3SoldGames = context.Games
                .Include(g => g.Studio)
                .OrderBy(g => g.CopiesSold)
                .Take(3)
                .ToList();

            if (bottom3SoldGames.Any())
            {
                Console.WriteLine($"\nТоп-3 самых непродаваемых игр:");
                for (int i = 0; i < bottom3SoldGames.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {bottom3SoldGames[i].Name} ({bottom3SoldGames[i].Studio?.Name ?? "Не указана"}) - {bottom3SoldGames[i].CopiesSold:N0} копий");
                }
            }

            // Средние продажи и общая статистика
            var averageSold = context.Games.Average(g => g.CopiesSold);
            var totalGames = context.Games.Count();
            var totalStudios = context.Studios.Count();

            Console.WriteLine($"\nДополнительная статистика:");
            Console.WriteLine($"Среднее количество продаж на игру: {averageSold:N0}");
            Console.WriteLine($"Всего игр в базе: {totalGames}");
            Console.WriteLine($"Всего студий в базе: {totalStudios}");

            // Статистика по студиям
            var studioStats = context.Studios
                .Include(s => s.Games)
                .Select(s => new
                {
                    s.Name,
                    GameCount = s.Games.Count,
                    TotalSales = s.Games.Sum(g => g.CopiesSold)
                })
                .OrderByDescending(s => s.TotalSales)
                .ToList();

            Console.WriteLine($"\n=== СТАТИСТИКА ПО СТУДИЯМ ===");
            foreach (var stat in studioStats)
            {
                Console.WriteLine($"{stat.Name}: {stat.GameCount} игр, продано {stat.TotalSales:N0} копий");
            }
        }

        static void UpdateGame(GameContext context)
        {
            Console.WriteLine("\n=== ИЗМЕНЕНИЕ ДАННЫХ ИГРЫ ===");

            Console.Write("Введите ID игры для изменения (или 0 для поиска по названию): ");
            var input = Console.ReadLine();

            Games gameToUpdate = null;

            if (int.TryParse(input, out int gameId) && gameId > 0)
            {
                gameToUpdate = context.Games.Include(g => g.Studio).FirstOrDefault(g => g.Id == gameId);
            }
            else
            {
                Console.Write("Введите название игры: ");
                var gameName = Console.ReadLine();

                var games = context.Games
                    .Include(g => g.Studio)
                    .Where(g => g.Name.ToLower().Contains(gameName.ToLower()))
                    .ToList();

                if (games.Count == 0)
                {
                    Console.WriteLine("Игра не найдена.");
                    return;
                }
                else if (games.Count == 1)
                {
                    gameToUpdate = games.First();
                }
                else
                {
                    Console.WriteLine("\nНайдено несколько игр:");
                    foreach (var game in games)
                    {
                        Console.WriteLine($"ID: {game.Id} | {game.Name} | Студия: {game.Studio?.Name ?? "Не указана"}");
                    }

                    Console.Write("\nВведите ID игры для изменения: ");
                    if (int.TryParse(Console.ReadLine(), out gameId))
                    {
                        gameToUpdate = context.Games.Include(g => g.Studio).FirstOrDefault(g => g.Id == gameId);
                    }
                }
            }

            if (gameToUpdate == null)
            {
                Console.WriteLine("Игра не найдена.");
                return;
            }

            Console.WriteLine("\nТекущие данные игры:");
            DisplayGameInfo(gameToUpdate);

            Console.WriteLine("\nВведите новые данные (оставьте поле пустым, чтобы оставить текущее значение):");

            Console.Write($"Название игры [{gameToUpdate.Name}]: ");
            var newName = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(newName))
                gameToUpdate.Name = newName;

            // Выбор студии
            Console.WriteLine("\nДоступные студии:");
            var studios = context.Studios.ToList();
            foreach (var studio in studios)
            {
                Console.WriteLine($"{studio.Id}. {studio.Name}");
            }
            Console.Write($"Выберите ID студии [{gameToUpdate.StudioId}] (или 0 чтобы оставить текущую): ");
            var studioInput = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(studioInput) && int.TryParse(studioInput, out int newStudioId) && newStudioId > 0)
            {
                if (context.Studios.Any(s => s.Id == newStudioId))
                    gameToUpdate.StudioId = newStudioId;
                else
                    Console.WriteLine("Студия с таким ID не найдена, оставляем текущую.");
            }

            Console.Write($"Стиль игры [{gameToUpdate.PlayingStyle}]: ");
            var newStyle = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(newStyle))
                gameToUpdate.PlayingStyle = newStyle;

            Console.Write($"Копий продано [{gameToUpdate.CopiesSold}]: ");
            var copiesInput = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(copiesInput) && int.TryParse(copiesInput, out int newCopies))
                gameToUpdate.CopiesSold = newCopies;

            Console.Write($"Режим игры [{gameToUpdate.GameMode}]: ");
            var newMode = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(newMode))
                gameToUpdate.GameMode = newMode;

            Console.WriteLine("Дата выпуска:");
            Console.Write($"Год [{gameToUpdate.DateRealise.Year}] (оставьте пустым для текущего): ");
            var yearInput = Console.ReadLine();
            int newYear = gameToUpdate.DateRealise.Year;

            Console.Write($"Месяц [{gameToUpdate.DateRealise.Month}] (оставьте пустым для текущего): ");
            var monthInput = Console.ReadLine();
            int newMonth = gameToUpdate.DateRealise.Month;

            Console.Write($"День [{gameToUpdate.DateRealise.Day}] (оставьте пустым для текущего): ");
            var dayInput = Console.ReadLine();
            int newDay = gameToUpdate.DateRealise.Day;

            if (!string.IsNullOrWhiteSpace(yearInput) ||
                !string.IsNullOrWhiteSpace(monthInput) ||
                !string.IsNullOrWhiteSpace(dayInput))
            {
                if (!string.IsNullOrWhiteSpace(yearInput) && int.TryParse(yearInput, out int parsedYear))
                    newYear = parsedYear;
                if (!string.IsNullOrWhiteSpace(monthInput) && int.TryParse(monthInput, out int parsedMonth))
                    newMonth = parsedMonth;
                if (!string.IsNullOrWhiteSpace(dayInput) && int.TryParse(dayInput, out int parsedDay))
                    newDay = parsedDay;

                try
                {
                    gameToUpdate.DateRealise = new DateTime(newYear, newMonth, newDay);
                }
                catch
                {
                    Console.WriteLine("Неверная дата, оставляем текущую.");
                }
            }

            try
            {
                context.SaveChanges();
                Console.WriteLine($"\nДанные игры '{gameToUpdate.Name}' успешно обновлены!");
                Console.WriteLine("\nОбновленные данные:");
                DisplayGameInfo(gameToUpdate);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при обновлении: {ex.Message}");
            }
        }

        static void DeleteGame(GameContext context)
        {
            Console.WriteLine("\n=== УДАЛЕНИЕ ИГРЫ ===");

            Console.Write("Введите название игры: ");
            var gameName = Console.ReadLine();

            var games = context.Games
                .Include(g => g.Studio)
                .Where(g => g.Name.ToLower().Contains(gameName.ToLower()))
                .ToList();

            if (games.Count == 0)
            {
                Console.WriteLine("Игра не найдена.");
                return;
            }

            Games gameToDelete = null;

            if (games.Count == 1)
            {
                gameToDelete = games.First();
            }
            else
            {
                Console.WriteLine("\nНайдено несколько игр:");
                foreach (var game in games)
                {
                    Console.WriteLine($"ID: {game.Id} | {game.Name} | Студия: {game.Studio?.Name ?? "Не указана"} | Продано: {game.CopiesSold:N0}");
                }

                Console.Write("\nВведите ID игры для удаления: ");
                if (int.TryParse(Console.ReadLine(), out int gameId))
                {
                    gameToDelete = context.Games.Include(g => g.Studio).FirstOrDefault(g => g.Id == gameId);
                }

                if (gameToDelete == null)
                {
                    Console.WriteLine("Игра с указанным ID не найдена.");
                    return;
                }
            }

            Console.WriteLine("\nИнформация об игре для удаления:");
            DisplayGameInfo(gameToDelete);

            Console.Write("\nВы уверены, что хотите удалить эту игру? (да/нет): ");
            var confirmation = Console.ReadLine().ToLower();

            if (confirmation == "да" || confirmation == "д" || confirmation == "yes" || confirmation == "y")
            {
                try
                {
                    context.Games.Remove(gameToDelete);
                    context.SaveChanges();
                    Console.WriteLine($"\nИгра '{gameToDelete.Name}' успешно удалена из базы данных!");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Ошибка при удалении: {ex.Message}");
                }
            }
            else
            {
                Console.WriteLine("Удаление отменено.");
            }
        }

        static void NewReportsMenu(GameContext context)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("=== НОВЫЕ ОТЧЕТЫ (ЗАДАНИЯ 1-3) ===");
                Console.WriteLine("=== ЗАДАНИЕ 1 ===");
                Console.WriteLine("1. Топ-3 студий с максимальным количеством игр");
                Console.WriteLine("2. Студия с максимальным количеством игр");
                Console.WriteLine("3. Топ-3 самых популярных стилей по количеству игр");
                Console.WriteLine("4. Самый популярный стиль по количеству игр");
                Console.WriteLine("=== ЗАДАНИЕ 2 ===");
                Console.WriteLine("5. Топ-3 самых популярных стилей по количеству продаж");
                Console.WriteLine("6. Самый популярный стиль по количеству продаж");
                Console.WriteLine("7. Топ-3 самых популярных однопользовательских игр по продажам");
                Console.WriteLine("8. Топ-3 самых популярных многопользовательских игр по продажам");
                Console.WriteLine("9. Самая популярная однопользовательская игра по продажам");
                Console.WriteLine("10. Самая популярная многопользовательская игра по продажам");
                Console.WriteLine("11. Самая популярная игра по количеству продаж");
                Console.WriteLine("=== ЗАДАНИЕ 3 ===");
                Console.WriteLine("12. Удалить игры с нулевыми продажами");
                Console.WriteLine("13. Удалить игры с указанным количеством продаж");
                Console.WriteLine("14. Создать представления и процедуры");
                Console.WriteLine("15. Вернуться в главное меню");
                Console.Write("Выберите действие: ");

                var choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        ShowTop3StudiosByGames(context);
                        Console.ReadKey();
                        break;
                    case 2:
                        ShowTopStudioByGames(context);
                        Console.ReadKey();
                        break;
                    case 3:
                        ShowTop3StylesByGames(context);
                        Console.ReadKey();
                        break;
                    case 4:
                        ShowTopStyleByGames(context);
                        Console.ReadKey();
                        break;
                    case 5:
                        ShowTop3StylesBySales(context);
                        Console.ReadKey();
                        break;
                    case 6:
                        ShowTopStyleBySales(context);
                        Console.ReadKey();
                        break;
                    case 7:
                        ShowTop3SingleplayerGames(context);
                        Console.ReadKey();
                        break;
                    case 8:
                        ShowTop3MultiplayerGames(context);
                        Console.ReadKey();
                        break;
                    case 9:
                        ShowTopSingleplayerGame(context);
                        Console.ReadKey();
                        break;
                    case 10:
                        ShowTopMultiplayerGame(context);
                        Console.ReadKey();
                        break;
                    case 11:
                        ShowTopGameBySales(context);
                        Console.ReadKey();
                        break;
                    case 12:
                        DeleteGamesWithZeroSales(context);
                        Console.ReadKey();
                        break;
                    case 13:
                        DeleteGamesWithSalesParam(context);
                        Console.ReadKey();
                        break;
                    case 14:
                        CreateViewsAndProcedures(context);
                        Console.ReadKey();
                        break;
                    case 15:
                        return;
                    default:
                        Console.WriteLine("Неверный выбор. Попробуйте снова.");
                        Console.ReadKey();
                        break;
                }
            }
        }
        // Функции для Задания 1
        static void ShowTop3StudiosByGames(GameContext context)
        {
            try
            {
                var topStudios = context.TopStudiosByGames
                    .Take(3)
                    .ToList();

                Console.WriteLine("\n=== ТОП-3 СТУДИЙ ПО КОЛИЧЕСТВУ ИГР ===");

                if (topStudios.Any())
                {
                    for (int i = 0; i < topStudios.Count; i++)
                    {
                        Console.WriteLine($"{i + 1}. {topStudios[i].StudioName} - {topStudios[i].GameCount} игр");
                    }
                }
                else
                {
                    Console.WriteLine("Нет данных о студиях");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при получении данных: {ex.Message}");
            }
        }

        static void ShowTopStudioByGames(GameContext context)
        {
            try
            {
                var topStudio = context.TopStudiosByGames
                    .FirstOrDefault();

                Console.WriteLine("\n=== СТУДИЯ С МАКСИМАЛЬНЫМ КОЛИЧЕСТВОМ ИГР ===");

                if (topStudio != null)
                {
                    Console.WriteLine($"{topStudio.StudioName} - {topStudio.GameCount} игр");
                }
                else
                {
                    Console.WriteLine("Нет данных о студиях");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при получении данных: {ex.Message}");
            }
        }

        static void ShowTop3StylesByGames(GameContext context)
        {
            try
            {
                var topStyles = context.TopStylesByGames
                    .Take(3)
                    .ToList();

                Console.WriteLine("\n=== ТОП-3 САМЫХ ПОПУЛЯРНЫХ СТИЛЕЙ ПО КОЛИЧЕСТВУ ИГР ===");

                if (topStyles.Any())
                {
                    for (int i = 0; i < topStyles.Count; i++)
                    {
                        Console.WriteLine($"{i + 1}. {topStyles[i].StyleName} - {topStyles[i].GameCount} игр");
                    }
                }
                else
                {
                    Console.WriteLine("Нет данных о стилях");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при получении данных: {ex.Message}");
            }
        }

        static void ShowTopStyleByGames(GameContext context)
        {
            try
            {
                var topStyle = context.TopStylesByGames
                    .FirstOrDefault();

                Console.WriteLine("\n=== САМЫЙ ПОПУЛЯРНЫЙ СТИЛЬ ПО КОЛИЧЕСТВУ ИГР ===");

                if (topStyle != null)
                {
                    Console.WriteLine($"{topStyle.StyleName} - {topStyle.GameCount} игр");
                }
                else
                {
                    Console.WriteLine("Нет данных о стилях");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при получении данных: {ex.Message}");
            }
        }
        // Функции для Задания 2
        static void ShowTop3StylesBySales(GameContext context)
        {
            try
            {
                var topStyles = context.TopStylesBySales
                    .Take(3)
                    .ToList();

                Console.WriteLine("\n=== ТОП-3 САМЫХ ПОПУЛЯРНЫХ СТИЛЕЙ ПО КОЛИЧЕСТВУ ПРОДАЖ ===");

                if (topStyles.Any())
                {
                    for (int i = 0; i < topStyles.Count; i++)
                    {
                        Console.WriteLine($"{i + 1}. {topStyles[i].StyleName} - {topStyles[i].TotalSales:N0} продаж");
                    }
                }
                else
                {
                    Console.WriteLine("Нет данных о стилях");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при получении данных: {ex.Message}");
            }
        }

        static void ShowTopStyleBySales(GameContext context)
        {
            try
            {
                var topStyle = context.TopStylesBySales
                    .FirstOrDefault();

                Console.WriteLine("\n=== САМЫЙ ПОПУЛЯРНЫЙ СТИЛЬ ПО КОЛИЧЕСТВУ ПРОДАЖ ===");

                if (topStyle != null)
                {
                    Console.WriteLine($"{topStyle.StyleName} - {topStyle.TotalSales:N0} продаж");
                }
                else
                {
                    Console.WriteLine("Нет данных о стилях");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при получении данных: {ex.Message}");
            }
        }

        static void ShowTop3SingleplayerGames(GameContext context)
        {
            try
            {
                var topGames = context.TopSingleplayerGames
                    .Take(3)
                    .ToList();

                Console.WriteLine("\n=== ТОП-3 САМЫХ ПОПУЛЯРНЫХ ОДНОПОЛЬЗОВАТЕЛЬСКИХ ИГР ===");

                if (topGames.Any())
                {
                    for (int i = 0; i < topGames.Count; i++)
                    {
                        var game = topGames[i];
                        var studio = context.Studios.Find(game.StudioId);
                        Console.WriteLine($"{i + 1}. {game.Name} ({studio?.Name ?? "Неизвестная студия"}) - {game.CopiesSold:N0} продаж");
                    }
                }
                else
                {
                    Console.WriteLine("Нет однопользовательских игр");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при получении данных: {ex.Message}");
            }
        }

        static void ShowTop3MultiplayerGames(GameContext context)
        {
            try
            {
                var topGames = context.TopMultiplayerGames
                    .Take(3)
                    .ToList();

                Console.WriteLine("\n=== ТОП-3 САМЫХ ПОПУЛЯРНЫХ МНОГОПОЛЬЗОВАТЕЛЬСКИХ ИГР ===");

                if (topGames.Any())
                {
                    for (int i = 0; i < topGames.Count; i++)
                    {
                        var game = topGames[i];
                        var studio = context.Studios.Find(game.StudioId);
                        Console.WriteLine($"{i + 1}. {game.Name} ({studio?.Name ?? "Неизвестная студия"}) - {game.CopiesSold:N0} продаж");
                    }
                }
                else
                {
                    Console.WriteLine("Нет многопользовательских игр");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при получении данных: {ex.Message}");
            }
        }

        static void ShowTopSingleplayerGame(GameContext context)
        {
            try
            {
                var topGame = context.TopSingleplayerGames
                    .FirstOrDefault();

                Console.WriteLine("\n=== САМАЯ ПОПУЛЯРНАЯ ОДНОПОЛЬЗОВАТЕЛЬСКАЯ ИГРА ===");

                if (topGame != null)
                {
                    var studio = context.Studios.Find(topGame.StudioId);
                    Console.WriteLine($"{topGame.Name} ({studio?.Name ?? "Неизвестная студия"}) - {topGame.CopiesSold:N0} продаж");
                }
                else
                {
                    Console.WriteLine("Нет однопользовательских игр");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при получении данных: {ex.Message}");
            }
        }

        static void ShowTopMultiplayerGame(GameContext context)
        {
            try
            {
                var topGame = context.TopMultiplayerGames
                    .FirstOrDefault();

                Console.WriteLine("\n=== САМАЯ ПОПУЛЯРНАЯ МНОГОПОЛЬЗОВАТЕЛЬСКАЯ ИГРА ===");

                if (topGame != null)
                {
                    var studio = context.Studios.Find(topGame.StudioId);
                    Console.WriteLine($"{topGame.Name} ({studio?.Name ?? "Неизвестная студия"}) - {topGame.CopiesSold:N0} продаж");
                }
                else
                {
                    Console.WriteLine("Нет многопользовательских игр");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при получении данных: {ex.Message}");
            }
        }

        static void ShowTopGameBySales(GameContext context)
        {
            try
            {
                var topGame = context.Games
                    .Include(g => g.Studio)
                    .OrderByDescending(g => g.CopiesSold)
                    .FirstOrDefault();

                Console.WriteLine("\n=== САМАЯ ПОПУЛЯРНАЯ ИГРА ПО КОЛИЧЕСТВУ ПРОДАЖ ===");

                if (topGame != null)
                {
                    Console.WriteLine($"{topGame.Name} ({topGame.Studio?.Name ?? "Неизвестная студия"}) - {topGame.CopiesSold:N0} продаж");
                    Console.WriteLine($"Стиль: {topGame.PlayingStyle}");
                    Console.WriteLine($"Режим: {topGame.GameMode}");
                    Console.WriteLine($"Дата выхода: {topGame.DateRealise:yyyy-MM-dd}");
                }
                else
                {
                    Console.WriteLine("Нет игр в базе данных");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при получении данных: {ex.Message}");
            }
        }
        // Функции для Задания 3
        static void DeleteGamesWithZeroSales(GameContext context)
        {
            try
            {
                Console.WriteLine("\n=== УДАЛЕНИЕ ИГР С НУЛЕВЫМИ ПРОДАЖАМИ ===");

                // Подсчет игр перед удалением
                var gamesToDelete = context.Games
                    .Where(g => g.CopiesSold == 0)
                    .ToList();

                if (gamesToDelete.Any())
                {
                    Console.WriteLine($"Найдено {gamesToDelete.Count} игр с нулевыми продажами:");
                    foreach (var game in gamesToDelete)
                    {
                        Console.WriteLine($"- {game.Name}");
                    }

                    Console.Write("\nВы уверены, что хотите удалить эти игры? (да/нет): ");
                    var confirmation = Console.ReadLine().ToLower();

                    if (confirmation == "да" || confirmation == "д")
                    {
                        var deletedCount = context.DeleteGamesWithZeroSales();
                        Console.WriteLine($"Удалено {deletedCount} игр с нулевыми продажами");
                    }
                    else
                    {
                        Console.WriteLine("Удаление отменено");
                    }
                }
                else
                {
                    Console.WriteLine("Игр с нулевыми продажами не найдено");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при удалении игр: {ex.Message}");
            }
        }

        static void DeleteGamesWithSalesParam(GameContext context)
        {
            try
            {
                Console.WriteLine("\n=== УДАЛЕНИЕ ИГР С УКАЗАННЫМ КОЛИЧЕСТВОМ ПРОДАЖ ===");

                Console.Write("Введите количество продаж для удаления: ");
                if (!int.TryParse(Console.ReadLine(), out int salesThreshold))
                {
                    Console.WriteLine("Неверный формат числа");
                    return;
                }

                // Подсчет игр перед удалением
                var gamesToDelete = context.Games
                    .Where(g => g.CopiesSold == salesThreshold)
                    .ToList();

                if (gamesToDelete.Any())
                {
                    Console.WriteLine($"Найдено {gamesToDelete.Count} игр с {salesThreshold} продажами:");
                    foreach (var game in gamesToDelete)
                    {
                        var studio = context.Studios.Find(game.StudioId);
                        Console.WriteLine($"- {game.Name} ({studio?.Name ?? "Неизвестная студия"})");
                    }

                    Console.Write("\nВы уверены, что хотите удалить эти игры? (да/нет): ");
                    var confirmation = Console.ReadLine().ToLower();

                    if (confirmation == "да" || confirmation == "д")
                    {
                        var deletedCount = context.DeleteGamesWithSales(salesThreshold);
                        Console.WriteLine($"Удалено {deletedCount} игр с {salesThreshold} продажами");
                    }
                    else
                    {
                        Console.WriteLine("Удаление отменено");
                    }
                }
                else
                {
                    Console.WriteLine($"Игр с {salesThreshold} продажами не найдено");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при удалении игр: {ex.Message}");
            }
        }

        static void CreateViewsAndProcedures(GameContext context)
        {
            try
            {
                Console.WriteLine("\n=== СОЗДАНИЕ ПРЕДСТАВЛЕНИЙ И ПРОЦЕДУР ===");
                context.CreateViewsAndProcedures();
                Console.WriteLine("Представления и процедуры успешно созданы");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при создании представлений: {ex.Message}");
            }
        }
    }
}