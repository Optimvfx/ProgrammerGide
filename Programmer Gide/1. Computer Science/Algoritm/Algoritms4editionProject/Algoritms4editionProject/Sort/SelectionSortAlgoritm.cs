using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Extensions;

namespace AlgoritmsProject
{
    public class SellectionSortAlgoritm<T> : SortAlgoritm<T>
    {
        public T[] Sort(IEnumerable<T> collection, Func<T,T, int> comapairMetod)
        {
            var arrray = collection.ToArray();

            Sort(arrray, comapairMetod);

            return arrray;
        }

        public void Sort(T[] array, Func<T, T, int> comapairMetod)
        {
            for (int i = 0; i < array.Length; i++)
            {
                var smallestElementIndex = i;

                for(int j = i; j < array.Length; j++)
                {
                    if (comapairMetod(array[smallestElementIndex], array[j]) >= 0)
                        smallestElementIndex = j;
                }

                ChangePlaces(ref array[smallestElementIndex], ref array[i]);
            }
        }

        protected override void Work(uint hardnes, Random random, Stopwatch stopwatch)
        {
            stopwatch.Stop();

            var collectionExtentions = new CollectionsExtensions(random);

            var randomCollection = collectionExtentions.GenearateRandomCollection(hardnes, (int)hardnes).ToArray();

            var sellectionSort = new SellectionSortAlgoritm<int>();

            stopwatch.Start();

            sellectionSort.Sort(randomCollection, (f,s) => f);
        }
    }
}
