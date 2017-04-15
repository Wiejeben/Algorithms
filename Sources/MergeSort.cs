﻿using System.Runtime.CompilerServices;

namespace Algorithms.Sources
{
    public class MergeSort
    {
        private readonly int[] _numbers;

        public MergeSort(int[] values)
        {
            this._numbers = values;
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

            // Split low - median range
            this.Split(low, median);

            // Split median + 1 - range
            this.Split(median + 1, high);

            // Combine them both
            this.Merge(low, median, high);
        }

        private void Merge(int low, int middle, int high)
        {
            // Create helper to make swapping values easier
            var helper = (int[]) this._numbers.Clone();

            int i = low;
            int j = middle + 1;
            int k = low;

            // Copy the smallest values from either the left or the right side back to the original array
            while (i <= middle && j <= high)
            {
                if (helper[i] <= helper[j])
                {
                    this._numbers[k] = helper[i];
                    i++;
                }
                else
                {
                    this._numbers[k] = helper[j];
                    j++;
                }

                k++;
            }

            // Copy the rest of the left side of the array into the target array
            while (i <= middle)
            {
                this._numbers[k] = helper[i];

                k++;
                i++;
            }
        }
    }
}