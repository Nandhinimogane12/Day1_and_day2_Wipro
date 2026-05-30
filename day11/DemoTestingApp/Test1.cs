using Microsoft.VisualStudio.TestTools.UnitTesting;
using DemoTestingApp;

namespace Demo.Tests;

[TestClass]
public class Test1
{
    [TestMethod]
    public void TestMethod1()
    {
        var Calc = new Calculator();
        int result = Calc.Multiply(2, 6);
        Assert.AreEqual(12, result);
    }
}