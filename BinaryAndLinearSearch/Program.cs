using System;
using System.Diagnostics;

namespace BinarySearch
{
    class BinaryAndLinearSearch
    {
        private static int[] _numbers;

        private static Random _random = new Random();

        private static int _target;

        static BinaryAndLinearSearch()
        {
            int size = _random.Next(1000, 100_000);

            _numbers = new int[size];

            for (int i = 0; i < _numbers.Length; i++)
            {
                _numbers[i] = _random.Next(1, 5000);
            }

            Array.Sort(_numbers);
            
            _target = _numbers[_random.Next(_numbers.Length)];
        }

        /// <summary>
        /// Binary search.
        /// </summary>
        /// <param name="target">Number to find.</param>
        /// <returns>Number. -1 if number was not found.</returns>
        private static int BinarySearch(int target)
        {
            int low = 0;
            int high = _numbers.Length - 1;

            while (low <= high)
            {
                int mid = (low + high) / 2;
                int guess = _numbers[mid];

                if (guess < target)
                {
                    low = mid + 1;
                }
                else if (guess > target)
                {
                    high = mid - 1;
                }
                else
                {
                    return guess;
                }
            }

            return -1;
        }

        /// <summary>
        /// Linear Search
        /// </summary>
        /// <param name="target">Number to find.</param>
        /// <returns>Number. -1 if number was not found.</returns>
        private static int LinearSearch(int target)
        {
            foreach (int number in _numbers)
            {
                if (number == target)
                {
                    return number;
                }
            }

            return -1;
        }

        private static void Main(string[] args)
        {
            TimeSpan ts;
            
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            int indexBinary = BinarySearch(_target);
            stopwatch.Stop();
            ts = stopwatch.Elapsed;
            Console.WriteLine($"Binary search: {ts}\nIndex: {indexBinary}\n" +
                              $"Number: {_numbers[indexBinary]}");

            Console.WriteLine();
            
            stopwatch.Start();
            int indexLinear = LinearSearch(_target);
            stopwatch.Stop();
            ts = stopwatch.Elapsed;
            Console.WriteLine($"Linear search: {ts}\nIndex: {indexLinear}\n" +
                              $"Number: {_numbers[indexLinear]}");
        }
    }
}