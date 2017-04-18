using System;
using System.Linq;

namespace Algorithms.Sources
{
    public class KdTree
    {
        public KdNode Root { get; set; }

        public KdTree(Vector2[] values)
        {
            this.Root = this.BulkInsert(values);
        }

        public KdNode BulkInsert(Vector2[] positions, int depth = 0)
        {
            int length = positions.Length;
            int median = length / 2;
            bool even = depth % 2 == 0;

            // When there are no more positions left
            if (length == 0) return null;

            // When we cannot split any further
            if (length == 1) return new KdNode(positions[0]);

            // Sort values based on their axis
            positions = positions.OrderBy(p => even ? p.X : p.Y).ToArray();

            // Take sides
            Vector2[] left = positions.Take(median).ToArray();
            Vector2[] right = positions.Skip(median + 1).ToArray();

            // Generate median value and go both ways
            return new KdNode(positions[median])
            {
                Left = this.BulkInsert(left, depth + 1),
                Right = this.BulkInsert(right, depth + 1)
            };
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
}