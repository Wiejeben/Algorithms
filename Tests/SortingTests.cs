using System;
using Algorithms.Sources;
using NUnit.Framework;

namespace Algorithms.Tests
{
    [TestFixture]
    public class SortingTests
    {

        private static int[] GenerateArrayWithRandomIntegers(int amount = 500, int min = 0, int max = 1000)
        {
            var array = new int[amount];

            var random = new Random();
            for (int i = 0; i < amount; i++)
            {
                array[i] = random.Next(min, max);
            }

            return array;
        }

        [Test]
//        [Repeat(25)]
        public void TestInsertionSortAlgorithm()
        {
            int[] expected = SortingTests.GenerateArrayWithRandomIntegers();
            var actual = (int[]) expected.Clone();

            // Perform sorting algorithms
            Array.Sort(expected); // Native
            InsertionSort.Sort(actual); // Custom

            Assert.AreEqual(expected, actual);
        }

        [Test]
//        [Repeat(25)]
        public void TestMergeSortAlgorithm()
        {
            int[] expected = SortingTests.GenerateArrayWithRandomIntegers();
            var actual = (int[]) expected.Clone();

            // Perform sorting algorithms
            Array.Sort(expected); // Native
            MergeSort.Sort(actual); // Custom

            Assert.AreEqual(expected, actual);
        }
    }
}