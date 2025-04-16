using Microsoft.VisualBasic;

namespace List_of_books_to_read
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ReadingList list = new ReadingList();
            string NameBook;

            while (true) 
            {
                Console.WriteLine("Menu");
                Console.WriteLine("1. Add Book");
                Console.WriteLine("2. Delete Book");
                Console.WriteLine("3. Check the book availability");
                Console.WriteLine("4. Get a book by index");
                Console.WriteLine("5. Print all list");
                Console.Write("Your choice: ");
                int choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        Console.Write("Enter the number of books to add: ");
                        int count = Convert.ToInt32(Console.ReadLine());

                        for (int i = 0; i < count; i++)
                        {
                            Console.Write($"Enter a title for {i + 1} books: ");
                            NameBook = Console.ReadLine();
                            list += NameBook;
                        }
                        Console.WriteLine();
                        break;
                    case 2:
                        Console.Write("Enter the name of the book to delete: ");
                        NameBook = Console.ReadLine();
                        list -= NameBook;
                        Console.WriteLine();
                        break;
                    case 3:
                        Console.Write("Enter the name of the book to check for availability: ");
                        NameBook = Console.ReadLine();
                        Console.WriteLine(list.Contains(NameBook) ? "The book has been found" : "The book was not found");
                        Console.WriteLine();
                        break;
                    case 4:
                        Console.Write("Enter the index to get the book title: ");
                        int index = Convert.ToInt32(Console.ReadLine());
                        try
                        {
                            Console.WriteLine($"Book: {list[index]}");
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }
                        Console.WriteLine();
                        break;
                    case 5:
                        Console.WriteLine("List of books to read");
                        list.PrintList();
                        Console.WriteLine();
                        break;
                }
            }
        }
    }
}
