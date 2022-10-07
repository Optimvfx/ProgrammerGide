using System;
using System.Collections.Generic;

namespace Extensions
{
    public class CollectionsExtensions
    {
        private Random _random;

        public CollectionsExtensions(Random random)
        {
            _random = random;
        }

        public T GetRandomElement<T>(IReadOnlyList<T> collection)
        {
            var randomIndex = _random.Next(collection.Count);

            return collection[randomIndex];
        }

        public List<int> GenearateRandomCollection(uint count, int maxNumber)
        {
            var list = new List<int>();

            for(int i = 0; i < count; i++)
                list.Add(_random.Next(maxNumber));

            return list;
        }
    }
}
