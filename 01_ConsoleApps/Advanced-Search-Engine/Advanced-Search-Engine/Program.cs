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

            //Binary
            Console.WriteLine("\nEnter book title to search (binary search): ");
            string searchTitle = Console.ReadLine();
            int binaryIndex = BinarySearchBooks.Search(books, searchTitle);
            if (binaryIndex >= 0)
            {
                Console.WriteLine($"\nFound: {books[binaryIndex]} at index {binaryIndex}");
            }
            else
            {
                Console.WriteLine("\nBook not found.");
            }

            //Linear
            Console.WriteLine("\nLinear search example (int list): ");
            List<string> names = new List<string> { "Alice", "Bob", "Carol", "Dave" };
            Console.WriteLine("Enter name to find: ");
            string targetName = Console.ReadLine();
            int linearIndex = LinearSearch.Search(names, targetName);
            if(linearIndex >= 0)
            {
                Console.WriteLine($"Found {targetName} at index {linearIndex}");
            }
            else
            {
                Console.WriteLine($"{targetName} not found");
            }

            //Sentinel
            Console.WriteLine("\nSentinel search example (int list): ");
            List<int> numbers = new List<int> { 10, 22, 67, 52, 69, 101, 16, 91, 76 };
            Console.WriteLine("Enter number to find: ");
            int targetNumber = int.Parse(Console.ReadLine());
            int sentinelIndex = SentinelSearch.Search(numbers, targetNumber);
            if(sentinelIndex >= 0)
            {
                Console.WriteLine($"Found {targetNumber} at index {sentinelIndex}");
            }
            else
            {
                Console.WriteLine($"{targetNumber} not found");
            }

            Console.ReadKey();
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
