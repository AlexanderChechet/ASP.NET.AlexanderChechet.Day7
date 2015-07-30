using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    public static class Fibonacci
    {
        public static IEnumerable<uint> Numbers(uint length)
        {
            if (length > 0)
                yield return 0;
            uint previous = 0;
            uint next = 1;
            for (int i = 1; i < length; i++)
            {
                uint temp = next;
                next += previous;
                previous = temp;
                yield return previous;
            }
        }
    }
}
