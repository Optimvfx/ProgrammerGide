using System;
using System.Collections.Generic;
using System.Drawing;
using Algoritms4editionProject;

namespace Algoritm4editionVisualizetion
{
    public class Visualizetion
    {
        private readonly uint _showDistance = 100000;

        private readonly int _randomKey = 20;

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

            AddPointsToCurve(oneCurve, (y) => 1);
            AddPointsToCurve(sqrtCurve, (y) => Math.Sqrt(y));
            AddPointsToCurve(logCurve, (y) => Math.Log(y));
            AddPointsToCurve(nCurve, (y) => y);
            AddPointsToCurve(nnCurve, (y) => y * y);
            AddPointsToCurve(nnnCurve, (y) => y * y * y);
            AddPointsToCurve(nMultiNCurve, (y) => Math.Pow(y, y));

            ShowGraph("N Curves", curves);
        }

        public void ShowEqlidAlgoritm()
        {
            var random = GetRandom();

            var eqlidAlgoritm = new EqlidAlgoritm();

            var eqlidCurve = new CurveInfo("Eqlid Algoritm", Color.Red);

            AddPointsToCurve(eqlidCurve, (y) => eqlidAlgoritm.GetWorkTime(y, random));

            ShowGraph("Eqlid Algoritm", eqlidCurve);
        }

        public void ShowSearchAlgoritms()
        {
            var random = GetRandom();

            var binarySearchAlgoritm = new BinaritySearchAlgoritm<int>();
            var standartSearchAlgoritm = new StandartSearchAlgoritm<int>();

            var binarySearchCurve = new CurveInfo("Binary Algoritm", Color.Red);
            var standartSearchCurve = new CurveInfo("Standart Algoritm", Color.Blue);

            AddPointsToCurve(binarySearchCurve, (y) => binarySearchAlgoritm.GetWorkTime(y, random));
            AddPointsToCurve(standartSearchCurve, (y) => standartSearchAlgoritm.GetWorkTime(y, random));

            ShowGraph("Search Algoritm", binarySearchCurve, standartSearchCurve);
        }

        private void ShowGraph(string name, params CurveInfo[] curves)
        {
            var graph = new GraphVisualizer(name, curves);
            graph.Show();
        }

        private void AddPointsToCurve(CurveInfo curve, Func<uint, double> getXPoistion)
        {
            AddPointsToCurve(curve, _showDistance, getXPoistion);
        }

        private void AddPointsToCurve(CurveInfo curve, uint showDistance, Func<uint, double> getXPoistion)
        {
            for(uint i = 0; i < _showDistance; i += (i*2) + 1)
            {
                curve.AddPoint(new DataPoint(i, getXPoistion(i)));
            }
        }

        private Random GetRandom()
        {
            return new Random(_randomKey);
        }
    }
}
