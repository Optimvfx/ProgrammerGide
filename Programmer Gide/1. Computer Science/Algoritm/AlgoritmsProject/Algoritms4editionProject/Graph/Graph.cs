using System;
using System.Collections.Generic;
using System.Linq;

namespace AlgoritmsProject
{
    public class Graph
    {
        protected readonly List<Vertex> _vertexes;

        public int VertexCount => _vertexes.Count;

        public string Find(int vertexIndex)
        {
            if (OutOfRange(vertexIndex))
                throw new IndexOutOfRangeException();

            return _vertexes[vertexIndex].Name;
        }

        protected Graph(IEnumerable<Vertex> vertexes)
        {
            _vertexes = vertexes.ToList();
        }

        protected bool OutOfRange(int vertexIndex)
        {
            return vertexIndex < 0 || vertexIndex >= _vertexes.Count;
        }
    }
}
