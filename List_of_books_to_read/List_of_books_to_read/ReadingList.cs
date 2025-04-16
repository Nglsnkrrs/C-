using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace List_of_books_to_read
{
    public class ReadingList
    {
        private List<string> books = new List<string>();
        public int Count => books.Count;
        public string this[int index]
        {
            get
            {
                if (index >= 0 && index < books.Count)
                    return books[index];
                else
                    throw new IndexOutOfRangeException("No book with this index was found.");
            }
            set
            {
                if (index >= 0 && index < books.Count)
                    books[index] = value;
                else
                    throw new IndexOutOfRangeException("No book with this index was found.");
            }
        }
        public bool Contains(string book)
        {
            return books.Contains(book);
        }
        public static ReadingList operator +(ReadingList list, string book)
        {
            if (!list.Contains(book))
            {
                list.books.Add(book);
                Console.WriteLine("The book has been added");
            }
            else
                Console.WriteLine($"The book \"{book}\" has already been added.");
            return list;
        }

        public static ReadingList operator -(ReadingList list, string book)
        {
            if (list.Contains(book))
            {
                list.books.Remove(book);
                Console.WriteLine("The book was deleted");
            }
            else
                Console.WriteLine($"The book \"{book}\" was not found in the list.");
            return list;
        }

        public void PrintList()
        {
            if (books.Count == 0)
            {
                Console.WriteLine("The list is empty.");
                return;
            }
    
            for (int i = 0; i < books.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {books[i]}");
            }
        }
    }
}
