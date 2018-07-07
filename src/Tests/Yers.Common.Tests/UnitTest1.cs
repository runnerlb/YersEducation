using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Yers.Common.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Assert.AreEqual(CommonHelper.GenerateCaptchaCode(5).Length, 5);
            Assert.AreEqual("123".CalcMd5(), "123".CalcMd5());
        }
    }
}