namespace Algorithms.Sources
{
    public class Vector2
    {
        public float X { get; set; }
        public float Y { get; set; }

        public Vector2(float x, float y)
        {
            this.X = x;
            this.Y = y;
        }

        public override string ToString()
        {
            return this.X + " - " + this.Y;
        }
    }

    public class KdTree
    {
        public KdNode Root { get; set; }

        public KdTree(Vector2[] values)
        {
            foreach (Vector2 value in values)
            {
                this.Root = this.Insert(value);
            }
        }

        public KdNode Insert(Vector2 value)
        {
            return this.Insert(this.Root, value);
        }

        public KdNode Insert(KdNode node, Vector2 value, int depth = 0)
        {
            // New node
            if (node == null)
            {
                node = new KdNode(value);
                return node;
            }

            // Determine axis
            bool even = depth % 2 == 0;

            var valueAxis = even ? value.X : value.Y;
            var nodeValueAxis = even ? node.Value.X : node.Value.Y;

            // Go left if lesser or equal, otherwise go right
            if (valueAxis <= nodeValueAxis)
            {
                node.Left = this.Insert(node.Left, value, depth + 1);
            }
            else
            {
                node.Right = this.Insert(node.Right, value, depth + 1);
            }

            return node;
        }
    }

    public class KdNode
    {
        public Vector2 Value { get; set; }
        public KdNode Left { get; set; } // Lesser or equal
        public KdNode Right { get; set; } // Greater

        public KdNode(Vector2 value)
        {
            this.Value = value;
        }

        public override string ToString()
        {
            return this.Value.ToString();
        }
    }
}