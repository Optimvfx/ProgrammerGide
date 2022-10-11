namespace AlgoritmsTests
{
    public class SortAlgoritms
    {
        public class SellectionSortTests
        {
            SellectionSortAlgoritm<int> _sellectionSort;

            [SetUp]
            public void SetUp()
            {
                _sellectionSort = new SellectionSortAlgoritm<int>();
            }

            [TestCase(new int[] { 12, 9, 3, 7, 14, 11, 6, 2, 10, 5 },
                      new int[] { 2, 3, 5, 6, 7, 9, 10, 11, 12, 14 })]

            [TestCase(new int[] { int.MinValue, -15, -10, -5, 0, 5, 10, 15, 20, 25, int.MaxValue },
                      new int[] { int.MinValue, -15, -10, -5, 0, 5, 10, 15, 20, 25, int.MaxValue })]

            [TestCase(new int[] { 1000, 25, 20, 15, 10, 5, 0, -5, -10, -15, -1000 },
                      new int[] { -1000, -15, -10, -5, 0, 5, 10, 15, 20, 25, 1000 })]

            [TestCase(new int[] { int.MinValue, 20, 15, -15, -5, 0, 5, 10, -10, 25, int.MaxValue },
                      new int[] { int.MinValue, -15, -10, -5, 0, 5, 10, 15, 20, 25, int.MaxValue })]

            [TestCase(new int[] { int.MaxValue, -15, -10, -5, 0, 5, 10, 15, 20, 25, int.MinValue },
                      new int[] { int.MinValue, -15, -10, -5, 0, 5, 10, 15, 20, 25, int.MaxValue })]

            [TestCase(new int[] { int.MinValue, -15, -10, 10, 5, 0, -5, 15, 20, 25, int.MaxValue },
                      new int[] { int.MinValue, -15, -10, -5, 0, 5, 10, 15, 20, 25, int.MaxValue })]

            [TestCase(new int[] { -15, int.MaxValue, 10, 15, int.MinValue, 20, 25, 5, 0, -10, -5 },
                      new int[] { int.MinValue, -15, -10, -5, 0, 5, 10, 15, 20, 25, int.MaxValue })]

            [TestCase(new int[] { 10, 10, -10, 10, 15, 15, -15, 15, -15 },
                      new int[] { -15, -15, -10, 10, 10, 10, 15, 15, 15 })]

            public void SortTest(int[] array, int[] exeptedResult)
            {
                _sellectionSort.Sort(array, (f, s) => f.CompareTo(s));

                AreEqualResult(array, exeptedResult);
            }
        }

        public class InsertionSortTests
        {
            InsertionSortAlgoritm<int> _insertionSort;

            [SetUp]
            public void SetUp()
            {
                _insertionSort = new InsertionSortAlgoritm<int>();
            }

            [TestCase(new int[] { int.MinValue, -15, -10, -5, 0, 5, 10, 15, 20, 25, int.MaxValue },
                      new int[] { int.MinValue, -15, -10, -5, 0, 5, 10, 15, 20, 25, int.MaxValue })]

            [TestCase(new int[] {  1000 , 25, 20, 15, 10, 5, 0, -5, -10, -15, -1000},
                      new int[] { -1000, -15, -10, -5, 0, 5, 10, 15, 20, 25, 1000})]

            [TestCase(new int[] { int.MinValue, 20, 15, -15, -5, 0, 5, 10, -10, 25, int.MaxValue },
                      new int[] { int.MinValue, -15, -10, -5, 0, 5, 10, 15, 20, 25, int.MaxValue })]

            [TestCase(new int[] { int.MaxValue, -15, -10, -5, 0, 5, 10, 15, 20, 25, int.MinValue },
                      new int[] { int.MinValue, -15, -10, -5, 0, 5, 10, 15, 20, 25, int.MaxValue })]

            [TestCase(new int[] { int.MinValue, -15, -10, 10, 5, 0, -5, 15, 20, 25, int.MaxValue },
                      new int[] { int.MinValue, -15, -10, -5, 0, 5, 10, 15, 20, 25, int.MaxValue })]

            [TestCase(new int[] { -15, int.MaxValue, 10, 15, int.MinValue, 20, 25, 5, 0, -10, -5},
                      new int[] { int.MinValue, -15, -10, -5, 0, 5, 10, 15, 20, 25, int.MaxValue })]

            [TestCase(new int[] {  10,  10, -10, 10, 15, 15, -15, 15, -15 },
                      new int[] { -15, -15, -10, 10, 10, 10, 15, 15, 15 })]

            public void SortTest(int[] array, int[] exeptedResult)
            {
                _insertionSort.Sort(array, (f, s) => f.CompareTo(s));

                AreEqualResult(array, exeptedResult);
            }
        }

        public class MergeSortRecursionTests
        {
            MergeSortAlgoritmRecursion<int> _mergeSort;

            [SetUp]
            public void SetUp()
            {
                _mergeSort = new MergeSortAlgoritmRecursion<int>();
            }

            [TestCase(new int[] { 12, 9, 3, 7, 14, 11, 6, 2, 10, 5 },
                      new int[] { 2, 3, 5, 6, 7, 9, 10, 11, 12, 14 })]

            [TestCase(new int[] { int.MinValue, -15, -10, -5, 0, 5, 10, 15, 20, 25, int.MaxValue },
                      new int[] { int.MinValue, -15, -10, -5, 0, 5, 10, 15, 20, 25, int.MaxValue })]

            [TestCase(new int[] { 1000, 25, 20, 15, 10, 5, 0, -5, -10, -15, -1000 },
                      new int[] { -1000, -15, -10, -5, 0, 5, 10, 15, 20, 25, 1000 })]

            [TestCase(new int[] { int.MinValue, 20, 15, -15, -5, 0, 5, 10, -10, 25, int.MaxValue },
                      new int[] { int.MinValue, -15, -10, -5, 0, 5, 10, 15, 20, 25, int.MaxValue })]

            [TestCase(new int[] { int.MaxValue, -15, -10, -5, 0, 5, 10, 15, 20, 25, int.MinValue },
                      new int[] { int.MinValue, -15, -10, -5, 0, 5, 10, 15, 20, 25, int.MaxValue })]

            [TestCase(new int[] { int.MinValue, -15, -10, 10, 5, 0, -5, 15, 20, 25, int.MaxValue },
                      new int[] { int.MinValue, -15, -10, -5, 0, 5, 10, 15, 20, 25, int.MaxValue })]

            [TestCase(new int[] { -15, int.MaxValue, 10, 15, int.MinValue, 20, 25, 5, 0, -10, -5 },
                      new int[] { int.MinValue, -15, -10, -5, 0, 5, 10, 15, 20, 25, int.MaxValue })]

            [TestCase(new int[] { 10, 10, -10, 10, 15, 15, -15, 15, -15 },
                      new int[] { -15, -15, -10, 10, 10, 10, 15, 15, 15 })]

            public void SortTest(int[] array, int[] exeptedResult)
            {
                _mergeSort.Sort(array, (f, s) => f.CompareTo(s));

                AreEqualResult(array, exeptedResult);
            }
        }

        public class MergeSortTests
        {
            MergeSortAlgoritm<int> _mergeSort;

            [SetUp]
            public void SetUp()
            {
                _mergeSort = new MergeSortAlgoritm<int>();
            }

            [TestCase(new int[] { 12, 9, 3, 7, 14, 11, 6, 2, 10, 5 },
                      new int[] { 2, 3, 5, 6, 7, 9, 10, 11, 12, 14 })]

            [TestCase(new int[] { int.MinValue, -15, -10, -5, 0, 5, 10, 15, 20, 25, int.MaxValue },
                      new int[] { int.MinValue, -15, -10, -5, 0, 5, 10, 15, 20, 25, int.MaxValue })]

            [TestCase(new int[] { 1000, 25, 20, 15, 10, 5, 0, -5, -10, -15, -1000 },
                      new int[] { -1000, -15, -10, -5, 0, 5, 10, 15, 20, 25, 1000 })]

            [TestCase(new int[] { int.MinValue, 20, 15, -15, -5, 0, 5, 10, -10, 25, int.MaxValue },
                      new int[] { int.MinValue, -15, -10, -5, 0, 5, 10, 15, 20, 25, int.MaxValue })]

            [TestCase(new int[] { int.MaxValue, -15, -10, -5, 0, 5, 10, 15, 20, 25, int.MinValue },
                      new int[] { int.MinValue, -15, -10, -5, 0, 5, 10, 15, 20, 25, int.MaxValue })]

            [TestCase(new int[] { int.MinValue, -15, -10, 10, 5, 0, -5, 15, 20, 25, int.MaxValue },
                      new int[] { int.MinValue, -15, -10, -5, 0, 5, 10, 15, 20, 25, int.MaxValue })]

            [TestCase(new int[] { -15, int.MaxValue, 10, 15, int.MinValue, 20, 25, 5, 0, -10, -5 },
                      new int[] { int.MinValue, -15, -10, -5, 0, 5, 10, 15, 20, 25, int.MaxValue })]

            [TestCase(new int[] { 10, 10, -10, 10, 15, 15, -15, 15, -15 },
                      new int[] { -15, -15, -10, 10, 10, 10, 15, 15, 15 })]

            public void SortTest(int[] array, int[] exeptedResult)
            {
                _mergeSort.Sort(array, (f, s) => f.CompareTo(s));

                AreEqualResult(array, exeptedResult);
            }
        }

        public class QuickSortTests
        {
            QuickSortAlgoritm<int> _quickSort;

            [SetUp]
            public void SetUp()
            {
                _quickSort = new QuickSortAlgoritm<int>();
            }

            [TestCase(new int[] { 12, 9, 3, 7, 14, 11, 6, 2, 10, 5 },
                      new int[] { 2, 3, 5, 6, 7, 9, 10, 11, 12, 14 })]

            [TestCase(new int[] { int.MinValue, -15, -10, -5, 0, 5, 10, 15, 20, 25, int.MaxValue },
                      new int[] { int.MinValue, -15, -10, -5, 0, 5, 10, 15, 20, 25, int.MaxValue })]

            [TestCase(new int[] { 1000, 25, 20, 15, 10, 5, 0, -5, -10, -15, -1000 },
                      new int[] { -1000, -15, -10, -5, 0, 5, 10, 15, 20, 25, 1000 })]

            [TestCase(new int[] { int.MinValue, 20, 15, -15, -5, 0, 5, 10, -10, 25, int.MaxValue },
                      new int[] { int.MinValue, -15, -10, -5, 0, 5, 10, 15, 20, 25, int.MaxValue })]

            [TestCase(new int[] { int.MaxValue, -15, -10, -5, 0, 5, 10, 15, 20, 25, int.MinValue },
                      new int[] { int.MinValue, -15, -10, -5, 0, 5, 10, 15, 20, 25, int.MaxValue })]

            [TestCase(new int[] { int.MinValue, -15, -10, 10, 5, 0, -5, 15, 20, 25, int.MaxValue },
                      new int[] { int.MinValue, -15, -10, -5, 0, 5, 10, 15, 20, 25, int.MaxValue })]

            [TestCase(new int[] { -15, int.MaxValue, 10, 15, int.MinValue, 20, 25, 5, 0, -10, -5 },
                      new int[] { int.MinValue, -15, -10, -5, 0, 5, 10, 15, 20, 25, int.MaxValue })]

            [TestCase(new int[] { 10, 10, -10, 10, 15, 15, -15, 15, -15 },
                      new int[] { -15, -15, -10, 10, 10, 10, 15, 15, 15 })]

            public void SortTest(int[] array, int[] exeptedResult)
            {
                _quickSort.Sort(array, (f, s) => f.CompareTo(s));

                AreEqualResult(array, exeptedResult);
            }
        }

        public class QuickSortRecursionTests
        {
            QuickSortAlgoritmRecursion<int> _quickSort;

            [SetUp]
            public void SetUp()
            {
                _quickSort = new QuickSortAlgoritmRecursion<int>();
            }

            [TestCase(new int[] { 12, 9, 3, 7, 14, 11, 6, 2, 10, 5 },
                      new int[] { 2, 3, 5, 6, 7, 9, 10, 11, 12, 14 })]

            [TestCase(new int[] { int.MinValue, -15, -10, -5, 0, 5, 10, 15, 20, 25, int.MaxValue },
                      new int[] { int.MinValue, -15, -10, -5, 0, 5, 10, 15, 20, 25, int.MaxValue })]

            [TestCase(new int[] { 1000, 25, 20, 15, 10, 5, 0, -5, -10, -15, -1000 },
                      new int[] { -1000, -15, -10, -5, 0, 5, 10, 15, 20, 25, 1000 })]

            [TestCase(new int[] { int.MinValue, 20, 15, -15, -5, 0, 5, 10, -10, 25, int.MaxValue },
                      new int[] { int.MinValue, -15, -10, -5, 0, 5, 10, 15, 20, 25, int.MaxValue })]

            [TestCase(new int[] { int.MaxValue, -15, -10, -5, 0, 5, 10, 15, 20, 25, int.MinValue },
                      new int[] { int.MinValue, -15, -10, -5, 0, 5, 10, 15, 20, 25, int.MaxValue })]

            [TestCase(new int[] { int.MinValue, -15, -10, 10, 5, 0, -5, 15, 20, 25, int.MaxValue },
                      new int[] { int.MinValue, -15, -10, -5, 0, 5, 10, 15, 20, 25, int.MaxValue })]

            [TestCase(new int[] { -15, int.MaxValue, 10, 15, int.MinValue, 20, 25, 5, 0, -10, -5 },
                      new int[] { int.MinValue, -15, -10, -5, 0, 5, 10, 15, 20, 25, int.MaxValue })]

            [TestCase(new int[] { 10, 10, -10, 10, 15, 15, -15, 15, -15 },
                      new int[] { -15, -15, -10, 10, 10, 10, 15, 15, 15 })]

            public void SortTest(int[] array, int[] exeptedResult)
            {
                _quickSort.Sort(array, (f, s) => f.CompareTo(s));

                AreEqualResult(array, exeptedResult);
            }
        }

        public static void AreEqualResult(int[] result, int[] exeptedResult)
        {
            Console.WriteLine("Array:\n");

            foreach(var element in result)
            {
                Console.Write(element + " ");
            }

            Console.WriteLine("\nExepted Sorted Result:\n");

            foreach(int element in exeptedResult)
            {
                Console.Write(element + " ");
            }

            Assert.That(result.Length == exeptedResult.Length, "Different Length!");

            for(int i = 0; i < result.Length; i++)
            {
                Assert.That(result[i] == exeptedResult[i], $"{i} Resul is different!");
            }
        }
    }
}

