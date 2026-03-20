using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorting_Performance_Lab
{
    internal class SortingDataGenerator
    {
        private static Random rand = new Random();

        public static int[] GenerateRandomArray(int size, int min = 0, int max = 100000)
        {
            int[] array = new int[size];
            for (int i = 0; i < size; i++)
            {
                array[i] = rand.Next(min, max);
            }
            return array;
        }
    }
}
