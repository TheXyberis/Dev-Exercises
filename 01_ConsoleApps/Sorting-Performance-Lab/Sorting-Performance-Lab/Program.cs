using Sorting_Performance_Lab.SortingAlgorithms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Sorting_Performance_Lab
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Enter size of array: ");
            int size = int.Parse(Console.ReadLine());
            int[] original = SortingDataGenerator.GenerateRandomArray(size);

            Console.WriteLine("\nOriginal array: ");
            PrintArray(original);

            Console.WriteLine($"Sorting comparison for {size} elements: \n");

            RunSort("BubbleSort", original, BubbleSort.Sort);
            RunSort("SelectionSort", original, SelectionSort.Sort);
            RunSort("InsertionSort", original, InsertionSort.Sort);
            RunSort("QuickSort", original, arr => QuickSort.Sort(arr, 0, arr.Length - 1));

            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }

        static void RunSort(string name, int[] array, Action<int[]> sortMethod)
        {
            int[] copy = (int[])array.Clone();
            Stopwatch sw = Stopwatch.StartNew();
            sortMethod(copy);
            sw.Stop();

            Console.WriteLine($"{name.PadRight(15)}: {sw.ElapsedMilliseconds} ms");
            Console.WriteLine("Sorted array");
            PrintArray(copy);
            Console.WriteLine(new string('-', 50));
        }

        static void PrintArray(int[] array, int maxLength = 20)
        {
            if (array.Length <= maxLength)
            {
                Console.WriteLine(string.Join(", ", array));
            }
            else
            {
                for (int i = 0; i < 10; i++) Console.WriteLine(array[i] + ", ");
                Console.WriteLine("... , ");
                for (int i = array.Length - 10; i < array.Length; i++) Console.WriteLine(array[i] + (i == array.Length - 1 ? "\n" : ", "));
            }
        }
    }
}
