using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Remoting.Messaging;

namespace Task3
{
    public class CustomQueue<T>
    {
        #region private fields

        private T[] array;
        private int currentSize;
        private int capacity;
        private int head;
        private int tail;

        #endregion

        #region Properties

        public T this[int index]
        {
            get 
            { 
                if (index < 0 || index > Count)
                    throw new ArithmeticException();
                return array[(index + head)%Count];
            }
        }
        public int Count { get { return capacity; } }

        #endregion

        #region Ctors
        public CustomQueue()
        {
            capacity = 0;
            head = 0;
            tail = 0;
            currentSize = 20;
            array = new T[currentSize];
        }

        public CustomQueue(int length)
        {
            capacity = 0;
            head = 0;
            tail = 0;
            currentSize = length;
            array = new T[currentSize];
        }
        #endregion

        #region Public methods

        public void Enqueue(T item)
        {
            int temp = GetTail();
            array[temp] = item;
        }

        public T Deque()
        {
            if (capacity > 0)
                return array[GetHead()];
            throw new ArgumentNullException();
        }

        public T Peek()
        {
            if (capacity > 0)
                return array[head];
            throw new ArgumentNullException();
        }

        public T[] ToArray()
        {
            var tempArray = new T[capacity];
            Array.Copy(array, tempArray, capacity);
            return tempArray;
        }

        public IEnumerator GetEnumerator()
        {
            return new CustomIterator(this);
        }

        #endregion

        #region Private methods

        private int GetHead()
        {
            var temp = head;
            head++;
            if (head == currentSize)
                head = 0;
            capacity--;
            return temp;
        }

        private int GetTail()
        {
            var temp = tail;
            tail++;
            capacity++;
            if (tail == currentSize)
                tail = 0;
            if (tail == head && capacity == currentSize)
            {
                IncreaseSize();
            }
            return temp;
        }

        private void IncreaseSize()
        {
            var tempArray = new T[currentSize * 2];
            for (int i = 0; i < currentSize; i++)
            {
                tempArray[i] = array[(head + i) % currentSize];
            }
            array = tempArray;
            head = 0;
            tail = currentSize;
            currentSize *= 2;
        }

        #endregion

        #region private struct iterator

        private struct CustomIterator : IEnumerator<T>
        {
            private readonly CustomQueue<T> collection;
            private readonly int last;
            private int index;

            public CustomIterator(CustomQueue<T> collection)
            {
                this.collection = collection;
                last = collection.Count;
                index = -1;
            }

            public void Dispose()
            {
            }

            public bool MoveNext()
            {
                return ++index < last;
            }

            public void Reset()
            {
                throw new NotSupportedException();
            }

            public T Current
            {
                get { return collection[index]; }
            }

            object IEnumerator.Current
            {
                get { return Current; }
            }
        }

        #endregion
    }
}
