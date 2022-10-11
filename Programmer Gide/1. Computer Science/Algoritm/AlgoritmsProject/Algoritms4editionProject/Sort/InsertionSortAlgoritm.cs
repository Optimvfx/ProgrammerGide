using Extensions;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;


namespace AlgoritmsProject
{
    public class InsertionSortAlgoritm<T> : SortAlgoritm<T>
    {
        public T[] Sort(IEnumerable<T> collection, Func<T, T, int> comapairMetod)
        {
            var arrray = collection.ToArray();

            Sort(arrray, comapairMetod);

            return arrray;
        }

        public void Sort(T[] array, Func<T, T, int> comapairMetod)
        {
            for (int i = 0; i < array.Length; i++)
            {
                var key = array[i];

                int j = i - 1;

                while(j >= 0 && comapairMetod(array[j], key) >= 0)
                {
                    ChangePlaces(ref array[j + 1], ref array[j]);

                    j--;
                }

                array[j + 1] = key;
            }
        }

        protected override void Work(uint hardnes, Random random, Stopwatch stopwatch)
        {
            stopwatch.Stop();

            var collectionExtentions = new CollectionsExtensions(random);

            var randomCollection = collectionExtentions.GenearateRandomCollection(hardnes, (int)hardnes).ToArray();

            var insertionSort = new InsertionSortAlgoritm<int>();

            stopwatch.Start();

            insertionSort.Sort(randomCollection, (f, s) => f);
        }
    }
}
