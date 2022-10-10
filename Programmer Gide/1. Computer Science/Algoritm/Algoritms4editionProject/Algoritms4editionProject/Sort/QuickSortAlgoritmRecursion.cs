using Extensions;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace AlgoritmsProject
{
    public class QuickSortAlgoritmRecursion<T> : SortAlgoritm<T>
    {
        public T[] Sort(IEnumerable<T> collection, Func<T, T, int> comapairMetod)
        {
            var arrray = collection.ToArray();

            Sort(arrray, comapairMetod);

            return arrray;
        }

        public void Sort(T[] array, Func<T, T, int> comapairMetod)
        {
            QuickSort(array, 0, array.Length - 1, comapairMetod);
        }

        private void QuickSort(T[] array, int left, int right, Func<T, T, int> comapairMetod)
        {
            if (left >= right)
                return;

            var center = Partition(array, left, right, comapairMetod);

            QuickSort(array, left, center - 1, comapairMetod);
            QuickSort(array, center + 1, right, comapairMetod);
        }

        private int Partition(T[] array, int left, int right, Func<T, T, int> comapairMetod)
        {
            var exchangeableIndex = left;

            for(int i = left; i < right; i++)
            {
                if (comapairMetod(array[i], array[right]) <= 0)
                {
                    ChangePlaces(ref array[exchangeableIndex], ref array[i]);

                    exchangeableIndex++;
                }
            }

            ChangePlaces(ref array[exchangeableIndex], ref array[right]);

            return exchangeableIndex;
        }

        protected override void Work(uint hardnes, Random random, Stopwatch stopwatch)
        {
            stopwatch.Stop();

            var collectionExtentions = new CollectionsExtensions(random);

            var randomCollection = collectionExtentions.GenearateRandomCollection(hardnes, (int)hardnes).ToArray();

            var quickSort = new QuickSortAlgoritmRecursion<int>();

            stopwatch.Start();

            quickSort.Sort(randomCollection, (f, s) => f);
        }
    }
}

