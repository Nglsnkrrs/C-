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
            while (true) {
                using var context = new GameContext();
                Console.WriteLine("1. Создание/обновление базы данных");
                Console.WriteLine("2. Добавление игр в базу данных");
                Console.WriteLine("3. Список всех игр в базе данных");
                Console.WriteLine("4. Статистика по играм");
                Console.WriteLine("5. Различные поиски игры");
                Console.WriteLine("6. Отображение информации обо всех однопользовательских играх");
                Console.WriteLine("7. Отображение информации обо всех многопользовательских играх");
                Console.WriteLine("8. Статистика по продажам игр");
                Console.WriteLine("9. Управление играми (добавить/изменить/удалить)");
                Console.Write("Выберите поиск: ");
                var choiceMain = int.Parse(Console.ReadLine());
                switch (choiceMain)
                {
                    case 1:
                        CreateDatabase(context);
                        Console.WriteLine();
                        break;
                    case 2:
                        AddGames(context);
                        Console.WriteLine();
                        break;
                    case 3:
                        ViewAllGames(context);
                        Console.WriteLine();
                        break;
                    case 4:
                        GameDtatistics(context);
                        Console.WriteLine();
                        break;
                    case 5:
                        SearchGame(context);
                        Console.WriteLine();
                        break;
                    case 6:
                        SingleplayerGame(context);
                        Console.WriteLine();
                        break;
                    case 7:
                        MultiplayerGame(context);
                        Console.WriteLine();
                        break;
                    case 8:
                        SalesStatistics(context);
                        Console.WriteLine();
                        break;
                    case 9:
                        ManageGames(context);
                        Console.WriteLine();
                        break;
                    default:
                        Console.WriteLine("Неверный выбор. Попробуйте снова.");
                        break;
                }
            }
       
        }
        static void CreateDatabase(GameContext context)
        {
            Console.WriteLine("Инициализация базы данных...");
            try
            {
                
                bool created = context.Database.EnsureCreated();
                Console.WriteLine($"База данных {(created ? "создана" : "уже существует")}");
                Console.WriteLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при создании базы данных: {ex.Message}");

            }
        }

        static void AddGames(GameContext context)
        {
                try
                {
                    Console.Write("Название игры: ");
                    var name = Console.ReadLine();
                    Console.Write("Студия или компания разработки: ");
                    var studio = Console.ReadLine();
                    Console.Write("Стиль игры: ");
                    var playingstyle = Console.ReadLine();
                    Console.Write("Копий продано: ");
                    var copies = int.Parse(Console.ReadLine());
                    Console.Write("Режим игры: ");
                    var gamemode = Console.ReadLine();
                    Console.Write("Дата выпуска: ");
                    Console.Write("Год: ");
                    int year = int.Parse(Console.ReadLine());
                    Console.Write("Месяц (1-12): ");
                    int month = int.Parse(Console.ReadLine());
                    Console.Write("День (1-31): ");
                    int day = int.Parse(Console.ReadLine());
                    var dateRealise = new DateTime(year, month, day);


                    var games = new Games
                    {
                        Name = name,
                        Studio = studio,
                        PlayingStyle = playingstyle,
                        CopiesSold = copies,
                        GameMode = gamemode,
                        DateRealise = dateRealise
                    };
                    context.Games.Add(games);
                    context.SaveChanges();
                    Console.WriteLine($"Игра {name} добавлена (ID: {games.Id})!");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Ошибка: {ex.Message}");
                }
        }

        static void ViewAllGames(GameContext context)
        {
            var games = context.Games.OrderBy(g => g.Id).ToList();

            if (games.Any())
            {
                    Console.WriteLine($"\nВсего игр в базе: {games.Count}");
                    foreach (var game in games)
                    {
                        Console.WriteLine($"|ID: {game.Id} |Название: {game.Name} |Студия: {game.Studio} | " +
                            $"Стиль: {game.PlayingStyle} |Режим: {game.GameMode} |Продано: {game.CopiesSold} |Дата выхода: {game.DateRealise:yyyy-MM-dd} |");
                    }
            }
            else
            {
               Console.WriteLine("В базе данных нет игр.");
            }
            
        }

        static void GameDtatistics(GameContext context)
        {
            var totalCopiesSold = context.Games.Sum(g => g.CopiesSold);
            var singleplayerCount = context.Games.Count(g => g.GameMode == "Singleplayer");
            var multiplayerCount = context.Games.Count(g => g.GameMode == "Multiplayer");

            Console.WriteLine($"Всего продано копий: {totalCopiesSold:N0}");
            Console.WriteLine($"Однопользовательских игр: {singleplayerCount}");
            Console.WriteLine($"Многопользовательских игр: {multiplayerCount}");
        }

        static void SearchGame(GameContext context)
        {
            while (true)
            {
                Console.WriteLine("\n=== ПОИСК ИГР ===");
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
                        Console.WriteLine();
                        break;
                    case 2:
                        SearchByStudio(context);
                        Console.WriteLine();
                        break;
                    case 3:
                        SearchByNameAndStudio(context);
                        Console.WriteLine();
                        break;
                    case 4:
                        SearchByStyle(context);
                        Console.WriteLine();
                        break;
                    case 5:
                        SearchByReleaseYear(context);
                        Console.WriteLine();
                        break;
                    case 6:
                        SearchBySalesRange(context);
                        Console.WriteLine();
                        break;
                    case 7:
                        SearchByGameMode(context);
                        Console.WriteLine();
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
                .Where(g => g.Studio.ToLower().Contains(searchStudio.ToLower()))
                .OrderBy(g => g.Studio)
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

            var query = context.Games.AsQueryable();

            if (!string.IsNullOrWhiteSpace(searchName))
            {
                query = query.Where(g => g.Name.ToLower().Contains(searchName.ToLower()));
            }

            if (!string.IsNullOrWhiteSpace(searchStudio))
            {
                query = query.Where(g => g.Studio.ToLower().Contains(searchStudio.ToLower()));
            }

            var results = query
                .OrderBy(g => g.Studio)
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

            IQueryable<Games> query = context.Games;

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

            IQueryable<Games> query = context.Games;
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
                Console.WriteLine($"|ID: {game.Id} |Название: {game.Name} |Студия: {game.Studio} | " +
                    $"Стиль: {game.PlayingStyle} |Режим: {game.GameMode} |Продано: {game.CopiesSold} |Дата выхода: {game.DateRealise:yyyy-MM-dd} |");
            }


 
        }

        static void SingleplayerGame(GameContext context)
        {
            var singleplayerGame = context.Games
                                .Where(g => g.GameMode == "Singleplayer" || g.GameMode.Contains("Однопользовательская"))
                                .OrderBy(g => g.Name)
                                .ToList();

            if (singleplayerGame.Any())
            {
                Console.WriteLine($"\nВсего однопользовательских игр в базе: {singleplayerGame.Count}");
                foreach (var game in singleplayerGame)
                {
                    Console.WriteLine($"|ID: {game.Id} |Название: {game.Name} |Студия: {game.Studio} | " +
                        $"Стиль: {game.PlayingStyle} |Режим: {game.GameMode} |Продано: {game.CopiesSold} |Дата выхода: {game.DateRealise:yyyy-MM-dd} |");
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
                                .Where(g => g.GameMode == "Multiplayer" || g.GameMode.Contains("Многопользовательская"))
                                .OrderBy(g => g.Name)
                                .ToList();

            if (multiplayerGames.Any())
            {
                Console.WriteLine($"\nВсего многопользовательских игр в базе: {multiplayerGames.Count}");
                foreach (var game in multiplayerGames)
                {
                    Console.WriteLine($"|ID: {game.Id} |Название: {game.Name} |Студия: {game.Studio} | " +
                        $"Стиль: {game.PlayingStyle} |Режим: {game.GameMode} |Продано: {game.CopiesSold} |Дата выхода: {game.DateRealise:yyyy-MM-dd} |");
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

            var maxSoldGame = context.Games
                .OrderByDescending(g => g.CopiesSold)
                .FirstOrDefault();

            if (maxSoldGame != null)
            {
                Console.WriteLine($"\nИгра с максимальным количеством продаж:");
                Console.WriteLine($"Название: {maxSoldGame.Name}");
                Console.WriteLine($"Студия: {maxSoldGame.Studio}");
                Console.WriteLine($"Продано копий: {maxSoldGame.CopiesSold:N0}");
                Console.WriteLine($"Режим игры: {maxSoldGame.GameMode}");
            }

            var minSoldGame = context.Games
                .OrderBy(g => g.CopiesSold)
                .FirstOrDefault();

            if (minSoldGame != null)
            {
                Console.WriteLine($"\nИгра с минимальным количеством продаж:");
                Console.WriteLine($"Название: {minSoldGame.Name}");
                Console.WriteLine($"Студия: {minSoldGame.Studio}");
                Console.WriteLine($"Продано копий: {minSoldGame.CopiesSold:N0}");
                Console.WriteLine($"Режим игры: {minSoldGame.GameMode}");
            }

            var top3SoldGames = context.Games
                .OrderByDescending(g => g.CopiesSold)
                .Take(3)
                .ToList();

            if (top3SoldGames.Any())
            {
                Console.WriteLine($"\nТоп-3 самых продаваемых игр:");
                for (int i = 0; i < top3SoldGames.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {top3SoldGames[i].Name} - {top3SoldGames[i].CopiesSold:N0} копий ({top3SoldGames[i].Studio})");
                }
            }

            var bottom3SoldGames = context.Games
                .OrderBy(g => g.CopiesSold)
                .Take(3)
                .ToList();

            if (bottom3SoldGames.Any())
            {
                Console.WriteLine($"\nТоп-3 самых непродаваемых игр:");
                for (int i = 0; i < bottom3SoldGames.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {bottom3SoldGames[i].Name} - {bottom3SoldGames[i].CopiesSold:N0} копий ({bottom3SoldGames[i].Studio})");
                }
            }

            var averageSold = context.Games.Average(g => g.CopiesSold);
            var totalGames = context.Games.Count();

            Console.WriteLine($"\nДополнительная статистика:");
            Console.WriteLine($"Среднее количество продаж на игру: {averageSold:N0}");
            Console.WriteLine($"Всего игр в базе: {totalGames}");
        }


        static void ManageGames(GameContext context)
        {
            while (true)
            {
                Console.WriteLine("\n=== УПРАВЛЕНИЕ ИГРАМИ ===");
                Console.WriteLine("1. Добавить новую игру (с проверкой на дубликаты)");
                Console.WriteLine("2. Изменить данные существующей игры");
                Console.WriteLine("3. Удалить игру");
                Console.WriteLine("4. Вернуться в главное меню");
                Console.Write("Выберите действие: ");

                var choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        AddGameWithCheck(context);
                        break;
                    case 2:
                        UpdateGame(context);
                        break;
                    case 3:
                        DeleteGame(context);
                        break;
                    case 4:
                        return;
                    default:
                        Console.WriteLine("Неверный выбор. Попробуйте снова.");
                        break;
                }
            }
        }

        static void AddGameWithCheck(GameContext context)
        {
            try
            {
                Console.WriteLine("\n=== ДОБАВЛЕНИЕ НОВОЙ ИГРЫ ===");

                Console.Write("Название игры: ");
                var name = Console.ReadLine();

                Console.Write("Студия или компания разработки: ");
                var studio = Console.ReadLine();

                var existingGame = context.Games
                    .FirstOrDefault(g => g.Name.ToLower() == name.ToLower() &&
                                        g.Studio.ToLower() == studio.ToLower());

                if (existingGame != null)
                {
                    Console.WriteLine($"\nИгра '{name}' от студии '{studio}' уже существует в базе данных!");
                    Console.WriteLine("Информация о существующей игре:");
                    DisplayGameInfo(existingGame);

                    Console.Write("\nХотите добавить эту игру как новую запись? (да/нет): ");
                    var answer = Console.ReadLine().ToLower();

                    if (answer != "да" && answer != "д" && answer != "yes" && answer != "y")
                    {
                        Console.WriteLine("Добавление отменено.");
                        return;
                    }
                }

                Console.Write("Стиль игры: ");
                var playingstyle = Console.ReadLine();

                Console.Write("Копий продано: ");
                var copies = int.Parse(Console.ReadLine());

                Console.Write("Режим игры (Singleplayer/Multiplayer): ");
                var gamemode = Console.ReadLine();

                Console.Write("Дата выпуска: ");
                Console.Write("Год: ");
                int year = int.Parse(Console.ReadLine());
                Console.Write("Месяц (1-12): ");
                int month = int.Parse(Console.ReadLine());
                Console.Write("День (1-31): ");
                int day = int.Parse(Console.ReadLine());
                var dateRealise = new DateTime(year, month, day);

                var game = new Games
                {
                    Name = name,
                    Studio = studio,
                    PlayingStyle = playingstyle,
                    CopiesSold = copies,
                    GameMode = gamemode,
                    DateRealise = dateRealise
                };

                context.Games.Add(game);
                context.SaveChanges();
                Console.WriteLine($"\nИгра '{name}' успешно добавлена (ID: {game.Id})!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
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
                gameToUpdate = context.Games.Find(gameId);
            }
            else
            {
                Console.Write("Введите название игры: ");
                var gameName = Console.ReadLine();

                Console.Write("Введите студию разработчика: ");
                var studioName = Console.ReadLine();

                var games = context.Games
                    .Where(g => g.Name.ToLower().Contains(gameName.ToLower()) &&
                               g.Studio.ToLower().Contains(studioName.ToLower()))
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
                        Console.WriteLine($"ID: {game.Id} | {game.Name} | {game.Studio}");
                    }

                    Console.Write("\nВведите ID игры для изменения: ");
                    gameId = int.Parse(Console.ReadLine());
                    gameToUpdate = context.Games.Find(gameId);
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

            Console.Write($"Студия разработки [{gameToUpdate.Studio}]: ");
            var newStudio = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(newStudio))
                gameToUpdate.Studio = newStudio;

            Console.Write($"Стиль игры [{gameToUpdate.PlayingStyle}]: ");
            var newStyle = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(newStyle))
                gameToUpdate.PlayingStyle = newStyle;

            Console.Write($"Копий продано [{gameToUpdate.CopiesSold}]: ");
            var copiesInput = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(copiesInput))
                gameToUpdate.CopiesSold = int.Parse(copiesInput);

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
                if (!string.IsNullOrWhiteSpace(yearInput))
                    newYear = int.Parse(yearInput);
                if (!string.IsNullOrWhiteSpace(monthInput))
                    newMonth = int.Parse(monthInput);
                if (!string.IsNullOrWhiteSpace(dayInput))
                    newDay = int.Parse(dayInput);

                gameToUpdate.DateRealise = new DateTime(newYear, newMonth, newDay);
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

            Console.Write("Введите студию разработчика: ");
            var studioName = Console.ReadLine();

            var games = context.Games
                .Where(g => g.Name.ToLower().Contains(gameName.ToLower()) &&
                           g.Studio.ToLower().Contains(studioName.ToLower()))
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
                    Console.WriteLine($"ID: {game.Id} | {game.Name} | {game.Studio} | Продано: {game.CopiesSold}");
                }

                Console.Write("\nВведите ID игры для удаления: ");
                var gameId = int.Parse(Console.ReadLine());
                gameToDelete = context.Games.Find(gameId);

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
        static void DisplayGameInfo(Games game)
        {
            Console.WriteLine("=================================");
            Console.WriteLine($"ID: {game.Id}");
            Console.WriteLine($"Название: {game.Name}");
            Console.WriteLine($"Студия: {game.Studio}");
            Console.WriteLine($"Стиль: {game.PlayingStyle}");
            Console.WriteLine($"Режим игры: {game.GameMode}");
            Console.WriteLine($"Продано копий: {game.CopiesSold:N0}");
            Console.WriteLine($"Дата выхода: {game.DateRealise:yyyy-MM-dd}");
            Console.WriteLine("=================================\n");
        }
    }
}