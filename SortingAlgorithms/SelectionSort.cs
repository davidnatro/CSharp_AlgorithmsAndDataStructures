using System;

namespace SortingAlgorithms
{
    /// <summary>
    /// O(n^2)
    /// </summary>
    public class SelectionSort
    {
        public int[] SelectionSortArray(int[] array)
        {
            int smallest, temp;

            for (int i = 0; i < array.Length; i++)
            {
                smallest = i;
                for (int j = i + 1; j < array.Length; j++)
                {
                    if (array[j] < array[smallest])
                        smallest = j;
                }

                temp = array[smallest];
                array[smallest] = array[i];
                array[i] = temp;
            }

            return array;
        }
    }
}