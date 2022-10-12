using AlgoritmsProject;
using GraphVisualizetion;
using System;
using System.Drawing;

namespace GraphShow
{
    public class GraphShower
    {
        private const uint _showDistance = 10000;

        private const int _randomKey = 20;

        private readonly Visualizer _visualizer;

        public GraphShower(Visualizer visualizer)
        {
            _visualizer = visualizer;
        }

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

            _visualizer.AddPointsToCurve(oneCurve, _showDistance, (y) => 1);
            _visualizer.AddPointsToCurve(sqrtCurve, _showDistance, (y) => Math.Sqrt(y));
            _visualizer.AddPointsToCurve(logCurve, _showDistance, (y) => Math.Log(y));
            _visualizer.AddPointsToCurve(nCurve, _showDistance, (y) => y);
            _visualizer.AddPointsToCurve(nnCurve, _showDistance, (y) => y * y);
            _visualizer.AddPointsToCurve(nnnCurve, _showDistance, (y) => y * y * y);

            if (showNMulti)
                _visualizer.AddPointsToCurve(nMultiNCurve, _showDistance, (y) => Math.Pow(y, y));

            _visualizer.ShowGraph("N Curves", curves);
        }

        public void ShowEqlidAlgoritm()
        {
            var random = GetRandom();

            var eqlidAlgoritm = new EqlidAlgoritm();

            var eqlidCurve = new CurveInfo("Eqlid Algoritm", Color.Red);

            _visualizer.AddPointsToCurve(eqlidCurve, _showDistance, (y) => eqlidAlgoritm.GetWorkTime(y, random));

            _visualizer.ShowGraph("Eqlid Algoritm", eqlidCurve);
        }

        public void ShowSearchAlgoritms()
        {
            var random = GetRandom();

            var binarySearchAlgoritm = new BinaritySearchAlgoritm<int>();
            var standartSearchAlgoritm = new StandartSearchAlgoritm<int>();

            var binarySearchCurve = new CurveInfo("Binary Algoritm", Color.Red);
            var standartSearchCurve = new CurveInfo("Standart Algoritm", Color.Blue);

            _visualizer.AddPointsToCurve(binarySearchCurve, _showDistance, (y) => binarySearchAlgoritm.GetWorkTime(y, random));
            _visualizer.AddPointsToCurve(standartSearchCurve, _showDistance, (y) => standartSearchAlgoritm.GetWorkTime(y, random));

            _visualizer.ShowGraph("Search Algoritm", binarySearchCurve, standartSearchCurve);
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

            _visualizer.AddPointsToCurve(sellectionSortCurve, (uint)(_showDistance * showDistanceModiffier), (y) => sellectionSortAlgoritm.GetWorkTime(y, random));
            _visualizer.AddPointsToCurve(insertionSortCurve, (uint)(_showDistance * showDistanceModiffier), (y) => insertionSortAlgoritm.GetWorkTime(y, random));
            _visualizer.AddPointsToCurve(mergeSortRecursionCurve, (uint)(_showDistance * showDistanceModiffier), (y) => mergeSortRecursionAlgoritm.GetWorkTime(y, random));
            _visualizer.AddPointsToCurve(mergeSortCurve, (uint)(_showDistance * showDistanceModiffier), (y) => mergeSortAlgoritm.GetWorkTime(y, random));
            _visualizer.AddPointsToCurve(quickSortRecursionCurve, (uint)(_showDistance * showDistanceModiffier), (y) => quickSortRecursionAlgoritm.GetWorkTime(y, random));
            _visualizer.AddPointsToCurve(quickSortCurve, (uint)(_showDistance * showDistanceModiffier), (y) => quickSortAlgoritm.GetWorkTime(y, random));

            _visualizer.ShowGraph("Sort Algoritm", sellectionSortCurve, insertionSortCurve, mergeSortRecursionCurve, mergeSortCurve, quickSortRecursionCurve, quickSortCurve);
        }

        public Random GetRandom()
        {
            return new Random(_randomKey);
        }
    }
}
