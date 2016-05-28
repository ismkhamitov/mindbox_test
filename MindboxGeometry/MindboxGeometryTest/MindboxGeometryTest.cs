using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using MindboxGeometry;
using NUnit.Framework.Interfaces;

namespace MindboxGeometryTest
{
    [TestFixture]
    public class MindboxGeometryTest
    {
        [Test]
        public void TestTriangle1()
        {
            Triangle tr = new Triangle(3, 4, 5);

            Assert.AreEqual(true, tr.IsRectangular);
            Assert.AreEqual(6, tr.Area);
        }

        [Test]
        public void TestTriangle2()
        {
            Triangle tr = null;
            Assert.Throws<ArgumentException>(() => tr = new Triangle(3, 7, 3));
        }

        [Test]
        public void TestTriangle3()
        {
            Triangle tr = new Triangle(3, 4, 3);
            
            Assert.AreEqual(false, tr.IsRectangular);
            Assert.AreEqual(Math.Sqrt(5) * 2, tr.Area);
        }
    }
}
