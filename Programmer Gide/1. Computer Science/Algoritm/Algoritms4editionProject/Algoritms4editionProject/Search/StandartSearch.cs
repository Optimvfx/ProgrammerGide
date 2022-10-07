using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using Extensions;

namespace Algoritms4editionProject
{ 
    public class StandartSearchAlgoritm<T> : Algoritm
               where T : IComparable
    {
        private readonly int _compareResultEqual = 0;

        public bool TrySearchElementIndex(IEnumerable<T> sortedCollection, T searching, out int foundedIndex)
        {
            return TrySearchElementIndex(sortedCollection.ToArray(), searching, out foundedIndex);
        }

        public bool TrySearchElementIndex(T[] sortedArray, T searching, out int foundedIndex)
        {
            for(int i = 0; i < sortedArray.Length; i++)
            {
                if (sortedArray[i].CompareTo(searching) == _compareResultEqual)
                {
                    foundedIndex = i;

                    return true;
                }
            }

            foundedIndex = -1;

            return false;
        }


        protected override void Work(uint hardnes, Random random, Stopwatch stopwatch)
        {
            if (hardnes == 0)
                return;

            stopwatch.Stop();

            var extenstions = new CollectionsExtensions(random);
            var collection = extenstions.GenearateRandomCollection(hardnes, (int)hardnes);

            var standartSearch = new StandartSearchAlgoritm<int>();

            stopwatch.Start();

            standartSearch.TrySearchElementIndex(collection, extenstions.GetRandomElement(collection), out int foundedIndex);
        }
    }
}
