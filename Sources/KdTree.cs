﻿using System.Linq;

namespace Algorithms.Sources
{
    public class KdTree
    {
        public KdNode Root { get; set; }

        public KdTree(Vector2[] values)
        {
            this.Root = BulkInsert(values);
        }

        private static KdNode BulkInsert(Vector2[] positions, int depth = 0)
        {
            int length = positions.Length;
            int median = length / 2;
            bool even = depth % 2 == 0;

            // When there are no more positions
            if (length == 0) return null;

            // No point in splitting any further
            if (length == 1) return new KdNode(positions[0]);

            // Sort values based on their axis
            positions = positions.OrderBy(p => even ? p.X : p.Y).ToArray();

            // Split sides (left will always be less
            Vector2[] left = positions.Take(median).ToArray();
            Vector2[] right = positions.Skip(median + 1).ToArray();

            // Create node from the median
            return new KdNode(positions[median])
            {
                Left = BulkInsert(left, ++depth),
                Right = BulkInsert(right, ++depth)
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