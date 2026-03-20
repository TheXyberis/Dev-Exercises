using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorting_Performance_Lab.SortingAlgorithms
{
    internal class QuickSort
    {
        public static void Sort(int[] array, int left, int right)
        {
            int pivot = array[(left + right) / 2];
            int i = left;
            int j = right;
            while (i < j)
            {
                while (array[i] < pivot)
                {
                    i++;
                }
                while (array[j] > pivot)
                {
                    j--;
                }
                if (i <= j) // If the scouts found items that are on the WRONG sides...
                {
                    int temp = array[i];
                    array[i] = array[j];
                    array[j] = temp;
                    i++; // Move scouts inward
                    j--;
                }
            }

            // Divide and Conquer
            if (left < j)
            {
                Sort(array, left, j); // Sort the "Left Team" (smaller items)
            }
            if (i < right)
            {
                Sort(array, i, right); // Sort the "Right Team" (larger items)
            }
        }
    }
}
