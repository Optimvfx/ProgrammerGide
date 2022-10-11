using System;
using System.Drawing;
using AlgoritmsProject;

namespace AlgoritmVisualizetion
{
    public class Visualizetion
    {
        private readonly uint _showDistance = 10000;

        private readonly int _randomKey = 20;

        public event Action<uint, uint> VisualizationProgresChanged;

        public void ShowNHardnes(bool showNMulti)
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

            if (showNMulti)
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

        public void ShowSortAlgoritms()
        {
            var showDistanceModiffier = 0.1f;

            var random = GetRandom();

            var sellectionSortAlgoritm = new SellectionSortAlgoritm<int>();
            var insertionSortAlgoritm = new InsertionSortAlgoritm<int>();
            var mergeSortRecursionAlgoritm = new MergeSortAlgoritmRecursion<int>();
            var mergeSortAlgoritm = new MergeSortAlgoritm<int>();
            var quickSortRecursionAlgoritm = new QuickSortAlgoritmRecursion<int>();
            var quickSortAlgoritm = new QuickSortAlgoritm<int>();

            var sellectionSortCurve = new CurveInfo("Sellection Sort Curve", Color.Red);
            var insertionSortCurve = new CurveInfo("Insertion Sort Curve", Color.Yellow);
            var mergeSortRecursionCurve = new CurveInfo("Merge Sort Recursion Curve", Color.Green);
            var mergeSortCurve = new CurveInfo("Merge Sort Curve", Color.Blue);
            var quickSortRecursionCurve = new CurveInfo("Quick Sort Recursion Curve", Color.Cyan);
            var quickSortCurve = new CurveInfo("Quick Sort Curve", Color.LightBlue);

            AddPointsToCurve(sellectionSortCurve, (uint)(_showDistance * showDistanceModiffier), (y) => sellectionSortAlgoritm.GetWorkTime(y, random));
            AddPointsToCurve(insertionSortCurve, (uint)(_showDistance * showDistanceModiffier), (y) => insertionSortAlgoritm.GetWorkTime(y, random));
            AddPointsToCurve(mergeSortRecursionCurve, (uint)(_showDistance * showDistanceModiffier), (y) => mergeSortRecursionAlgoritm.GetWorkTime(y, random));
            AddPointsToCurve(mergeSortCurve, (uint)(_showDistance * showDistanceModiffier), (y) => mergeSortAlgoritm.GetWorkTime(y, random));
            AddPointsToCurve(quickSortRecursionCurve, (uint)(_showDistance * showDistanceModiffier), (y) => quickSortRecursionAlgoritm.GetWorkTime(y, random));
            AddPointsToCurve(quickSortCurve, (uint)(_showDistance * showDistanceModiffier), (y) => quickSortAlgoritm.GetWorkTime(y, random));

            ShowGraph("Sort Algoritm", sellectionSortCurve, insertionSortCurve, mergeSortRecursionCurve, mergeSortCurve, quickSortRecursionCurve, quickSortCurve);
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
            for(uint i = 0; i < showDistance; i += (i*2) + 1)
            {
                curve.AddPoint(new DataPoint(i, getXPoistion(i)));

                VisualizationProgresChanged?.Invoke(i, showDistance);
            }
        }

        private Random GetRandom()
        {
            return new Random(_randomKey);
        }
    }
}
