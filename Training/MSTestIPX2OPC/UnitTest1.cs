namespace MSTestIPX2OPC;

[TestClass]
public class UnitTest1
{
    [TestMethod]
    public void TestMethod1()
    {
        Assert.IsTrue(1 == 1);
    }

    [TestMethod]
    public void TestMethod2()
    {
        Assert.IsTrue(true);
    }

    [TestMethod]
    public void TestMethod3()
    {
        Assert.IsFalse(0 != 1);
    }

}