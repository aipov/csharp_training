using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace addressbook_web_tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethodSquare()
        {
            Square s1 = new Square(17);
            Square s2 = new Square(85);
            Square s3 = s1;
            Assert.AreEqual(s1.Size, 17);
            Assert.AreEqual(s2.Size, 85);
            Assert.AreEqual(s1.Size, 17);

            s3.Size=28;
            Assert.AreEqual(s1.Size, 28);

        }

        [TestMethod]
        public void TestMethodCircle()
        {
            Circle s1 = new Circle(17);
            Circle s2 = new Circle(85);
            Circle s3 = s1;
            Assert.AreEqual(s1.Radius, 17);
            Assert.AreEqual(s2.Radius, 85);
            Assert.AreEqual(s1.Radius, 17);

            s3.Radius = 28;
            Assert.AreEqual(s1.Radius, 28);

        }
    }
}
