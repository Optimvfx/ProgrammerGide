using Extensions;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace AlgoritmsProject
{
    public class MergeSortAlgoritm<T> : SortAlgoritm<T>
    {
        public T[] Sort(IEnumerable<T> collection, Func<T, T, int> comapairMetod)
        {
            var arrray = collection.ToArray();

            Sort(arrray, comapairMetod);

            return arrray;
        }

        public void Sort(T[] array, Func<T, T, int> comapairMetod)
        {
            var boundsStack = new Stack<Bounds>();
            var saveBoundsStack = new Stack<Bounds>();
            
            boundsStack.Push(new Bounds(0, array.Length - 1));

            while (boundsStack.Count > 0)
            {
                var currentBounds = boundsStack.Pop();

                if (currentBounds.Length <= 0)
                    continue;

                saveBoundsStack.Push(currentBounds);

                var leftBounds = new Bounds(currentBounds.Center + 1, currentBounds.Right);
                var rightBounds = new Bounds(currentBounds.Left, currentBounds.Center);

                boundsStack.Push(rightBounds);
                boundsStack.Push(leftBounds);
            }

            foreach (var bounds in saveBoundsStack)
            {     
                Merage(array, bounds, comapairMetod);
            }
        }

        private void Merage(T[] array, Bounds bounds, Func<T, T, int> comapairMetod)
        {
            var leftPartLength = bounds.Center - bounds.Left + 1;
            var rightPartLength = bounds.Right - bounds.Center;

            var leftPartArray = new T[leftPartLength];

            for (int leftPartIndex = 0; leftPartIndex < leftPartLength; leftPartIndex++)
            {
                leftPartArray[leftPartIndex] = array[leftPartIndex + bounds.Left];
            }

            var rightPartArray = new T[rightPartLength];

            for (int rigthPartIndex = 0; rigthPartIndex < rightPartLength; rigthPartIndex++)
            {
                rightPartArray[rigthPartIndex] = array[bounds.Center + 1 + rigthPartIndex];
            }

            int leftPartCompairIndex = 0;
            int rigthPartComapirIndex = 0;

            for (int i = bounds.Left; i <= bounds.Right; i++)
            {
                if (leftPartCompairIndex >= leftPartArray.Length)
                {
                    for (int j = i; j <= bounds.Right; j++)
                    {
                        array[j] = rightPartArray[rigthPartComapirIndex];
                        rigthPartComapirIndex++;
                    }

                    return;
                }
                else if (rigthPartComapirIndex >= rightPartArray.Length)
                {
                    for (int j = i; j <= bounds.Right; j++)
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

            var merageSort = new MergeSortAlgoritm<int>();

            stopwatch.Start();

            merageSort.Sort(randomCollection, (f, s) => f);
        }
    }
}
