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

            var random = new Random(Guid.NewGuid().GetHashCode());
            for (int i = 0; i < amount; i++)
            {
                array[i] = random.Next(min, max);
            }

            return array;
        }

        [Test]
//        [Repeat(25)]
        public void TestBstInsertAlgorithm()
        {
            int[] values = TreeTests.GenerateArrayWithRandomIntegers();

            // Build tree
            var tree = new BinaryTree(values);

            // Validate entire tree structure
            Assert.IsTrue(ValidateBst(tree.Root));
        }

        [Test]
//        [Repeat(25)]
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

        [Test]
//        [Repeat(25)]
        public void TestKdtInsertAlgorithm()
        {
            int[] x = TreeTests.GenerateArrayWithRandomIntegers();
            int[] y = TreeTests.GenerateArrayWithRandomIntegers();

            var values = new Vector2[x.Length];
            for (int i = 0; i < x.Length; i++)
            {
                values[i] = new Vector2(x[i], y[i]);
            }

            // Build tree
            var tree = new KdTree(values);

            // Validate entire tree structure
            // TODO: Write unit test to validate the KdTree
            Assert.IsTrue(ValidateKdt(tree.Root));
            Console.Write("");
        }

        private static bool ValidateKdt(KdNode node, int depth = 0)
        {
            bool even = depth % 2 == 0;
            var nodeValue = even ? node.Value.X : node.Value.Y;

            if (node.Left != null)
            {
                var leftValue = even ? node.Left.Value.X : node.Left.Value.Y;

                if (nodeValue < leftValue || ValidateKdt(node.Left, ++depth) == false)
                {
                    return false;
                }
            }

            if (node.Right != null)
            {
                var rightValue = even ? node.Right.Value.X : node.Right.Value.Y;

                if (nodeValue >= rightValue || ValidateKdt(node.Right, ++depth) == false)
                {
                    return false;
                }
            }

            return true;
        }
    }
}