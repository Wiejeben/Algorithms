using System;

namespace Algorithms.Sources
{
    public class BinaryTree
    {
        public BinaryNode Root { get; set; }

        public BinaryTree(int[] values)
        {
            foreach (int value in values)
            {
                this.Root = this.Insert(value);
            }
        }

        public BinaryNode Insert(int value)
        {
            return this.Insert(this.Root, value);
        }

        public BinaryNode Insert(BinaryNode node, int value)
        {
            // New node
            if (node == null)
            {
                node = new BinaryNode(value);
                return node;
            }

            // Go left if lesser or equal, otherwise go right
            if (value <= node.Value)
            {
                node.Left = this.Insert(node.Left, value);
            }
            else
            {
                node.Right = this.Insert(node.Right, value);
            }

            return node;
        }

        public bool Search(int value)
        {
            return this.Search(this.Root, value);
        }

        public bool Search(BinaryNode node, int value)
        {
            // Conclude
            if (node == null) return false;
            if (node.Value == value) return true;

            return this.Search(value <= node.Value ? node.Left : node.Right, value);
        }
    }

    public class BinaryNode
    {
        public int Value { get; set; }
        public BinaryNode Left { get; set; } // Lesser or equal
        public BinaryNode Right { get; set; } // Greater

        public BinaryNode(int value)
        {
            this.Value = value;
        }

        public override string ToString()
        {
            return this.Value.ToString();
        }
    }
}