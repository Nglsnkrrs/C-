using System;
using Product_accounting_system.Data;
using Product_accounting_system.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Product_accounting_system
{
    class Program
    {
        static void Main(string[] args)
        {
            using var context = new AppDbContext();
            context.Database.EnsureCreated();

            bool exit = false;

            while (!exit)
            {
                ShowMenu();

                var input = Console.ReadLine();
                Console.WriteLine(); 

                switch (input)
                {
                    case "1":
                        AddCategory();
                        break;
                    case "2":
                        AddProduct();
                        break;
                    case "3":
                        ShowProducts();
                        break;
                    case "4":
                        DeleteProduct();
                        break;
                    case "0":
                        exit = true;
                        Console.WriteLine("Выход из программы...");
                        break;
                    default:
                        Console.WriteLine("Неверная команда!");
                        break;
                }

                Console.WriteLine(); 
            }
        }

        static void ShowMenu()
        {
            Console.WriteLine("=== Система учета товаров ===");
            Console.WriteLine("1 - Добавить категорию");
            Console.WriteLine("2 - Добавить товар");
            Console.WriteLine("3 - Показать товары");
            Console.WriteLine("4 - Удалить товар");
            Console.WriteLine("0 - Выход");
            Console.Write("Выберите команду: ");
        }

        static void AddCategory()
        {
            Console.WriteLine("=== Добавление категории ===");
            Console.Write("Введите название категории: ");
            var name = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(name))
            {
                Console.WriteLine("Ошибка: Название категории не может быть пустым!");
                return;
            }

            using (var context = new AppDbContext())
            {
                var category = new Category { Name = name };
                context.Categories.Add(category);
                context.SaveChanges();

                Console.WriteLine($"Категория '{name}' добавлена с ID: {category.Id}");
            }
        }

        static void AddProduct()
        {
            Console.WriteLine("=== Добавление товара ===");

            Console.Write("Введите название товара: ");
            var name = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(name))
            {
                Console.WriteLine("Ошибка: Название товара не может быть пустым!");
                return;
            }

            decimal price;
            Console.Write("Введите цену товара: ");
            while (!decimal.TryParse(Console.ReadLine(), out price) || price <= 0)
            {
                Console.Write("Некорректная цена. Введите положительное число: ");
            }

            int categoryId;
            Console.Write("Введите ID категории: ");
            while (!int.TryParse(Console.ReadLine(), out categoryId))
            {
                Console.Write("Некорректный ID. Введите число: ");
            }

            using (var context = new AppDbContext())
            {
               
                var category = context.Categories.Find(categoryId);
                if (category == null)
                {
                    Console.WriteLine($"Категория с ID {categoryId} не найдена!");
                    return;
                }

                var product = new Product
                {
                    Name = name,
                    Price = price,
                    CategryId = categoryId,
                    IsDeleted = false
                };

                context.Products.Add(product);
                context.SaveChanges();

                Console.WriteLine($"Товар '{name}' добавлен с ID: {product.Id}");
            }
        }

        static void ShowProducts()
        {
            Console.WriteLine("=== Список товаров ===");

            using (var context = new AppDbContext())
            {
                
                var products = context.Products
                    .Include(p => p.Category)
                    .Where(p => !p.IsDeleted) 
                    .ToList();

                if (!products.Any())
                {
                    Console.WriteLine("Товары не найдены.");
                }
                else
                {
                    Console.WriteLine($"{"ID"} {"Название"} {"Цена"} {"Категория"}");
                    Console.WriteLine(new string('-', 80));

                    foreach (var product in products)
                    {
                        Console.WriteLine($"{product.Id} {product.Name} {product.Price:C2} {product.Category?.Name ?? "Нет категории"}");
                    }
                }
            }
        }

        static void DeleteProduct()
        {
            Console.WriteLine("=== Удаление товара ===");

            int productId;
            Console.Write("Введите ID товара для удаления: ");
            while (!int.TryParse(Console.ReadLine(), out productId))
            {
                Console.Write("Некорректный ID. Введите число: ");
            }

            using (var context = new AppDbContext())
            {
                var product = context.Products.Find(productId);

                if (product == null)
                {
                    Console.WriteLine($"Товар с ID {productId} не найден!");
                }
                else if (product.IsDeleted)
                {
                    Console.WriteLine($"⚠Товар с ID {productId} уже удален!");
                }
                else
                {
                    product.IsDeleted = true;
                    context.SaveChanges();
                    Console.WriteLine($"Товар '{product.Name}' (ID: {product.Id}) помечен как удаленный.");
                }
            }
        }
    }
}