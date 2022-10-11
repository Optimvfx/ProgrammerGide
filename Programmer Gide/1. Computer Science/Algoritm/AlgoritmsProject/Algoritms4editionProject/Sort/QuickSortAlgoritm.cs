using Extensions;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace AlgoritmsProject
{
    public class QuickSortAlgoritm<T>: SortAlgoritm<T>
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

            boundsStack.Push(new Bounds(0, array.Length - 1));

            while (boundsStack.Count > 0)
            {
                var currentBounds = boundsStack.Pop();

                if (currentBounds.Length <= 0)
                    continue;

                var center = Partition(array, currentBounds, comapairMetod);

                var leftBounds = new Bounds(currentBounds.Left, center -1);
                var rightBounds = new Bounds(center + 1, currentBounds.Right);

                boundsStack.Push(leftBounds);
                boundsStack.Push(rightBounds);
            }
        }

        private int Partition(T[] array, Bounds bounds, Func<T, T, int> comapairMetod)
        {
            var exchangeableIndex = bounds.Left;

            for (int i = bounds.Left; i < bounds.Right; i++)
            {
                if (comapairMetod(array[i], array[bounds.Right]) <= 0)
                {
                    ChangePlaces(ref array[exchangeableIndex], ref array[i]);

                    exchangeableIndex++;
                }
            }

            ChangePlaces(ref array[exchangeableIndex], ref array[bounds.Right]);

            return exchangeableIndex;
        }

        protected override void Work(uint hardnes, Random random, Stopwatch stopwatch)
        {
            stopwatch.Stop();

            var collectionExtentions = new CollectionsExtensions(random);

            var randomCollection = collectionExtentions.GenearateRandomCollection(hardnes, (int)hardnes).ToArray();

            var quickSort = new QuickSortAlgoritm<int>();

            stopwatch.Start();

            quickSort.Sort(randomCollection, (f, s) => f);
        }
    }
}
