using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using MailingListSystem.Data;
using MailingListSystem.Models;
using Microsoft.Data.Sqlite;
using System.Collections.Generic;

namespace MailingListSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== Система управления списком рассылки ===");

            bool exit = false;

            while (!exit)
            {
                ShowMainMenu();

                var choice = Console.ReadLine();
                Console.WriteLine();

                switch (choice)
                {
                    case "1":
                        ConnectToDatabase();
                        break;
                    case "2":
                        DisconnectFromDatabase();
                        break;
                    case "3":
                        CheckConnection();
                        break;
                    case "4":
                        ShowStatistics();
                        break;
                    case "5":
                        ManageSubscribersMenu();
                        break;
                    case "6":
                        ManageCountriesMenu();
                        break;
                    case "7":
                        ManageCitiesMenu();
                        break;
                    case "8":
                        ManageCategoriesMenu();
                        break;
                    case "9":
                        ManagePromotionsMenu();
                        break;
                    case "10":
                        ShowInformationMenu();
                        break;
                    case "0":
                        exit = true;
                        Console.WriteLine("Выход из программы...");
                        break;
                    default:
                        Console.WriteLine("Неверная команда!");
                        break;
                }
            }
        }

        static void ShowMainMenu()
        {
            Console.WriteLine("\n=== ГЛАВНОЕ МЕНЮ ===");
            Console.WriteLine("1. Подключиться к базе данных");
            Console.WriteLine("2. Отключиться от базы данных");
            Console.WriteLine("3. Проверить подключение");
            Console.WriteLine("4. Показать статистику");
            Console.WriteLine("=== Управление данными ===");
            Console.WriteLine("5. Управление покупателями");
            Console.WriteLine("6. Управление странами");
            Console.WriteLine("7. Управление городами");
            Console.WriteLine("8. Управление разделами");
            Console.WriteLine("9. Управление акционными товарами");
            Console.WriteLine("10. Просмотр информации");
            Console.WriteLine("0. Выход");
            Console.Write("Выберите команду: ");
        }

        #region Базовые функции подключения
        static void ConnectToDatabase()
        {
            Console.WriteLine("\n=== Подключение к базе данных ===");

            try
            {
                using (var context = new MailingDbContext())
                {
                    Console.WriteLine("Попытка подключения к базе данных...");

                    bool canConnect = context.Database.CanConnect();

                    if (canConnect)
                    {
                        Console.WriteLine("Успешное подключение к базе данных!");

                        Console.WriteLine("Проверка существования базы данных...");
                        context.Database.EnsureCreated();
                        Console.WriteLine("База данных готова к работе.");

                        var connection = context.Database.GetDbConnection();
                        Console.WriteLine($"Тип базы данных: {connection.GetType().Name}");
                        Console.WriteLine($"База данных: {connection.Database}");
                    }
                    else
                    {
                        Console.WriteLine("Не удалось подключиться к базе данных.");
                    }
                }
            }
            catch (SqliteException ex)
            {
                Console.WriteLine($"Ошибка подключения к SQLite: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Общая ошибка: {ex.Message}");
            }
        }

        static void DisconnectFromDatabase()
        {
            Console.WriteLine("\n=== Отключение от базы данных ===");
            Console.WriteLine("Все подключения к базе данных закрыты.");
            Console.WriteLine("При следующем запросе будет установлено новое подключение.");
        }

        static void CheckConnection()
        {
            Console.WriteLine("\n=== Проверка подключения ===");

            try
            {
                using (var context = new MailingDbContext())
                {
                    var connection = context.Database.GetDbConnection();

                    if (connection.State == System.Data.ConnectionState.Open)
                    {
                        Console.WriteLine("Подключение активно и открыто");
                    }
                    else if (connection.State == System.Data.ConnectionState.Closed)
                    {
                        Console.WriteLine("Подключение закрыто, но может быть открыто по требованию");
                        connection.Open();
                        Console.WriteLine($"Подключение успешно открыто");
                        connection.Close();
                    }

                    Console.WriteLine($"База данных: {connection.Database}");
                    Console.WriteLine($"Версия: {connection.ServerVersion}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка проверки подключения: {ex.Message}");
            }
        }

        static void ShowStatistics()
        {
            Console.WriteLine("\n=== Статистика базы данных ===");

            try
            {
                using (var context = new MailingDbContext())
                {
                    if (!context.Database.CanConnect())
                    {
                        Console.WriteLine("Нет подключения к базе данных");
                        return;
                    }

                    var subscribersCount = context.Subscribers.Count();
                    var categoriesCount = context.Categories.Count();
                    var promotionsCount = context.Promotions.Count();
                    var activePromotions = context.Promotions.Count(p => p.IsActive && p.EndDate >= DateTime.Now);
                    var countriesCount = context.Countries.Count();
                    var citiesCount = context.Cities.Count();

                    Console.WriteLine("Общая статистика:");
                    Console.WriteLine($"   Покупателей: {subscribersCount}");
                    Console.WriteLine($"   Стран: {countriesCount}");
                    Console.WriteLine($"   Городов: {citiesCount}");
                    Console.WriteLine($"   Разделов: {categoriesCount}");
                    Console.WriteLine($"   Акций всего: {promotionsCount}");
                    Console.WriteLine($"   Активных акций: {activePromotions}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка получения статистики: {ex.Message}");
            }
        }
        #endregion

        #region Управление покупателями (Задание 1, 2, 3)
        static void ManageSubscribersMenu()
        {
            Console.WriteLine("\n=== Управление покупателями ===");
            Console.WriteLine("1. Добавить покупателя");
            Console.WriteLine("2. Показать всех покупателей");
            Console.WriteLine("3. Обновить данные покупателя");
            Console.WriteLine("4. Удалить покупателя");
            Console.WriteLine("5. Добавить раздел для покупателя");
            Console.WriteLine("0. Назад");
            Console.Write("Выберите: ");

            var choice = Console.ReadLine();
            Console.WriteLine();

            switch (choice)
            {
                case "1":
                    AddSubscriber();
                    break;
                case "2":
                    ShowAllSubscribers();
                    break;
                case "3":
                    UpdateSubscriber();
                    break;
                case "4":
                    DeleteSubscriber();
                    break;
                case "5":
                    AddCategoryToSubscriber();
                    break;
            }
        }

        static void AddSubscriber()
        {
            Console.WriteLine("=== Добавление нового покупателя ===");

            try
            {
                using (var context = new MailingDbContext())
                {
                    Console.Write("ФИО: ");
                    var fullName = Console.ReadLine();

                    Console.Write("Дата рождения (гггг-мм-дд): ");
                    if (!DateTime.TryParse(Console.ReadLine(), out var birthDate))
                    {
                        Console.WriteLine("Неверный формат даты");
                        return;
                    }

                    Console.Write("Пол (Male/Female/Other): ");
                    var gender = Console.ReadLine();

                    Console.Write("Email: ");
                    var email = Console.ReadLine();

                    var countries = context.Countries.ToList();
                    if (!countries.Any())
                    {
                        Console.WriteLine("Сначала добавьте страны");
                        return;
                    }

                    Console.WriteLine("\nДоступные страны:");
                    foreach (var country in countries)
                    {
                        Console.WriteLine($"{country.Id}. {country.Name}");
                    }
                    Console.Write("Выберите ID страны: ");
                    if (!int.TryParse(Console.ReadLine(), out int countryId))
                    {
                        Console.WriteLine("❌ Неверный ID");
                        return;
                    }

                    var cities = context.Cities.Where(c => c.CountryId == countryId).ToList();
                    if (!cities.Any())
                    {
                        Console.WriteLine("В этой стране нет городов");
                        return;
                    }

                    Console.WriteLine("\nДоступные города:");
                    foreach (var city in cities)
                    {
                        Console.WriteLine($"{city.Id}. {city.Name}");
                    }
                    Console.Write("Выберите ID города: ");
                    if (!int.TryParse(Console.ReadLine(), out int cityId))
                    {
                        Console.WriteLine("Неверный ID");
                        return;
                    }

                    var subscriber = new Subscriber
                    {
                        FullName = fullName,
                        BirthDate = birthDate,
                        Gender = gender,
                        Email = email,
                        CountryId = countryId,
                        CityId = cityId,
                        IsActive = true
                    };

                    context.Subscribers.Add(subscriber);
                    context.SaveChanges();

                    Console.WriteLine($"Покупатель '{fullName}' добавлен с ID: {subscriber.Id}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }
        }

        static void ShowAllSubscribers()
        {
            try
            {
                using (var context = new MailingDbContext())
                {
                    var subscribers = context.Subscribers
                        .Include(s => s.Country)
                        .Include(s => s.City)
                        .ToList();

                    if (!subscribers.Any())
                    {
                        Console.WriteLine("Покупатели не найдены");
                        return;
                    }

                    Console.WriteLine($"{"ID"} {"ФИО"} {"Email"}");
                    Console.WriteLine(new string('-', 90));

                    foreach (var subscriber in subscribers)
                    {
                        Console.WriteLine($"{subscriber.Id} {subscriber.FullName} {subscriber.Email} {subscriber.Country?.Name} {subscriber.City?.Name}");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }
        }

        static void UpdateSubscriber()
        {
            Console.WriteLine("=== Обновление данных покупателя ===");

            try
            {
                using (var context = new MailingDbContext())
                {
                    Console.Write("Введите ID покупателя для обновления: ");
                    if (!int.TryParse(Console.ReadLine(), out int id))
                    {
                        Console.WriteLine("Неверный ID");
                        return;
                    }

                    var subscriber = context.Subscribers.Find(id);
                    if (subscriber == null)
                    {
                        Console.WriteLine("Покупатель не найден");
                        return;
                    }

                    Console.WriteLine($"Текущие данные: {subscriber.FullName}, {subscriber.Email}");
                    Console.WriteLine("Оставьте поле пустым, чтобы не изменять значение");

                    Console.Write($"Новое ФИО [{subscriber.FullName}]: ");
                    var newFullName = Console.ReadLine();
                    if (!string.IsNullOrWhiteSpace(newFullName))
                        subscriber.FullName = newFullName;

                    Console.Write($"Новый Email [{subscriber.Email}]: ");
                    var newEmail = Console.ReadLine();
                    if (!string.IsNullOrWhiteSpace(newEmail))
                        subscriber.Email = newEmail;

                    Console.Write($"Новый пол [{subscriber.Gender}]: ");
                    var newGender = Console.ReadLine();
                    if (!string.IsNullOrWhiteSpace(newGender))
                        subscriber.Gender = newGender;

                    context.SaveChanges();
                    Console.WriteLine("Данные покупателя обновлены");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }
        }

        static void DeleteSubscriber()
        {
            Console.WriteLine("=== Удаление покупателя ===");

            try
            {
                using (var context = new MailingDbContext())
                {
                    Console.Write("Введите ID покупателя для удаления: ");
                    if (!int.TryParse(Console.ReadLine(), out int id))
                    {
                        Console.WriteLine("Неверный ID");
                        return;
                    }

                    var subscriber = context.Subscribers.Find(id);
                    if (subscriber == null)
                    {
                        Console.WriteLine("Покупатель не найден");
                        return;
                    }

                    var subscriberCategories = context.SubscriberCategories
                        .Where(sc => sc.SubscriberId == id)
                        .ToList();
                    context.SubscriberCategories.RemoveRange(subscriberCategories);

                    context.Subscribers.Remove(subscriber);
                    context.SaveChanges();

                    Console.WriteLine($"Покупатель '{subscriber.FullName}' удален");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }
        }

        static void AddCategoryToSubscriber()
        {
            Console.WriteLine("=== Добавление раздела для покупателя ===");

            try
            {
                using (var context = new MailingDbContext())
                {
                    var subscribers = context.Subscribers.ToList();
                    if (!subscribers.Any())
                    {
                        Console.WriteLine("Нет покупателей");
                        return;
                    }

                    Console.WriteLine("Покупатели:");
                    foreach (var subscriber in subscribers)
                    {
                        Console.WriteLine($"{subscriber.Id}. {subscriber.FullName}");
                    }

                    Console.Write("Выберите ID покупателя: ");
                    if (!int.TryParse(Console.ReadLine(), out int subscriberId))
                    {
                        Console.WriteLine("Неверный ID");
                        return;
                    }

                    var categories = context.Categories.ToList();
                    if (!categories.Any())
                    {
                        Console.WriteLine("Нет категорий");
                        return;
                    }

                    Console.WriteLine("\nКатегории:");
                    foreach (var category in categories)
                    {
                        Console.WriteLine($"{category.Id}. {category.Name}");
                    }

                    Console.Write("Выберите ID категории: ");
                    if (!int.TryParse(Console.ReadLine(), out int categoryId))
                    {
                        Console.WriteLine("Неверный ID");
                        return;
                    }

                    var existing = context.SubscriberCategories
                        .FirstOrDefault(sc => sc.SubscriberId == subscriberId && sc.CategoryId == categoryId);

                    if (existing != null)
                    {
                        Console.WriteLine("Эта категория уже добавлена для данного покупателя");
                        return;
                    }

                    var subscriberCategory = new SubscriberCategory
                    {
                        SubscriberId = subscriberId,
                        CategoryId = categoryId
                    };

                    context.SubscriberCategories.Add(subscriberCategory);
                    context.SaveChanges();

                    Console.WriteLine("Категория добавлена для покупателя");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }
        }
        #endregion

        #region Управление странами (Задание 1, 2, 3)
        static void ManageCountriesMenu()
        {
            Console.WriteLine("\n=== Управление странами ===");
            Console.WriteLine("1. Добавить страну");
            Console.WriteLine("2. Показать все страны");
            Console.WriteLine("3. Обновить страну");
            Console.WriteLine("4. Удалить страну");
            Console.WriteLine("0. Назад");
            Console.Write("Выберите: ");

            var choice = Console.ReadLine();
            Console.WriteLine();

            switch (choice)
            {
                case "1":
                    AddCountry();
                    break;
                case "2":
                    ShowAllCountries();
                    break;
                case "3":
                    UpdateCountry();
                    break;
                case "4":
                    DeleteCountry();
                    break;
            }
        }

        static void AddCountry()
        {
            Console.WriteLine("=== Добавление новой страны ===");

            try
            {
                using (var context = new MailingDbContext())
                {
                    Console.Write("Название страны: ");
                    var name = Console.ReadLine();

                    Console.Write("Код страны (2 буквы, например RU): ");
                    var code = Console.ReadLine();

                    var country = new Country
                    {
                        Name = name,
                        CountryCode = code
                    };

                    context.Countries.Add(country);
                    context.SaveChanges();

                    Console.WriteLine($"Страна '{name}' добавлена с ID: {country.Id}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }
        }

        static void ShowAllCountries()
        {
            try
            {
                using (var context = new MailingDbContext())
                {
                    var countries = context.Countries.ToList();

                    if (!countries.Any())
                    {
                        Console.WriteLine("❌ Страны не найдены");
                        return;
                    }

                    Console.WriteLine($"{"ID"}   {"Название"}   {"Код"  }");
                    Console.WriteLine(new string('-', 50));

                    foreach (var country in countries)
                    {
                        var cityCount = context.Cities.Count(c => c.CountryId == country.Id);
                        Console.WriteLine($"{country.Id}   {country.Name}   {country.CountryCode}");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }
        }

        static void UpdateCountry()
        {
            Console.WriteLine("=== Обновление страны ===");

            try
            {
                using (var context = new MailingDbContext())
                {
                    Console.Write("Введите ID страны для обновления: ");
                    if (!int.TryParse(Console.ReadLine(), out int id))
                    {
                        Console.WriteLine("Неверный ID");
                        return;
                    }

                    var country = context.Countries.Find(id);
                    if (country == null)
                    {
                        Console.WriteLine("❌ Страна не найдена");
                        return;
                    }

                    Console.WriteLine($"Текущие данные: {country.Name}, {country.CountryCode}");
                    Console.WriteLine("Оставьте поле пустым, чтобы не изменять значение");

                    Console.Write($"Новое название [{country.Name}]: ");
                    var newName = Console.ReadLine();
                    if (!string.IsNullOrWhiteSpace(newName))
                        country.Name = newName;

                    Console.Write($"Новый код [{country.CountryCode}]: ");
                    var newCode = Console.ReadLine();
                    if (!string.IsNullOrWhiteSpace(newCode))
                        country.CountryCode = newCode;

                    context.SaveChanges();
                    Console.WriteLine("Данные страны обновлены");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }
        }

        static void DeleteCountry()
        {
            Console.WriteLine("=== Удаление страны ===");
            Console.WriteLine("Внимание: Будут также удалены все города и промоакции этой страны!");

            try
            {
                using (var context = new MailingDbContext())
                {
                    Console.Write("Введите ID страны для удаления: ");
                    if (!int.TryParse(Console.ReadLine(), out int id))
                    {
                        Console.WriteLine("Неверный ID");
                        return;
                    }

                    var country = context.Countries.Find(id);
                    if (country == null)
                    {
                        Console.WriteLine("Страна не найдена");
                        return;
                    }

                    var cities = context.Cities.Where(c => c.CountryId == id).ToList();
                    if (cities.Any())
                    {
                        context.Cities.RemoveRange(cities);
                    }

                    var promotions = context.Promotions.Where(p => p.CountryId == id).ToList();
                    if (promotions.Any())
                    {
                        context.Promotions.RemoveRange(promotions);
                    }

                    var subscribers = context.Subscribers.Where(s => s.CountryId == id).ToList();
                    foreach (var subscriber in subscribers)
                    {
                        subscriber.CountryId = 0;
                    }

                    context.Countries.Remove(country);
                    context.SaveChanges();

                    Console.WriteLine($"Страна '{country.Name}' и все связанные данные удалены");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }
        }
        #endregion

        #region Управление городами (Задание 1, 2, 3)
        static void ManageCitiesMenu()
        {
            Console.WriteLine("\n=== Управление городами ===");
            Console.WriteLine("1. Добавить город");
            Console.WriteLine("2. Показать все города");
            Console.WriteLine("3. Обновить город");
            Console.WriteLine("4. Удалить город");
            Console.WriteLine("0. Назад");
            Console.Write("Выберите: ");

            var choice = Console.ReadLine();
            Console.WriteLine();

            switch (choice)
            {
                case "1":
                    AddCity();
                    break;
                case "2":
                    ShowAllCities();
                    break;
                case "3":
                    UpdateCity();
                    break;
                case "4":
                    DeleteCity();
                    break;
            }
        }

        static void AddCity()
        {
            Console.WriteLine("=== Добавление нового города ===");

            try
            {
                using (var context = new MailingDbContext())
                {
                    var countries = context.Countries.ToList();
                    if (!countries.Any())
                    {
                        Console.WriteLine("Сначала добавьте страны");
                        return;
                    }

                    Console.WriteLine("Доступные страны:");
                    foreach (var country in countries)
                    {
                        Console.WriteLine($"{country.Id}. {country.Name}");
                    }

                    Console.Write("Выберите ID страны: ");
                    if (!int.TryParse(Console.ReadLine(), out int countryId))
                    {
                        Console.WriteLine("Неверный ID");
                        return;
                    }

                    Console.Write("Название города: ");
                    var name = Console.ReadLine();

                    var city = new City
                    {
                        Name = name,
                        CountryId = countryId
                    };

                    context.Cities.Add(city);
                    context.SaveChanges();

                    Console.WriteLine($"Город '{name}' добавлен с ID: {city.Id}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }
        }

        static void ShowAllCities()
        {
            try
            {
                using (var context = new MailingDbContext())
                {
                    var cities = context.Cities
                        .Include(c => c.Country)
                        .ToList();

                    if (!cities.Any())
                    {
                        Console.WriteLine("Города не найдены");
                        return;
                    }

                    Console.WriteLine($"{"ID"} {"Название"} {"Страна"}");
                    Console.WriteLine(new string('-', 60)); 

                    foreach (var city in cities)
                    {
                        var subscriberCount = context.Subscribers.Count(s => s.CityId == city.Id);
                        Console.WriteLine($"{city.Id} {city.Name} {city.Country?.Name}");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }
        }

        static void UpdateCity()
        {
            Console.WriteLine("=== Обновление города ===");

            try
            {
                using (var context = new MailingDbContext())
                {
                    Console.Write("Введите ID города для обновления: ");
                    if (!int.TryParse(Console.ReadLine(), out int id))
                    {
                        Console.WriteLine("Неверный ID");
                        return;
                    }

                    var city = context.Cities.Find(id);
                    if (city == null)
                    {
                        Console.WriteLine("Город не найден");
                        return;
                    }

                    Console.WriteLine($"Текущие данные: {city.Name}");
                    Console.Write("Новое название: ");
                    var newName = Console.ReadLine();

                    if (!string.IsNullOrWhiteSpace(newName))
                    {
                        city.Name = newName;
                        context.SaveChanges();
                        Console.WriteLine("Название города обновлено");
                    }
                    else
                    {
                        Console.WriteLine("Название не может быть пустым");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }
        }

        static void DeleteCity()
        {
            Console.WriteLine("=== Удаление города ===");

            try
            {
                using (var context = new MailingDbContext())
                {
                    Console.Write("Введите ID города для удаления: ");
                    if (!int.TryParse(Console.ReadLine(), out int id))
                    {
                        Console.WriteLine("Неверный ID");
                        return;
                    }

                    var city = context.Cities.Find(id);
                    if (city == null)
                    {
                        Console.WriteLine("❌ Город не найден");
                        return;
                    }

                    var subscribers = context.Subscribers.Where(s => s.CityId == id).ToList();
                    foreach (var subscriber in subscribers)
                    {
                        subscriber.CityId = 0;
                    }

                    context.Cities.Remove(city);
                    context.SaveChanges();

                    Console.WriteLine($"Город '{city.Name}' удален");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }
        }
        #endregion

        #region Управление разделами (Задание 1, 2, 3)
        static void ManageCategoriesMenu()
        {
            Console.WriteLine("\n=== Управление разделами ===");
            Console.WriteLine("1. Добавить раздел");
            Console.WriteLine("2. Показать все разделы");
            Console.WriteLine("3. Обновить раздел");
            Console.WriteLine("4. Удалить раздел");
            Console.WriteLine("0. Назад");
            Console.Write("Выберите: ");

            var choice = Console.ReadLine();
            Console.WriteLine();

            switch (choice)
            {
                case "1":
                    AddCategory();
                    break;
                case "2":
                    ShowAllCategories();
                    break;
                case "3":
                    UpdateCategory();
                    break;
                case "4":
                    DeleteCategory();
                    break;
            }
        }

        static void AddCategory()
        {
            Console.WriteLine("=== Добавление нового раздела ===");

            try
            {
                using (var context = new MailingDbContext())
                {
                    Console.Write("Название раздела: ");
                    var name = Console.ReadLine();

                    Console.Write("Описание: ");
                    var description = Console.ReadLine();

                    var category = new Category
                    {
                        Name = name,
                        Description = description
                    };

                    context.Categories.Add(category);
                    context.SaveChanges();

                    Console.WriteLine($"Раздел '{name}' добавлен с ID: {category.Id}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }
        }

        static void ShowAllCategories()
        {
            try
            {
                using (var context = new MailingDbContext())
                {
                    var categories = context.Categories.ToList();

                    if (!categories.Any())
                    {
                        Console.WriteLine("Разделы не найдены");
                        return;
                    }

                    Console.WriteLine($"{"ID"} {"Название"} {"Описание"}");
                    Console.WriteLine(new string('-', 75));

                    foreach (var category in categories)
                    {
                        var subscriberCount = context.SubscriberCategories.Count(sc => sc.CategoryId == category.Id);
                        Console.WriteLine($"{category.Id} {category.Name} {category.Description}");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }
        }

        static void UpdateCategory()
        {
            Console.WriteLine("=== Обновление раздела ===");

            try
            {
                using (var context = new MailingDbContext())
                {
                    Console.Write("Введите ID раздела для обновления: ");
                    if (!int.TryParse(Console.ReadLine(), out int id))
                    {
                        Console.WriteLine("Неверный ID");
                        return;
                    }

                    var category = context.Categories.Find(id);
                    if (category == null)
                    {
                        Console.WriteLine("Раздел не найден");
                        return;
                    }

                    Console.WriteLine($"Текущие данные: {category.Name}");
                    Console.WriteLine("Оставьте поле пустым, чтобы не изменять значение");

                    Console.Write($"Новое название [{category.Name}]: ");
                    var newName = Console.ReadLine();
                    if (!string.IsNullOrWhiteSpace(newName))
                        category.Name = newName;

                    Console.Write($"Новое описание [{category.Description}]: ");
                    var newDescription = Console.ReadLine();
                    if (!string.IsNullOrWhiteSpace(newDescription))
                        category.Description = newDescription;

                    context.SaveChanges();
                    Console.WriteLine("Данные раздела обновлены");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }
        }

        static void DeleteCategory()
        {
            Console.WriteLine("=== Удаление раздела ===");

            try
            {
                using (var context = new MailingDbContext())
                {
                    Console.Write("Введите ID раздела для удаления: ");
                    if (!int.TryParse(Console.ReadLine(), out int id))
                    {
                        Console.WriteLine("Неверный ID");
                        return;
                    }

                    var category = context.Categories.Find(id);
                    if (category == null)
                    {
                        Console.WriteLine("Раздел не найден");
                        return;
                    }

                    var subscriberCategories = context.SubscriberCategories
                        .Where(sc => sc.CategoryId == id)
                        .ToList();
                    context.SubscriberCategories.RemoveRange(subscriberCategories);

                    var promotions = context.Promotions.Where(p => p.CategoryId == id).ToList();
                    context.Promotions.RemoveRange(promotions);

                    context.Categories.Remove(category);
                    context.SaveChanges();

                    Console.WriteLine($"Раздел '{category.Name}' и все связанные данные удалены");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }
        }
        #endregion

        #region Управление акционными товарами (Задание 1, 2, 3)
        static void ManagePromotionsMenu()
        {
            Console.WriteLine("\n=== Управление акционными товарами ===");
            Console.WriteLine("1. Добавить акционный товар");
            Console.WriteLine("2. Показать все акционные товары");
            Console.WriteLine("3. Обновить акционный товар");
            Console.WriteLine("4. Удалить акционный товар");
            Console.WriteLine("0. Назад");
            Console.Write("Выберите: ");

            var choice = Console.ReadLine();
            Console.WriteLine();

            switch (choice)
            {
                case "1":
                    AddPromotion();
                    break;
                case "2":
                    ShowAllPromotions();
                    break;
                case "3":
                    UpdatePromotion();
                    break;
                case "4":
                    DeletePromotion();
                    break;
            }
        }

        static void AddPromotion()
        {
            Console.WriteLine("=== Добавление нового акционного товара ===");

            try
            {
                using (var context = new MailingDbContext())
                {
                    Console.Write("Название акции: ");
                    var title = Console.ReadLine();

                    Console.Write("Описание: ");
                    var description = Console.ReadLine();

                    var categories = context.Categories.ToList();
                    if (!categories.Any())
                    {
                        Console.WriteLine("Сначала добавьте категории");
                        return;
                    }

                    Console.WriteLine("\nДоступные категории:");
                    foreach (var category in categories)
                    {
                        Console.WriteLine($"{category.Id}. {category.Name}");
                    }

                    Console.Write("Выберите ID категории: ");
                    if (!int.TryParse(Console.ReadLine(), out int categoryId))
                    {
                        Console.WriteLine("Неверный ID");
                        return;
                    }

                    var countries = context.Countries.ToList();
                    if (!countries.Any())
                    {
                        Console.WriteLine("Сначала добавьте страны");
                        return;
                    }

                    Console.WriteLine("\nДоступные страны:");
                    foreach (var country in countries)
                    {
                        Console.WriteLine($"{country.Id}. {country.Name}");
                    }

                    Console.Write("Выберите ID страны: ");
                    if (!int.TryParse(Console.ReadLine(), out int countryId))
                    {
                        Console.WriteLine("Неверный ID");
                        return;
                    }

                    Console.Write("Дата начала (гггг-мм-дд): ");
                    if (!DateTime.TryParse(Console.ReadLine(), out var startDate))
                    {
                        Console.WriteLine("Неверный формат даты");
                        return;
                    }

                    Console.Write("Дата окончания (гггг-мм-дд): ");
                    if (!DateTime.TryParse(Console.ReadLine(), out var endDate))
                    {
                        Console.WriteLine("Неверный формат даты");
                        return;
                    }

                    Console.Write("Процент скидки: ");
                    if (!decimal.TryParse(Console.ReadLine(), out var discount))
                    {
                        Console.WriteLine("Неверный формат числа");
                        return;
                    }

                    Console.Write("Промокод (не обязательно): ");
                    var promoCode = Console.ReadLine();

                    var promotion = new Promotion
                    {
                        Title = title,
                        Description = description,
                        CategoryId = categoryId,
                        CountryId = countryId,
                        StartDate = startDate,
                        EndDate = endDate,
                        DiscountPercentage = discount,
                        PromoCode = promoCode,
                        IsActive = true
                    };

                    context.Promotions.Add(promotion);
                    context.SaveChanges();

                    Console.WriteLine($"Акция '{title}' добавлена с ID: {promotion.Id}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }
        }

        static void ShowAllPromotions()
        {
            try
            {
                using (var context = new MailingDbContext())
                {
                    var promotions = context.Promotions
                        .Include(p => p.Category)
                        .Include(p => p.Country)
                        .ToList();

                    if (!promotions.Any())
                    {
                        Console.WriteLine("Акционные товары не найдены");
                        return;
                    }

                    Console.WriteLine($"{"ID"} {"Название"} {"Категория"} {"Страна"} {"Скидка"} {"Активна"}");
                    Console.WriteLine(new string('-', 90));

                    foreach (var promotion in promotions)
                    {
                        var isActive = promotion.IsActive && promotion.EndDate >= DateTime.Now;
                        var activeStatus = isActive ? "Да" : "Нет";
                        Console.WriteLine($"{promotion.Id} {promotion.Title} {promotion.Category?.Name} {promotion.Country?.Name} {promotion.DiscountPercentage + "%"} {activeStatus}");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }
        }

        static void UpdatePromotion()
        {
            Console.WriteLine("=== Обновление акционного товара ===");

            try
            {
                using (var context = new MailingDbContext())
                {
                    Console.Write("Введите ID акции для обновления: ");
                    if (!int.TryParse(Console.ReadLine(), out int id))
                    {
                        Console.WriteLine("Неверный ID");
                        return;
                    }

                    var promotion = context.Promotions.Find(id);
                    if (promotion == null)
                    {
                        Console.WriteLine("Акция не найдена");
                        return;
                    }

                    Console.WriteLine($"Текущие данные: {promotion.Title}");
                    Console.WriteLine("Оставьте поле пустым, чтобы не изменять значение");

                    Console.Write($"Новое название [{promotion.Title}]: ");
                    var newTitle = Console.ReadLine();
                    if (!string.IsNullOrWhiteSpace(newTitle))
                        promotion.Title = newTitle;

                    Console.Write($"Новое описание [{promotion.Description}]: ");
                    var newDescription = Console.ReadLine();
                    if (!string.IsNullOrWhiteSpace(newDescription))
                        promotion.Description = newDescription;

                    Console.Write($"Новая скидка [{promotion.DiscountPercentage}]: ");
                    var discountInput = Console.ReadLine();
                    if (!string.IsNullOrWhiteSpace(discountInput) && decimal.TryParse(discountInput, out var newDiscount))
                        promotion.DiscountPercentage = newDiscount;

                    context.SaveChanges();
                    Console.WriteLine("Данные акции обновлены");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }
        }

        static void DeletePromotion()
        {
            Console.WriteLine("=== Удаление акционного товара ===");

            try
            {
                using (var context = new MailingDbContext())
                {
                    Console.Write("Введите ID акции для удаления: ");
                    if (!int.TryParse(Console.ReadLine(), out int id))
                    {
                        Console.WriteLine("Неверный ID");
                        return;
                    }

                    var promotion = context.Promotions.Find(id);
                    if (promotion == null)
                    {
                        Console.WriteLine("Акция не найдена");
                        return;
                    }

                    context.Promotions.Remove(promotion);
                    context.SaveChanges();

                    Console.WriteLine($"Акция '{promotion.Title}' удалена");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }
        }
        #endregion

        #region Просмотр информации (Задание 4)
        static void ShowInformationMenu()
        {
            Console.WriteLine("\n=== Просмотр информации ===");
            Console.WriteLine("1. Города конкретной страны");
            Console.WriteLine("2. Разделы конкретного покупателя");
            Console.WriteLine("3. Акционные товары конкретного раздела");
            Console.WriteLine("0. Назад");
            Console.Write("Выберите: ");

            var choice = Console.ReadLine();
            Console.WriteLine();

            switch (choice)
            {
                case "1":
                    ShowCitiesByCountry();
                    break;
                case "2":
                    ShowCategoriesBySubscriber();
                    break;
                case "3":
                    ShowPromotionsByCategory();
                    break;
            }
        }

        static void ShowCitiesByCountry()
        {
            Console.WriteLine("=== Города конкретной страны ===");

            try
            {
                using (var context = new MailingDbContext())
                {
                   
                    var countries = context.Countries.ToList();
                    if (!countries.Any())
                    {
                        Console.WriteLine("Нет стран");
                        return;
                    }

                    Console.WriteLine("Доступные страны:");
                    foreach (var country in countries)
                    {
                        Console.WriteLine($"{country.Id}. {country.Name}");
                    }

                    Console.Write("Выберите ID страны: ");
                    if (!int.TryParse(Console.ReadLine(), out int countryId))
                    {
                        Console.WriteLine("Неверный ID");
                        return;
                    }

                    var cities = context.Cities
                        .Where(c => c.CountryId == countryId)
                        .Include(c => c.Country)
                        .ToList();

                    var countryName = context.Countries.Find(countryId)?.Name;

                    if (!cities.Any())
                    {
                        Console.WriteLine($"В стране '{countryName}' нет городов");
                        return;
                    }

                    Console.WriteLine($"\nГорода страны '{countryName}':");
                    Console.WriteLine($"{"ID"} {"Название"} {"Покупателей"}");
                    Console.WriteLine(new string('-', 40));

                    foreach (var city in cities)
                    {
                        var subscriberCount = context.Subscribers.Count(s => s.CityId == city.Id);
                        Console.WriteLine($"{city.Id} {city.Name} {subscriberCount}");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }
        }

        static void ShowCategoriesBySubscriber()
        {
            Console.WriteLine("=== Разделы конкретного покупателя ===");

            try
            {
                using (var context = new MailingDbContext())
                {
                    
                    var subscribers = context.Subscribers.ToList();
                    if (!subscribers.Any())
                    {
                        Console.WriteLine("Нет покупателей");
                        return;
                    }

                    Console.WriteLine("Покупатели:");
                    foreach (var subscriber in subscribers)
                    {
                        Console.WriteLine($"{subscriber.Id}. {subscriber.FullName}");
                    }

                    Console.Write("Выберите ID покупателя: ");
                    if (!int.TryParse(Console.ReadLine(), out int subscriberId))
                    {
                        Console.WriteLine("Неверный ID");
                        return;
                    }

                    var categories = context.SubscriberCategories
                        .Where(sc => sc.SubscriberId == subscriberId)
                        .Include(sc => sc.Category)
                        .Select(sc => sc.Category)
                        .ToList();

                    var subscriberName = context.Subscribers.Find(subscriberId)?.FullName;

                    if (!categories.Any())
                    {
                        Console.WriteLine($"У покупателя '{subscriberName}' нет выбранных разделов");
                        return;
                    }

                    Console.WriteLine($"\nРазделы покупателя '{subscriberName}':");
                    Console.WriteLine($"{"ID"} {"Название"} {"Описание"}");
                    Console.WriteLine(new string('-', 65));

                    foreach (var category in categories)
                    {
                        Console.WriteLine($"{category.Id} {category.Name} {category.Description}");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }
        }

        static void ShowPromotionsByCategory()
        {
            Console.WriteLine("=== Акционные товары конкретного раздела ===");

            try
            {
                using (var context = new MailingDbContext())
                {
      
                    var categories = context.Categories.ToList();
                    if (!categories.Any())
                    {
                        Console.WriteLine("Нет категорий");
                        return;
                    }

                    Console.WriteLine("Доступные категории:");
                    foreach (var category in categories)
                    {
                        Console.WriteLine($"{category.Id}. {category.Name}");
                    }

                    Console.Write("Выберите ID категории: ");
                    if (!int.TryParse(Console.ReadLine(), out int categoryId))
                    {
                        Console.WriteLine("Неверный ID");
                        return;
                    }

                    var promotions = context.Promotions
                        .Where(p => p.CategoryId == categoryId)
                        .Include(p => p.Country)
                        .Include(p => p.Category)
                        .ToList();

                    var categoryName = context.Categories.Find(categoryId)?.Name;

                    if (!promotions.Any())
                    {
                        Console.WriteLine($"В разделе '{categoryName}' нет акционных товаров");
                        return;
                    }

                    Console.WriteLine($"\nАкционные товары раздела '{categoryName}':");
                    Console.WriteLine($"{"ID"} {"Название"} {"Страна"} {"Скидка"} {"Дата начала"} {"Дата окончания"}");
                    Console.WriteLine(new string('-', 90));

                    foreach (var promotion in promotions)
                    {
                        Console.WriteLine($"{promotion.Id} {promotion.Title} {promotion.Country?.Name} {promotion.DiscountPercentage + "%"} {promotion.StartDate:yyyy-MM-dd} {promotion.EndDate:yyyy-MM-dd}");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }
        }
        #endregion
    }
}