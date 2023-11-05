using Microsoft.VisualStudio.TestTools.UnitTesting;
using Codility_Tests;

namespace UnitTests
{
    [TestClass]
    public class Codilify_UnitTests
    {
        public static bool AreArraysEqual(int[] firstArray, int[] secondArray)
        {
            if (firstArray.Length != secondArray.Length)
                return false;
            for (int i = 0; i < firstArray.Length; i++)
            {
                if (firstArray[i] != secondArray[i])
                    return false;
            }
            return true;
        }

        [TestMethod]
        public void L0101()
        {
            // Given N = 1041 the function should return 5, because N has binary representation 10000010001 and so its longest binary gap is of length 5.
            // Given N = 32 the function should return 0, because N has binary representation '100000' and thus no binary gaps.
            Assert.AreEqual(5, L01_Iterations.BinaryGap(1041));
            Assert.AreEqual(0, L01_Iterations.BinaryGap(32));
            Assert.AreEqual(2, L01_Iterations.BinaryGap(9));
            Assert.AreEqual(4, L01_Iterations.BinaryGap(529));
            Assert.AreEqual(1, L01_Iterations.BinaryGap(20));
            Assert.AreEqual(0, L01_Iterations.BinaryGap(15));
        }

        [TestMethod]
        public void L0201()
        {
            Assert.AreEqual(7, L02_Arrays.OddElement(new int[] { 9, 3, 9, 3, 9, 7, 9 }));
        }

        [TestMethod]
        public void L0202()
        {
            Assert.AreEqual(true, AreArraysEqual(L02_Arrays.CyclicRotation(new int[] { 3, 8, 9, 7, 6 }, 3),
                                          new int[] { 9, 7, 6, 3, 8 }));
        }

        [TestMethod]
        public void L0301()
        {
            Assert.AreEqual(3, L03_TimeComplexity.FrogJmp(10, 85, 30));
        }

        [TestMethod]
        public void L0302()
        {
            Assert.AreEqual(1, L03_TimeComplexity.PermMissingElem(new int[] { 2 }));
            Assert.AreEqual(4, L03_TimeComplexity.PermMissingElem(new int[] { 2, 3, 1, 5 }));
            Assert.AreEqual(14, L03_TimeComplexity.PermMissingElem(new int[] { 6, 7, 8, 9, 10, 11, 2, 3, 1, 5, 12, 13, 4, 15 }));
        }

        [TestMethod]
        public void L0303()
        {
            Assert.AreEqual(2, L03_TimeComplexity.TapeEquilibrium(new int[] { 3, 1 }));
            Assert.AreEqual(1, L03_TimeComplexity.TapeEquilibrium(new int[] { 3, 1, 2, 4, 3 }));
        }

        [TestMethod]
        public void L0401()
        {
            Assert.AreEqual(6, L04_CountingElements.FrogRiverOne(5, new int[] { 1, 3, 1, 4, 2, 3, 5, 4 }));
            Assert.AreEqual(-1, L04_CountingElements.FrogRiverOne(3, new int[] { 1, 2, 1, 2, 2, 1, 1, 2 }));
        }

        [TestMethod]
        public void L0402()
        {
            Assert.AreEqual(1, L04_CountingElements.PermCheck(new int[] { 1, 3, 2 }));
            Assert.AreEqual(0, L04_CountingElements.PermCheck(new int[] { 4, 1, 3 }));
        }

        [TestMethod]
        public void L0403()
        {
            Assert.AreEqual(true, AreArraysEqual(L04_CountingElements.MaxCounters(5, new int[] { 3, 4, 4, 6, 1, 4, 4 }),
                              new int[] { 3, 2, 2, 4, 2 }));
        }

        [TestMethod]
        public void L0404()
        {
            Assert.AreEqual(5, L04_CountingElements.MissingInteger(new int[] { 1, 3, 4, 6, 1, 2 }));
            Assert.AreEqual(4, L04_CountingElements.MissingInteger(new int[] { 1, 2, 3 }));
            Assert.AreEqual(1, L04_CountingElements.MissingInteger(new int[] { -1, -3 }));
        }

        [TestMethod]
        public void L0501()
        {
            Assert.AreEqual(5, L05_PrefixSums.PassingCars(new int[] { 0, 1, 0, 1, 1 }));
        }

        [TestMethod]
        public void L0502()
        {
            Assert.AreEqual(3, L05_PrefixSums.CountDiv(6, 11, 2));
            Assert.AreEqual(1, L05_PrefixSums.CountDiv(0, 0, 11));
        }


        [TestMethod]
        public void L0503()
        {
            Assert.AreEqual(true, AreArraysEqual(L05_PrefixSums.GenomicRangeQuery("CAGCCTA", new int[] { 2, 5, 0 }, new int[] { 4, 5, 6 }),
                                                 new int[] { 2, 4, 1 }));
        }

        [TestMethod]
        public void L0504()
        {
            Assert.AreEqual(1, L05_PrefixSums.MinAvgTwoSlice(new int[] { 4, 2, 2, 5, 1, 5, 8 }));
        }

        [TestMethod]
        public void L0601()
        {
            Assert.AreEqual(3, L06_Sorting.Distinct(new int[] { 2, 1, 1, 2, 3, 1 }));
        }

    }
}