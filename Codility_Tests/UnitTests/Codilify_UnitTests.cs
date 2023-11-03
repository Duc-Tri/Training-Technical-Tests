﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using Codility_Tests;

namespace UnitTests
{
    [TestClass]
    public class Codilify_UnitTests
    {
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
            Assert.AreEqual(true, ForLoop(L02_Arrays.CyclicRotation(new int[] { 3, 8, 9, 7, 6 }, 3),
                                          new int[] { 9, 7, 6, 3, 8 }));
        }

        public bool ForLoop(int[] firstArray, int[] secondArray)
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

    }

}