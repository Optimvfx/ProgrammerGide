using System;
using System.Drawing;
using ZedGraph;

namespace Algoritm4editionVisualizetion
{
    public class CurveInfo
    {
        public readonly string Name;
        public readonly Color Color;

        public event Action<CurveInfo, DataPoint> OnAddPoint;

        public CurveInfo(string name, Color color)
        {
            Name = name;
            Color = color;
        }

        public void AddPoint(DataPoint point)
        {
            OnAddPoint?.Invoke(this, point);
        }
    }
}