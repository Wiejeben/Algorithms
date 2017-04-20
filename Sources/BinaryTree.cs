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
            return Insert(this.Root, value);
        }

        private static BinaryNode Insert(BinaryNode node, int value)
        {
            // New node
            if (node == null) return new BinaryNode(value);

            // Go left if lesser or equal, otherwise go right
            if (value <= node.Value)
            {
                node.Left = Insert(node.Left, value);
            }
            else
            {
                node.Right = Insert(node.Right, value);
            }

            return node;
        }

        public bool Search(int value)
        {
            return Search(this.Root, value);
        }

        private static bool Search(BinaryNode node, int value)
        {
            // Conclude
            if (node == null) return false;
            if (node.Value == value) return true;

            // Go left if lesser or equal, otherwise go right
            return Search(value <= node.Value ? node.Left : node.Right, value);
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