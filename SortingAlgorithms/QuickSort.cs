using System;
using System.Collections.Generic;
using System.Linq;

namespace SortingAlgorithms
{
    /// <summary>
    /// O(n*log(n))
    /// </summary>
    public class QuickSort
    {
        private static Random _random = new Random();
        
        public List<int> Sort(List<int> numbers)
        {
            if (numbers.Count <= 1) return numbers;

            // O(1)
            int pivotIndex = _random.Next(numbers.Count);
            int pivot = numbers[pivotIndex];
            numbers.RemoveAt(pivotIndex);

            List<int> less = new List<int>();
            List<int> greater = new List<int>();

            for (int i = 0; i < numbers.Count; i++)
            {
                if (numbers[i] < pivot)
                    less.Add(numbers[i]);
                else
                    greater.Add(numbers[i]);
            }

            List<int> sorted = Sort(less);
            sorted.Add(pivot);
            sorted.AddRange(Sort(greater));

            return sorted;
        }
    }
}