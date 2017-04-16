using System;
using System.Runtime.CompilerServices;

namespace Algorithms.Sources
{
    // O(n log n)
    public class MergeSort
    {
        private readonly int[] _values;

        public MergeSort(int[] values)
        {
            this._values = values;
        }

        public static void Sort(int[] values)
        {
            var mergeSort = new MergeSort(values);

            // Start merge sort
            mergeSort.Split(0, values.Length - 1);
        }

        private void Split(int low, int high)
        {
            // Can we split any further?
            if (low == high) return;

            int median = (low + high) / 2;

            // Sort left half
            this.Split(low, median);

            // Sort right half
            this.Split(median + 1, high);

            // Merge both sides together
            this.Merge(low, median, high);
        }

        private void Merge(int low, int middle, int high)
        {
            // Create helper to make swapping values easier
            var temp = (int[]) this._values.Clone();

            int left = low;
            int right = middle + 1;
            int index = low;

            // As long as we are in range
            while (left <= middle && right <= high)
            {
                // Decide which side has a lower value and apply that to the main array and move along on just that one side
                if (temp[left] <= temp[right])
                {
                    this._values[index] = temp[left];
                    left++;
                }
                else
                {
                    this._values[index] = temp[right];
                    right++;
                }

                index++;
            }

            // Check whether there are leftovers
            // Copy the rest of the left side of the array into the target array
            while (left <= middle)
            {
                this._values[index] = temp[left];

                index++;
                left++;
            }
        }
    }
}