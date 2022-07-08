using System;
using System.Collections.Immutable;
using System.Linq;

namespace SortingAlgorithms
{
    class Program
    {
        private static Random _random = new Random();

        static void Main(string[] args)
        {
            // Array generation
            int[] array = new int[_random.Next(10, 20)];

            for (int i = 0; i < array.Length; i++)
            {
                array[i] = _random.Next(20);
            }

            Console.WriteLine("Generated array:");
            PrintArray(array);

            Console.WriteLine("Sorted:");

            #region Selection Sort
            
            // SelectionSort selectionSort = new SelectionSort();
            // PrintArray(selectionSort.SelectionSortArray(array));

            #endregion

            #region Quick Sort

            // QuickSort quickSort = new QuickSort();
            // PrintArray(quickSort.Sort(array.ToList()).ToArray());

            #endregion
        }

        private static void PrintArray<T>(T[] array)
        {
            foreach (T element in array)
            {
                Console.Write($"{element} ");
            }

            Console.WriteLine();
        }
    }
}