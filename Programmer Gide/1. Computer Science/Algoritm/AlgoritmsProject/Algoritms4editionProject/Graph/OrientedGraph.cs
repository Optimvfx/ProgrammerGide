using System;
using System.Collections.Generic;
using System.Linq;

namespace AlgoritmsProject
{
    public class OrientedGraph : Graph
    {
        private OrientedGraph(IEnumerable<Vertex> vertexes) : base(vertexes)
        {
        }

        public static OrientedGraph Create(int vertexCount)
        {
            if (vertexCount <= 0)
                throw new ArgumentException();

            var vertexes = new Vertex[vertexCount];

            for (int i = 0; i < vertexCount; i++)
            {
                var newVertex = new Vertex(nameof(Vertex) + " " + i.ToString());

                vertexes[i] = newVertex;
            }

            return new OrientedGraph(vertexes);
        }

        public void Union(int from, int to)
        {
            if (OutOfRange(from) || OutOfRange(to))
                throw new IndexOutOfRangeException();

            if (_vertexes[from].IsConected(_vertexes[to]) == false)
            {
                throw new ArgumentException();
            }
        }

        public bool IsConected(int from, int to)
        {
            if (OutOfRange(from) || OutOfRange(to))
                throw new IndexOutOfRangeException();

            return _vertexes[from].IsConected(_vertexes[to]);
        }

        private bool OutOfRange(int vertexIndex)
        {
            return vertexIndex < 0 || vertexIndex >= _vertexes.Count;
        }

    }
}
