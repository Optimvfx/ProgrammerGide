using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoritmsTests
{
    public class EqlidAlgoritmTests
    {
        private EqlidAlgoritm _eqlidAlgoritm;

        [SetUp]
        public void Setup()
        {
            _eqlidAlgoritm = new EqlidAlgoritm();
        }

        //Data Validation Source https://planetcalc.ru/3298/
        [TestCase((ulong)20, (ulong)5, 1, (ulong)5)]
        [TestCase(ulong.MaxValue, ulong.MaxValue / 10, 3, (ulong)1)]
        [TestCase(uint.MaxValue, uint.MaxValue / 25, 6, (ulong)1)]
        [TestCase((ulong)98, (ulong)12, 2, (ulong)2)]
        public void EqlidAlgoritmTest(ulong dividend, ulong divisioned, int exceptedCycleCount, ulong exceptedResult)
        {
            var result = _eqlidAlgoritm.Calkulate(dividend, divisioned, out int cycleCount);

            AreEqualResult(result, cycleCount, exceptedResult, exceptedCycleCount);
        }

        //Data Validation Source https://planetcalc.ru/3298/
        [TestCase((ulong)20, (ulong)5, 1, (ulong)5)]
        [TestCase(ulong.MaxValue, ulong.MaxValue / 10, 3, (ulong)1)]
        [TestCase(uint.MaxValue, uint.MaxValue / 25, 6, (ulong)1)]
        [TestCase((ulong)98, (ulong)12, 2, (ulong)2)]
        public void EqlidAlgoritmRecursionTest(ulong dividend, ulong divisioned, int exceptedCycleCount, ulong exceptedResult)
        {
            var result = _eqlidAlgoritm.Calkulate(dividend, divisioned, out int cycleCount);

            AreEqualResult(result, cycleCount, exceptedResult, exceptedCycleCount);
        }

        private void AreEqualResult(ulong result, long cycleCount, ulong exceptedResult, long exceptedCycleCount)
        {
            Assert.That(exceptedResult == result, $"Node {result} != Exepted {exceptedResult}.");
            Assert.That(cycleCount == exceptedCycleCount, $"Cycle count {cycleCount} != Exepted {exceptedCycleCount}.");
        }
    }
}
