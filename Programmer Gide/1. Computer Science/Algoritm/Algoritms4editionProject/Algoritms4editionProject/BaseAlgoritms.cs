using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algoritms4editionProject
{
    public class BaseAlgoritms
    {
        public class EqlidAlgoritm
        {
            public ulong CalkulateRecursion(ulong dividend, ulong divisioned)
            {
                if (divisioned == 0)
                    return dividend;

                var result = dividend % divisioned;

                return CalkulateRecursion(dividend, result);
            }

            public ulong Calkulate(ulong dividend, ulong divisioned, out int cycleCount)
            {
                var nextCycle = new CycleInfo(dividend, divisioned);

                cycleCount = 0;

                while (nextCycle.Divisioned != 0)
                {
                    nextCycle = new CycleInfo(nextCycle.Divisioned, nextCycle.Node);
                    cycleCount++;
                }

                return nextCycle.Dividend;
            }

            private struct CycleInfo
            {
                public readonly ulong Dividend;
                public readonly ulong Divisioned;

                public ulong Node => Dividend % Divisioned;

                public CycleInfo(ulong dividend, ulong divisioned)
                {
                    Dividend = dividend;
                    Divisioned = divisioned;
                }
            }
        }

        public class BinaritySearchAlgoritm<T>
            where T : IComparable
        {
            private readonly int _compareResultEqual = 0;

            public bool TrySearchElementIndexRecursion(IEnumerable<T> sortedCollection,T searching, out int foundedIndex)
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

         /*   public bool TrySearchElementIndex(T[] sortedArray, T searching, out int foundedIndex)
            {
                var mediana = leftIndex + (rightIndex - leftIndex) / 2;

                if (leftIndex >= rightIndex || sortedArray[mediana].CompareTo(searching) == _compareResultEqual)
                {
                    if (sortedArray[mediana].CompareTo(searching) == _compareResultEqual)
                    {
                        foundedIndex = mediana;

                        return true;
                    }
                    else
                    {
                        foundedIndex = 0;
                        return false;
                    }
                }

                if (searching.CompareTo(sortedArray[mediana]) > _compareResultEqual)
                    return TrySearchElementIndexRecursion(sortedArray, searching, mediana + 1, rightIndex, out foundedIndex);
                else
                    return TrySearchElementIndexRecursion(sortedArray, searching, leftIndex, mediana - 1, out foundedIndex);
            }*/

            private bool TrySearchElementIndexRecursion(T[] sortedArray, T searching , int leftIndex, int rightIndex, out int foundedIndex)
            {
                var mediana = leftIndex + (rightIndex - leftIndex) / 2;

                if (leftIndex >= rightIndex || sortedArray[mediana].CompareTo(searching) == _compareResultEqual)
                {
                    if (sortedArray[mediana].CompareTo(searching) == _compareResultEqual)
                    {
                        foundedIndex = mediana;

                        return true;
                    }
                    else
                    {
                        foundedIndex = 0;
                        return false;
                    }
                }

                if (searching.CompareTo(sortedArray[mediana]) > _compareResultEqual)
                    return TrySearchElementIndexRecursion(sortedArray, searching, mediana + 1, rightIndex, out foundedIndex);
                else
                    return TrySearchElementIndexRecursion(sortedArray, searching, leftIndex, mediana - 1, out foundedIndex);
            }
        }
    }
}
