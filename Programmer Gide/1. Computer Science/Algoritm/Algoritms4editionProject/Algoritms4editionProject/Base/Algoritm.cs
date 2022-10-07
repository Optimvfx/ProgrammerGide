using System;
using System.Diagnostics;

namespace Algoritms4editionProject
{
    public abstract class Algoritm
    {
        private readonly uint _warmedUpWorksCount = 4;

        private uint _currentWorkIndex = 0;

        public float GetWorkTime(uint hardnes, Random random)
        {
            var watch = new Stopwatch();
            watch.Start();

            Work(hardnes, random, watch);

            watch.Stop();

            _currentWorkIndex++;

            if (_currentWorkIndex < _warmedUpWorksCount)
            {
                return 0;
            }

            return watch.ElapsedTicks;
        }

        protected abstract void Work(uint hardnes, Random random, Stopwatch stopwatch);
    }
}
