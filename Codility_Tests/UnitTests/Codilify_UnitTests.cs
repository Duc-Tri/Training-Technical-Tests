using Codility_Tests;
using System;

namespace UnitTests
{
    [TestClass]
    public class Codilify_UnitTests
    {
        [TestMethod]
        public void L1_BinaryGapTest()
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
        public void L2_OddElement()
        {
            Assert.AreEqual(7, L02_Arrays.OddElement(new int[] { 9, 3, 9, 3, 9, 7, 9 }));
        }

        [TestMethod]
        public void L2_CyclicRotation()
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
        public void L3_FrogJmp()
        {
            Assert.AreEqual(3, L03_TimeComplexity.FrogJmp(10, 85, 30));
        }


        [TestMethod]
        public void L3_PermMissingElem()
        {
            Assert.AreEqual(1, L03_TimeComplexity.PermMissingElem(new int[] { 2 }));
            Assert.AreEqual(4, L03_TimeComplexity.PermMissingElem(new int[] { 2, 3, 1, 5 }));
            Assert.AreEqual(14, L03_TimeComplexity.PermMissingElem(new int[] { 6, 7, 8, 9, 10, 11, 2, 3, 1, 5, 12, 13, 4, 15 }));
        }

    }

}