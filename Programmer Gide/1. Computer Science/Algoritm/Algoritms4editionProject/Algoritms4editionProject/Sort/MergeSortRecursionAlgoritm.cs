using Extensions;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace AlgoritmsProject
{
    public class MergeSortAlgoritmRecursion<T> : SortAlgoritm<T>
    {
        public T[] Sort(IEnumerable<T> collection, Func<T, T, int> comapairMetod)
        {
            var arrray = collection.ToArray();

            Sort(arrray, comapairMetod);

            return arrray;
        }

        public void Sort(T[] array, Func<T, T, int> comapairMetod)
        {
            MerageSort(array, 0, array.Length - 1, comapairMetod);
        }

        private void MerageSort(T[] array, int left, int right, Func<T, T, int> comapairMetod)
        {
            if (left >= right)
                return;

            var center = (left + right) / 2;

            MerageSort(array, left, center, comapairMetod);
            MerageSort(array, center + 1, right, comapairMetod);

            Merage(array, left, center, right, comapairMetod);
        }

        private void Merage(T[] array, int left, int center, int right, Func<T, T, int> comapairMetod)
        {
            var leftPartLength = center - left + 1;
            var rightPartLength = right - center;

            var leftPartArray = new T[leftPartLength];

            for (int leftPartIndex = 0; leftPartIndex < leftPartLength; leftPartIndex++)
            {
                leftPartArray[leftPartIndex] = array[leftPartIndex + left];
            }

            var rightPartArray = new T[rightPartLength];

            for (int rigthPartIndex = 0; rigthPartIndex < rightPartLength; rigthPartIndex++)
            {
                rightPartArray[rigthPartIndex] = array[center + 1 + rigthPartIndex];
            }

            int leftPartCompairIndex = 0;
            int rigthPartComapirIndex = 0;

            for (int i = left; i <= right; i++)
            {
                if (leftPartCompairIndex >= leftPartArray.Length)
                {
                    for (int j = i; j <= right; j++)
                    {
                        array[j] = rightPartArray[rigthPartComapirIndex];
                        rigthPartComapirIndex++;
                    }

                    return;
                }
                else if (rigthPartComapirIndex >= rightPartArray.Length)
                {
                    for (int j = i; j <= right; j++)
                    {
                        array[j] = leftPartArray[leftPartCompairIndex];
                        leftPartCompairIndex++;
                    }

                    return;
                }

                bool leftLargerRigth = comapairMetod(leftPartArray[leftPartCompairIndex], rightPartArray[rigthPartComapirIndex]) < 0;

                if (leftLargerRigth)
                {
                    array[i] = leftPartArray[leftPartCompairIndex];
                  
                    leftPartCompairIndex++;
                }
                else
                {
                    array[i] = rightPartArray[rigthPartComapirIndex];

                    rigthPartComapirIndex++;
                }
            }
        }

        protected override void Work(uint hardnes, Random random, Stopwatch stopwatch)
        {
            stopwatch.Stop();

            var collectionExtentions = new CollectionsExtensions(random);

            var randomCollection = collectionExtentions.GenearateRandomCollection(hardnes, (int)hardnes).ToArray();

            var merageSort = new MergeSortAlgoritmRecursion<int>();

            stopwatch.Start();

            merageSort.Sort(randomCollection, (f, s) => f);
        }
    }
}
