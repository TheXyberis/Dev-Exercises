using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorting_Performance_Lab.SortingAlgorithms
{
    internal class BubbleSort
    {
        public static void Sort(int[] array)
        {
            int n = array.Length; // 1. Get the total number of items.
            for (int i = 0; i < n - 1; i++) // 2. Outer loop: Counts how many passes we make.
            {
                for (int j = 0; j < n - i - 1; j++) // 3. Inner loop: Compares adjacent items.
                {
                    if (array[j] > array[j + 1]) // 4. If the left item is bigger than the right...
                    {
                        int temp = array[j]; // Keep the left value in a "temporary" box.
                        array[j] = array[j + 1]; // Move the right value to the left.
                        array[j + 1] = temp; // Move the "box" value to the right.
                    }
                }
            }
        }
    }
}

