using System;
using System.Diagnostics; 

namespace Algoritms4editionProject
{
    public class EqlidAlgoritm : Algoritm
    {
        public ulong CalkulateRecursion(ulong dividend, ulong divisioned)
        {
            if (divisioned == 0)
                return dividend;

            var result = dividend % divisioned;

            return CalkulateRecursion(dividend, result);
        }

        public ulong Calkulate(ulong dividend, ulong divisioned, out int cycleCount)
        {
            var nextCycle = new CycleInfo(dividend, divisioned);

            cycleCount = 0;

            while (nextCycle.Divisioned != 0)
            {
                nextCycle = new CycleInfo(nextCycle.Divisioned, nextCycle.Node);
                cycleCount++;
            }

            return nextCycle.Dividend;
        }

        protected override void Work(uint hardnes, Random random, Stopwatch stopwatch)
        {
           CalkulateRecursion(hardnes, (uint)random.Next(0,10));
        }

        private struct CycleInfo
        {
            public readonly ulong Dividend;
            public readonly ulong Divisioned;

            public ulong Node => Dividend % Divisioned;

            public CycleInfo(ulong dividend, ulong divisioned)
            {
                Dividend = dividend;
                Divisioned = divisioned;
            }
        }
    }
}
