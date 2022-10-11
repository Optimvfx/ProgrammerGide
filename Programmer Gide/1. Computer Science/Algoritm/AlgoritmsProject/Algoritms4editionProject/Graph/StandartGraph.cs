using System;
using System.Collections.Generic;
using System.Linq;

namespace AlgoritmsProject
{
    public class StandartGraph : Graph
    {
        private readonly List<Vertex> _vertexes;

        public int VertexCount => _vertexes.Count;

        private StandartGraph(IEnumerable<Vertex> vertexes) : base(vertexes)
        { 

        }

        public static StandartGraph Create(int vertexCount)
        {
            if (vertexCount <= 0)
                throw new ArgumentException();

             var vertexes = new Vertex[vertexCount];

            for(int i = 0; i < vertexCount; i++)
            {
                var newVertex = new Vertex(nameof(Vertex) + " " + i.ToString());

                vertexes[i] = newVertex;
            }

            return new StandartGraph(vertexes);
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
    }
}
