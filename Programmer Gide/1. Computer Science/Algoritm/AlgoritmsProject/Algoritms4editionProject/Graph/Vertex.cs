using System.Collections.Generic;

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