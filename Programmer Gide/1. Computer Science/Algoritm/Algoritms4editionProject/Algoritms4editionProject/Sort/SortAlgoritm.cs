namespace AlgoritmsProject
{
    public abstract class SortAlgoritm<T> : Algoritm
    {
        public void ChangePlaces(ref T first, ref T second)
        {
            var temp = first;

            first = second;
            second = temp;
        }

        protected struct Bounds
        {
            public readonly int Left;
            public readonly int Right;

            public int Center => (Left + Right) / 2;

            public int Length => Right - Left;

            public Bounds(int left, int right)
            {
                Left = left;
                Right = right;
            }
        }
    }
}
