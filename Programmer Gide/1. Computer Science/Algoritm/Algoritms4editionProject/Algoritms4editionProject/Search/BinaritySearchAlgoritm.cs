using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Extensions;

namespace Algoritms4editionProject
{
    public class BinaritySearchAlgoritm<T> : Algoritm
               where T : IComparable
    {
        private readonly int _compareResultEqual = 0;
        private readonly int _notFoundedResultIndex = -1;

        public bool TrySearchElementIndexRecursion(IEnumerable<T> sortedCollection, T searching, out int foundedIndex)
        {
            return TrySearchElementIndexRecursion(sortedCollection.ToArray(), searching, out foundedIndex);
        }

        public bool TrySearchElementIndexRecursion(T[] sortedArray, T searching, out int foundedIndex)
        {
            return TrySearchElementIndexRecursion(sortedArray, searching, 0, sortedArray.Length - 1, out foundedIndex);
        }

        public bool TrySearchElementIndex(IEnumerable<T> sortedCollection, T searching, out int foundedIndex)
        {
            return TrySearchElementIndex(sortedCollection.ToArray(), searching, out foundedIndex);
        }

        public bool TrySearchElementIndex(T[] sortedArray, T searching, out int foundedIndex)
        {
            int leftIndex = 0;
            int rightIndex = sortedArray.Length - 1;
            int mediana = 0;

            while (leftIndex < rightIndex)
            {
                mediana = leftIndex + (rightIndex - leftIndex) / 2;

                var compareResult = sortedArray[mediana].CompareTo(searching);
                
                if(compareResult == _compareResultEqual)
                {
                    foundedIndex = mediana;

                    return true;
                }
                else if (compareResult > _compareResultEqual)
                {
                    leftIndex = mediana + 1;
                }
                else
                {
                    rightIndex = mediana - 1;
                }
            }

            foundedIndex = _notFoundedResultIndex;

            return false;
        }

        private bool TrySearchElementIndexRecursion(T[] sortedArray, T searching, int leftIndex, int rightIndex, out int foundedIndex)
        {
            var mediana = leftIndex + (rightIndex - leftIndex) / 2;

            var compareResult = sortedArray[mediana].CompareTo(searching);

            if (compareResult == _compareResultEqual)
            {
                foundedIndex = mediana;

                return true;
            }

            if (leftIndex >= rightIndex)
            {
                foundedIndex = _notFoundedResultIndex;
                return false;
            }

            if (searching.CompareTo(sortedArray[mediana]) > _compareResultEqual)
                return TrySearchElementIndexRecursion(sortedArray, searching, mediana + 1, rightIndex, out foundedIndex);
            else
                return TrySearchElementIndexRecursion(sortedArray, searching, leftIndex, mediana - 1, out foundedIndex);
        }

        protected override void Work(uint hardnes, Random random, Stopwatch stopwatch)
        {
            if (hardnes == 0)
                return;

            stopwatch.Stop();

            var extenstions = new CollectionsExtensions(random);
            var collection = extenstions.GenearateRandomCollection(hardnes, (int)hardnes).
                OrderBy(value => value).ToList();

            var binarySearch = new BinaritySearchAlgoritm<int>();

            stopwatch.Start();

            binarySearch.TrySearchElementIndex(collection, extenstions.GetRandomElement(collection), out int foundedIndex);
        }
    }
}
