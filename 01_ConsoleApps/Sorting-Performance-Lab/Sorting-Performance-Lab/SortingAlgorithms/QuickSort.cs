using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorting_Performance_Lab.SortingAlgorithms
{
    internal class QuickSort
    {
        static void Sort(int[] array, int left, int right)
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
                if (i <= j)
                {
                    int temp = array[i];
                    array[i] = array[j];
                    array[j] = temp;
                    i++;
                    j--;
                }           
            }
            if (left < j)
            {
                Sort(array, left, j);
            }
            if (i < right)
            {
                Sort(array, i, right);
            }
        }
    }
}
