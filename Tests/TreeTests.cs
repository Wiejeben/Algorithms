using System;
using Algorithms.Sources;
using NUnit.Framework;

namespace Algorithms.Tests
{
    [TestFixture]
    public class TreeTests
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
        [Repeat(25)]
        public void TestBstInsertAlgorithm()
        {
            int[] values = TreeTests.GenerateArrayWithRandomIntegers();

            // Build tree
            var tree = new BinaryTree(values);

            // Validate entire tree structure
            Assert.IsTrue(ValidateBst(tree.Root));
        }

        [Test]
        [Repeat(25)]
        public void TestBstSearchAlgorithm()
        {
            int[] values = TreeTests.GenerateArrayWithRandomIntegers();

            // Build tree
            var tree = new BinaryTree(values);

            // Check if it can find the first index
            Assert.IsTrue(tree.Search(values[1]));
        }

        private static bool ValidateBst(BinaryNode node)
        {
            if (node.Left != null)
            {
                if (node.Value < node.Left.Value || ValidateBst(node.Left) == false)
                {
                    return false;
                }
            }

            if (node.Right != null)
            {
                if (node.Value >= node.Right.Value || ValidateBst(node.Right) == false)
                {
                    return false;
                }
            }

            return true;
        }
    }
}