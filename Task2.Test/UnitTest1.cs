using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Task2.Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestZero()
        {
            var array = (uint[])Fibonacci.Numbers(0).ToArray().Clone();

            var result = new uint[0];

            bool flag = true;
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] != result[i])
                {
                    flag = false;
                    break;
                }
            }
            Assert.IsTrue(flag);
        }

        [TestMethod]
        public void TestOne()
        {
            var array = (uint[])Fibonacci.Numbers(1).ToArray().Clone();

            var result = new uint[]{0};

            bool flag = true;
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] != result[i])
                {
                    flag = false;
                    break;
                }
            }
            Assert.IsTrue(flag);
        }

        [TestMethod]
        public void TestTwo()
        {
            uint[] array = (uint[])Fibonacci.Numbers(2).ToArray().Clone();

            uint[] result = { 0, 1 };

            bool flag = true;
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] != result[i])
                {
                    flag = false;
                    break;
                }
            }
            Assert.IsTrue(flag);
        }

        [TestMethod]
        public void TestSeven()
        {
            uint[] array = (uint[])Fibonacci.Numbers(2).ToArray().Clone();

            uint[] result = { 0, 1, 1, 2, 3, 5, 8 };

            bool flag = true;
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] != result[i])
                {
                    flag = false;
                    break;
                }
            }
            Assert.IsTrue(flag);
        }
    }
}
