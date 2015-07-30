using System;
using System.Collections.Generic;

namespace Task4
{
    public static class BinarySearch<T>
    {
        public static int Find(T[] array, T item)
        {
            int index = -1;
            int left = 0;
            if (array == null)
                throw new NullReferenceException();
            var comparable = item as IComparable<T>;
            if (comparable == null)
                throw new InvalidOperationException();
            int right = array.Length - 1;
            while (left <= right)
            {
                int middle = (left + right)/2;
                int compareResult = comparable.CompareTo(array[middle]);
                if (compareResult == 0)
                {
                    index = middle;
                    break;
                }
                if (compareResult > 0)
                {
                    left = middle + 1;
                }
                else
                {
                    right = middle - 1;
                }
            }
            return index > 0 ? index : -((left + right) / 2 + 1);
        }
    }
}
