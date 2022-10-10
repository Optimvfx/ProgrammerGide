namespace AlgoritmsTests
{
    public class SearchAlgoritmsTests
    {
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
            [TestCase(new int[] { 5, 15, 20, 25, 40 }, 100, -1, false)]
            [TestCase(new int[] { 5, 15, 20, 25, 40 }, -100, -1, false)]
            [TestCase(new int[] { 5, 15, 20, 25, 40 }, 0, -1, false)]
            [TestCase(new int[] { 5, 15, 20, 25, 40 }, 21, -1, false)]
            [TestCase(new int[] { 5, 15, 20, 25, 40 }, 19, -1, false)]
            public void BinaritySearchTest(IEnumerable<int> sortedCollection, int searching, int exceptedFoundedIndex, bool exceptedSearchResult)
            {
                var searchResult = _binarytiSearch.TrySearchElementIndexRecursion(sortedCollection, searching, out int foundedIndex);

                AreEqualResult(searchResult, foundedIndex, exceptedSearchResult, exceptedFoundedIndex);
            }
        }

        public class StandartSearchTests
        {
            private StandartSearchAlgoritm<int> _standartSearch;

            [SetUp]
            public void Setup()
            {
                _standartSearch = new StandartSearchAlgoritm<int>();
            }

            [TestCase(new int[] { 5, 15, 20, 25, 40 }, 5, 0, true)]
            [TestCase(new int[] { 5, 15, 20, 25, 40 }, 15, 1, true)]
            [TestCase(new int[] { 5, 15, 20, 25, 40 }, 20, 2, true)]
            [TestCase(new int[] { 5, 15, 20, 25, 40 }, 25, 3, true)]
            [TestCase(new int[] { 5, 15, 20, 25, 40 }, 40, 4, true)]
            [TestCase(new int[] { 5, 15, 20, 25, 40 }, 100, -1, false)]
            [TestCase(new int[] { 5, 15, 20, 25, 40 }, -100, -1, false)]
            [TestCase(new int[] { 5, 15, 20, 25, 40 }, 0, -1, false)]
            [TestCase(new int[] { 5, 15, 20, 25, 40 }, 21, -1, false)]
            [TestCase(new int[] { 5, 15, 20, 25, 40 }, 19, -1, false)]
            public void StandartSearchTest(IEnumerable<int> sortedCollection, int searching, int exceptedFoundedIndex, bool exceptedSearchResult)
            {
                var searchResult = _standartSearch.TrySearchElementIndex(sortedCollection, searching, out int foundedIndex);

                AreEqualResult(searchResult, foundedIndex, exceptedSearchResult, exceptedFoundedIndex);
            }
        }

        private static void AreEqualResult(bool searchResult, int foundedIndex, bool exeptedSearchingResult, int exeptedFoundedIndex)
        {
            Assert.That(searchResult == exeptedSearchingResult, $"{nameof(searchResult)} {searchResult} != {nameof(exeptedSearchingResult)} {exeptedSearchingResult}.");

            Assert.That(foundedIndex == exeptedFoundedIndex, $"{(nameof(foundedIndex))} {foundedIndex} != {nameof(exeptedFoundedIndex)} {exeptedFoundedIndex}.");
        }
    }
}
