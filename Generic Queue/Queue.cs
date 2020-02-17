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

        /// <summary>Initializes a new instance of the <see cref="Queue{T}"/> class.</summary>
        public Queue()
        {
            this.arr = new T[2];
            this.currentSize = 0;
        }

        /// <summary>Gets the current size of the queue.</summary>
        /// <value>The size of the current.</value>
        public int CurrentSize
        {
            get { return this.currentSize; }
        }

        /// <summary>  Adds the element to the queue.</summary>
        /// <param name="element">The element.</param>
        public void Enqueue(T element)
        {
            if (this.currentSize == this.arr.Length)
            {
                Array.Resize(ref this.arr, (int)(this.arr.Length * GrowMultiplier));
            }

            this.arr[this.currentSize] = element;
            this.currentSize++;
        }

        /// <summary> Gets the tail element from the queue.</summary>
        /// <returns>Returns the tail element from the queue.</returns>
        /// <exception cref="System.ArgumentNullException">The queue is empty.</exception>
        public T Peek()
        {
            if (this.currentSize == 0)
            {
                throw new ArgumentNullException($"{nameof(this.currentSize)} is zero.");
            }

            T returnValue = this.arr[0];
            return returnValue;
        }

        /// <summary> Gets the tail element from the queue and removes it.</summary>
        /// <returns>Returns the tail element from the queue.</returns>
        /// <exception cref="System.ArgumentNullException">The queue is empty.</exception>
        public T Dequeue()
        {
            if (this.currentSize == 0)
            {
                throw new ArgumentNullException($"{nameof(this.currentSize)} is zero.");
            }

            T removed = this.Peek();
            int counter = 0;
            while (counter + 1 < this.currentSize)
            {
                this.arr[counter] = this.arr[counter + 1];
                counter++;
            }

            return removed;
        }

        /// <summary>Returns an enumerator that iterates through a collection.</summary>
        /// <returns>An <see cref="T:System.Collections.IEnumerator"/> object that can be used to iterate through the collection.</returns>
        public IEnumerator GetEnumerator()
        {
            return new GenericQueueEnumerator<T>(this);
        }

        /// <summary>Returns an enumerator that iterates through the collection.</summary>
        /// <returns>An enumerator that can be used to iterate through the collection.</returns>
        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            return new GenericQueueEnumerator<T>(this);
        }

        /// <summary>Gets the element from the array.</summary>
        /// <param name="number">The number.</param>
        /// <returns>The array's element.</returns>
        internal T GetElement(int number)
        {
            return this.arr[number];
        }
    }
}
