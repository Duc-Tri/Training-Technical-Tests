using Codility_Tests;

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

    }
}