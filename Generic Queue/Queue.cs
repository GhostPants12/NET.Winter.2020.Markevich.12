using System;
using System.Collections;
using System.Collections.Generic;

namespace GenericQueue
{
    public class Queue<T> : IEnumerable<T>
    {
        private const double GrowMultiplier = 1.5;
        private T[] arr;
        private int currentSize;

        public Queue()
        {
            this.arr = new T[2];
            this.currentSize = 0;
        }

        public int CurrentSize
        {
            get { return this.currentSize; }
        }

        public void Enqueue(T element)
        {
            if (this.currentSize == this.arr.Length)
            {
                Array.Resize(ref this.arr, (int)(this.arr.Length * GrowMultiplier));
            }

            this.arr[this.currentSize] = element;
            this.currentSize++;
        }

        public T Peek()
        {
            if (this.currentSize == 0)
            {
                throw new NullReferenceException("The queue is empty.");
            }

            T returnValue = this.arr[0];
            return returnValue;
        }

        public T Dequeue()
        {
            T removed = this.Peek();
            int counter = 0;
            while (counter + 1 < this.currentSize)
            {
                this.arr[counter] = this.arr[counter + 1];
                counter++;
            }

            return removed;
        }

        public IEnumerator GetEnumerator()
        {
            return new GenericQueueEnumerator<T>(this);
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            return new GenericQueueEnumerator<T>(this);
        }

        internal T GetElement(int i)
        {
            return this.arr[i];
        }
    }
}
