using NUnit.Framework;
using NUnit.Framework.Interfaces;

namespace Lab3
{
    [TestFixture]
    public class MathTest
    {

        /// <summary>
        /// Triangle 1, 1, 1 should exist
        /// </summary>
        [Test]
        public void CanTrinagleExist()
        {
            Assert.IsTrue(Math.IsTriangleCanExist(1, 1, 1));
        }

        [TestCase(200, 1, 300)]
        public void TrinagleExist(float a, float b, float c)
        {
            Assert.IsTrue(!Math.IsTriangleCanExist(a, b, c));
        }

        [TestCase(100, 250, 250, ExpectedResult = true, Description = "Triangle with sides: 100, 250, 250")]
        [TestCase(20, 9, 30, ExpectedResult = true)]
        [TestCase(15, 200, 3, ExpectedResult = false)]
        [TestCase(21, 10, 33, ExpectedResult = false)]
        [TestCase(11, 2, 35, ExpectedResult = false)]
        [TestCase(121, 25, 73, ExpectedResult = false)]
        [TestCase(111, 213, 322, ExpectedResult = true)]
        [TestCase(133, 2275, 32, ExpectedResult = false)]
        public bool TestSequence(float a, float b, float c)
        {
            return Math.IsTriangleCanExist(a, b, c);
        }
    }
}
