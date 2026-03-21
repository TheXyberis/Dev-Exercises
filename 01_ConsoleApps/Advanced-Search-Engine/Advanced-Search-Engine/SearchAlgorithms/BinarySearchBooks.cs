using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Advanced_Search_Engine.Models;

namespace Advanced_Search_Engine.SearchAlgorithms
{
    public static class BinarySearchBooks
    {
        public static int Search(List<Book> books, string targetTitle)
        {
            int left = 0; //start of the search range
            int right = books.Count - 1; //end of the search range

            while (left <= right)
            {
                int mid = (left + right) / 2;
                int comparison = books[mid].Title.CompareTo(targetTitle);
                if (comparison == 0)
                {
                    return mid;
                }
                else if (comparison < 0)
                {
                    left = mid + 1; // the target is further down the alphabet
                }
                else
                {
                    right = mid - 1; // the target is earlier in the alphabet
                }
            }
            return -1;
        }
    }
}
