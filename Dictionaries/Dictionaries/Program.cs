using System.Globalization;

namespace Dictionaries
{
    public class Program
    {
        static void Main(string[] args)
        {
            Add_Dictionary add_Dictionary = new Add_Dictionary();
            string name,word;

            while (true) 
            {
                Console.WriteLine("Menu");
                Console.WriteLine("1. Create new dictionary");
                Console.WriteLine("2. Print all file in directory");
                Console.WriteLine("3. Add new word");
                Console.WriteLine("4. Delete word");
                Console.WriteLine("5. Search translate");
                Console.WriteLine("6. Replace word");
                Console.Write("Your choice: ");
                Console.WriteLine("----------------------------");
                int choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        Console.Write("Please enter a dictionary name: ");
                        name = Console.ReadLine();
                        add_Dictionary.CreateNewDictionary(name);
                        Console.WriteLine("----------------------------");
                        break;
                    case 2:
                        add_Dictionary.PrintAllFile();
                        break;
                    case 3:
                        Console.Write("Please enter a dictionary name: ");
                        name = Console.ReadLine();
                        Console.Write("Enter the number of words to enter: ");
                        int countWords = Convert.ToInt32(Console.ReadLine());
                        add_Dictionary.AddWordInDictionary(name, countWords);
                        Console.WriteLine("----------------------------");
                        break;
                    case 4:
                        Console.Write("Please enter a dictionary name: ");
                        name = Console.ReadLine();
                        Console.Write("Enter the word to delete: ");
                        word = Console.ReadLine();
                        add_Dictionary.DeleteTranslate(name, word);
                        Console.WriteLine("----------------------------");
                        break;
                    case 5:
                        Console.Write("Please enter a dictionary name: ");
                        name = Console.ReadLine();
                        Console.Write("Enter the word to search: ");
                        word = Console.ReadLine();
                        add_Dictionary.SearchTranslate(name, word);
                        Console.WriteLine("----------------------------");
                        break;
                    case 6:
                        Console.Write("Please enter a dictionary name: ");
                        name = Console.ReadLine();
                        Console.Write("Enter the word to replace: ");
                        string wordToReplace = Console.ReadLine();
                        add_Dictionary.Replace(name, wordToReplace);
                        Console.WriteLine("----------------------------");
                        break;
                     case 7:
                        break;
                }
            }

        }
    }
}
