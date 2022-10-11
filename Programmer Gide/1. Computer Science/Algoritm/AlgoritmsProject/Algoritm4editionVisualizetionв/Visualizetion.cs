using System;
using System.Drawing;

namespace Algoritm4editionVisualizetion
{
    public class Visualizetion
    {
        public void ShowNHardnes()
        {
            var oneCurve = new CurveInfo("1", Color.White);
            var sqrtCurve = new CurveInfo("Sqrt(n)", Color.LightBlue);
            var logCurve = new CurveInfo("Log(n)", Color.Blue);
            var nCurve = new CurveInfo("n", Color.Cyan);
            var nnCurve = new CurveInfo("n * n", Color.Green);
            var nnnCurve = new CurveInfo("n * n * n", Color.Yellow);
            var nMultiNCurve = new CurveInfo("n ^ n", Color.Red);

            var curves = new CurveInfo[] { oneCurve, sqrtCurve, logCurve, nCurve, nnCurve, nnnCurve, nMultiNCurve };

            var graphVisualize = new GraphVisualizer("PIZDA", curves);

            for (int i = 0; i < 100; i++)
            {
                oneCurve.AddPoint(new DataPoint(i, 1));
                sqrtCurve.AddPoint(new DataPoint(i, Math.Sqrt(i)));
                logCurve.AddPoint(new DataPoint(i, Math.Log(i)));
                nCurve.AddPoint(new DataPoint(i, i));
                nnCurve.AddPoint(new DataPoint(i, i * i));
                nnnCurve.AddPoint(new DataPoint(i, i * i * i));
                nMultiNCurve.AddPoint(new DataPoint(i, Math.Pow(i, i)));
            }

            graphVisualize.Show();
        }
    }
}
