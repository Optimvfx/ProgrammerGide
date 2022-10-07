namespace Algoritms4editonTests
{
    public class BaseAlgoritmsTester
    {
        public class EqlidAlgoritmTests
        {
            private EqlidAlgoritm _eqlidAlgoritm;

            [SetUp]
            public void Setup()
            {
                _eqlidAlgoritm = new EqlidAlgoritm();
            }

            //Data Validation Source https://planetcalc.ru/3298/
            [TestCase((ulong)20, (ulong)5, 1, (ulong)5)]
            [TestCase(ulong.MaxValue, ulong.MaxValue / 10, 3, (ulong)1)]
            [TestCase(uint.MaxValue, uint.MaxValue / 25, 6, (ulong)1)]
            [TestCase((ulong)98, (ulong)12, 2, (ulong)2)]
            public void EqlidAlgoritmTest(ulong dividend, ulong divisioned, int exceptedCycleCount, ulong exceptedResult)
            {
                var result = _eqlidAlgoritm.Calkulate(dividend, divisioned, out int cycleCount);

                AreEqualResult(result, cycleCount, exceptedResult, exceptedCycleCount);
            }

            //Data Validation Source https://planetcalc.ru/3298/
            [TestCase((ulong)20, (ulong)5, 1, (ulong)5)]
            [TestCase(ulong.MaxValue, ulong.MaxValue / 10, 3, (ulong)1)]
            [TestCase(uint.MaxValue, uint.MaxValue / 25, 6, (ulong)1)]
            [TestCase((ulong)98, (ulong)12, 2, (ulong)2)]
            public void EqlidAlgoritmRecursionTest(ulong dividend, ulong divisioned, int exceptedCycleCount, ulong exceptedResult)
            {
                var result = _eqlidAlgoritm.Calkulate(dividend, divisioned, out int cycleCount);

                AreEqualResult(result, cycleCount, exceptedResult, exceptedCycleCount);
            }

            private void AreEqualResult(ulong result, long cycleCount, ulong exceptedResult, long exceptedCycleCount)
            {
                Assert.That(exceptedResult == result, $"Node {result} != Exepted {exceptedResult}.");
                Assert.That(cycleCount == exceptedCycleCount, $"Cycle count {cycleCount} != Exepted {exceptedCycleCount}.");
            }
        }

        public class BinarytiSearchTests
        {
            private BinaritySearchAlgoritm<int> _binarytiSearch;

            [SetUp]
            public void Setup()
            {
                _binarytiSearch = new BinaritySearchAlgoritm<int>();
            }

            [TestCase(new int[] { 5, 15, 20, 25, 40 }, 5, 0, true)]
            [TestCase(new int[] { 5, 15, 20, 25, 40 }, 15, 1, true)]
            [TestCase(new int[] { 5, 15, 20, 25, 40 }, 20, 2, true)]
            [TestCase(new int[] { 5, 15, 20, 25, 40 }, 25, 3, true)]
            [TestCase(new int[] { 5, 15, 20, 25, 40 }, 40, 4, true)]
            [TestCase(new int[] { 5, 15, 20, 25, 40 }, 100, 0, false)]
            [TestCase(new int[] { 5, 15, 20, 25, 40 }, -100, 0, false)]
            [TestCase(new int[] { 5, 15, 20, 25, 40 }, 0, 0, false)]
            [TestCase(new int[] { 5, 15, 20, 25, 40 }, 21, 0, false)]
            [TestCase(new int[] { 5, 15, 20, 25, 40 }, 19, 0, false)]
            public void BinaritySearchTest(IEnumerable<int> sortedCollection, int searching, int exceptedFoundedIndex, bool exceptedSearchResult)
            {
                var searchResult = _binarytiSearch.TrySearchElementIndexRecursion(sortedCollection,searching, out int foundedIndex);

                AreEqualResult(searchResult, foundedIndex, exceptedSearchResult, exceptedFoundedIndex); 
            }

            private void AreEqualResult(bool searchResult, int foundedIndex, bool exeptedSearchingResult, int exeptedFoundedIndex)
            {
                Assert.That(searchResult == exeptedSearchingResult, $"{nameof(searchResult)} {searchResult} != {nameof(exeptedSearchingResult)} {exeptedSearchingResult}.");
                Assert.That(foundedIndex == exeptedFoundedIndex, $"{(nameof(foundedIndex))} {foundedIndex} != {nameof(exeptedFoundedIndex)} {exeptedFoundedIndex}.");
            }
        }
    }
}