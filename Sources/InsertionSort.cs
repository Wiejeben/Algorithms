﻿namespace Algorithms.Sources
{
    /*
        Complexity:
        - worst case, reverse order: O(n2)
        - best case, already sorted: O(n)
        Code implementation: http://www.codecodex.com/wiki/Insertion_sort#C.23
    */
    public static class InsertionSort
    {
        public static void Sort(int[] array)
        {
            // Go from left to right
            for (int i = 1; i < array.Length; i++)
            {
                int current = i;

                // Check all items from current to left
                // Do not go below index zero
                // Keep going as long as the current item is smaller than the left item
                while (current > 0 && array[current] < array[current - 1])
                {
                    // Swap and go to the previous item
                    SwapValues(array, current--, current);
                }
            }
        }

        private static void SwapValues(int[] array, int indexOne, int indexTwo)
        {
            // Store one of the indexes values
            var indexOneValue = array[indexOne];

            // Perform swap
            array[indexOne] = array[indexTwo];
            array[indexTwo] = indexOneValue;
        }
    }
}