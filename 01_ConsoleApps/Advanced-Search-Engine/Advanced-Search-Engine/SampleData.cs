using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Advanced_Search_Engine.Models;

namespace Advanced_Search_Engine
{
    public static class SampleData
    {
        public static List<Book> Books = new List<Book>
        {
            new Book {Title = "Clean Code", Author = "Robert C. Martin"},
            new Book { Title = "The Pragmatic Programmer", Author = "Andrew Hunt" },
            new Book { Title = "Algorithms Unlocked", Author = "Thomas H. Cormen" },
            new Book { Title = "C# in Depth", Author = "Jon Skeet" },
            new Book { Title = "Design Patterns", Author = "Erich Gamma" }
        };
    }
}
