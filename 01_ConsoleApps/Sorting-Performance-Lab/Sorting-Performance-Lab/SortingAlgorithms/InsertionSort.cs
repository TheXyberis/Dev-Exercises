using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorting_Performance_Lab.SortingAlgorithms
{
    internal class InsertionSort
    {
        public static void Sort(int[] array)
        {
            int n = array.Length;
            for (int i = 1; i < n; i++)
            {
                int key = array[i]; // This is the card we just picked up.
                int j = i - 1; // This is the index of the card immediately to its left.
                while (j >= 0 && array[j] > key)
                {
                    array[j + 1] = array[j]; // Move the bigger card one slot to the right.
                    j--; // Look at the next card to the left.
                }
                array[j + 1] = key; // Now that you've created a gap, you drop your key into that hole.
            }
        }
    }
}
