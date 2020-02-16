using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace GenericQueue
{
    public class GenericQueueEnumerator<T> : IEnumerator<T>
    {
        private readonly Queue<T> queue;
        private int position = -1;

        public GenericQueueEnumerator(Queue<T> queue)
        {
            this.queue = queue;
        }

        public T Current
        {
            get => this.queue.GetElement(this.position);
        }

        object IEnumerator.Current => this.Current;

        public bool MoveNext()
        {
            if (this.position >= -1 && this.position < this.queue.CurrentSize - 1)
            {
                this.position++;
                return true;
            }

            return false;
        }

        public void Reset()
        {
            this.position = -1;
        }

        public void Dispose()
        {
        }
    }
}
