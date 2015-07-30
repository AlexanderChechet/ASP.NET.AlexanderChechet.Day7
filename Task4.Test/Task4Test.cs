using System;
using System.Drawing;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Task4.Test
{
    [TestClass]
    public class Task4Test
    {
        [TestMethod]
        public void BinarySearchFirst()
        {
            int[] array = {1, 3, 7, 11, 14, 15, 18};
            
            int result = BinarySearch<int>.Find(array, 1);

            Assert.AreEqual(0, result);
        }

        [TestMethod]
        public void BinarySearchLast()
        {
            int[] array = { 1, 3, 7, 11, 14, 15, 18 };

            int result = BinarySearch<int>.Find(array, 18);

            Assert.AreEqual(6, result);
        }

        [TestMethod]
        public void BinarySearchMiddle()
        {
            int[] array = { 1, 3, 7, 11, 14, 15, 18 };

            int result = BinarySearch<int>.Find(array, 11);

            Assert.AreEqual(3, result);
        }

        [TestMethod]
        public void BinarySearchUsual()
        {
            int[] array = { 1, 3, 7, 11, 14, 15, 18 };

            int result = BinarySearch<int>.Find(array, 15);

            Assert.AreEqual(5, result);
        }

        [TestMethod]
        public void BinarySearchNoElement()
        {
            int[] array = { 1, 3, 7, 11, 14, 15, 18 };

            int result = BinarySearch<int>.Find(array, 2);

            Assert.AreEqual(-1, result);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void BinarySearchNoComparer()
        {
            Point[] array = { new Point(1, 1) };

            BinarySearch<Point>.Find(array, new Point(1, 1));
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void BinarySearchNoArray()
        {
            int[] array = null;

            BinarySearch<int>.Find(array, 1);
        }
    }
}
