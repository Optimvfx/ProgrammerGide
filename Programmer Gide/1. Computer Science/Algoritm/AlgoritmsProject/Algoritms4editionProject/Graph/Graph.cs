using System;
using System.Collections.Generic;
using System.Linq;

namespace AlgoritmsProject
{
    public class Graph
    {
        private readonly List<Vertex> _vertexes;

        public int VertexCount => _vertexes.Count;

        private Graph(IEnumerable<Vertex> vertexes)
        {
            _vertexes = vertexes.ToList();
        }

        public static Graph Create(int vertexCount)
        {
            if (vertexCount <= 0)
                throw new ArgumentException();

             var vertexes = new Vertex[vertexCount];

            for(int i = 0; i < vertexCount; i++)
            {
                var newVertex = new Vertex(nameof(Vertex) + " " + i.ToString());

                vertexes[i] = newVertex;
            }

            return new Graph(vertexes);
        }

        public void Union(int firstVertexIndex, int secondVertexIndex)
        {
            if (OutOfRange(firstVertexIndex) || OutOfRange(secondVertexIndex))
                throw new IndexOutOfRangeException();

            if (_vertexes[firstVertexIndex].TryUnion(_vertexes[secondVertexIndex]) == false ||
                _vertexes[secondVertexIndex].TryUnion(_vertexes[firstVertexIndex]) == false)
            {
                throw new ArgumentException();
            }
        }

        public string Find(int vertexIndex)
        {
            if (OutOfRange(vertexIndex))
                throw new IndexOutOfRangeException();

            return _vertexes[vertexIndex].Name;
        }

        public bool IsConected(int firstVertexIndex, int secondVertexIndex)
        {
            if (OutOfRange(firstVertexIndex) || OutOfRange(secondVertexIndex))
                throw new IndexOutOfRangeException();

            var firstConectedSecond = _vertexes[firstVertexIndex].IsConected(_vertexes[secondVertexIndex]);
            var secondConectedFirst = _vertexes[secondVertexIndex].IsConected(_vertexes[firstVertexIndex]);

            if (firstConectedSecond != secondConectedFirst)
                throw new Exception();

            return firstConectedSecond;
        }

        private bool OutOfRange(int vertexIndex)
        {
            return vertexIndex < 0 || vertexIndex >= _vertexes.Count;
        }

        public class Vertex
        {
            public readonly string Name;

            private readonly List<Vertex> _conectedVertexes;

            public IEnumerable<Vertex> ConectedVertexes => _conectedVertexes;

            public Vertex(string name)
            {
                Name = name;

                _conectedVertexes = new List<Vertex>();
            }

            public bool TryUnion(Vertex other)
            {
                if (IsConected(other))
                    return false; 

                _conectedVertexes.Add(other);

                return true;
            }

            public bool IsConected(Vertex other)
            {
                return _conectedVertexes.Contains(other);
            }
        }
    }
}
