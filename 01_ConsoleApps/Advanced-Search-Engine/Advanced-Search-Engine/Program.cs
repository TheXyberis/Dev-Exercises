using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Advanced_Search_Engine.Models;
using Advanced_Search_Engine.SearchAlgorithms;

namespace Advanced_Search_Engine
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Advanced Search Enging Demo");
            Console.WriteLine(new string('-', 40));

            List<Book> books = SampleData.Books;

            Console.WriteLine("Original list of books: ");
            DisplayBooks(books);

            SortBooks(books);
            Console.WriteLine("\nBooks sorted by title");
            DisplayBooks(books);
        }

        public static void SortBooks(List<Book> books)
        {
            int n = books.Count;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n - i - 1; j++)
                {
                    //compare the first and the second book
                    if (books[j].Title.CompareTo(books[j + 1].Title) > 0)
                    {
                        Book temp = books[j];
                        books[j] = books[j + 1];
                        books[j + 1] = temp;
                    }
                }
            }
        }

        static void DisplayBooks(List<Book> books)
        {
            foreach (var book in books)
            {
                Console.WriteLine($" - {book}");
            }
        }
    }
}
