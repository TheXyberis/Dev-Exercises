using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorting_Performance_Lab.SortingAlgorithms
{
    internal class SelectionSort
    {
        public static void Sort(int[] array)
        {
            int n = array.Length;
            for (int i = 0; i < n - 1; i++) // 1. Outer loop: Moves the boundary of the sorted part.
            {
                int minIndex = i; // 2. Assume the first unsorted item is the smallest for now.
                for (int j = i + 1; j < n; j++) // 3. Inner loop: Scan the REST of the array.
                {
                    if (array[j] < array[minIndex]) // 4. Did we find something even smaller?
                    {
                        minIndex = j; // 5. Update our "scout's" note: "The smallest is actually at position j!"
                    }
                }
                // 6. After scanning everything, swap the smallest found item with the first unsorted item.
                int temp = array[i];
                array[i] = array[minIndex];
                array[minIndex] = temp;
            }
        }
    }
}
