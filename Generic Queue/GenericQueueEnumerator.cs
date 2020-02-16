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

        /// <summary>Initializes a new instance of the <see cref="GenericQueueEnumerator{T}"/> class.</summary>
        /// <param name="queue">The queue.</param>
        public GenericQueueEnumerator(Queue<T> queue)
        {
            this.queue = queue;
        }

        /// <summary>Gets the element in the collection at the current position of the enumerator.</summary>
        public T Current
        {
            get => this.queue.GetElement(this.position);
        }

        /// <summary>Gets the element in the collection at the current position of the enumerator.</summary>
        object IEnumerator.Current => this.Current;

        /// <summary>Advances the enumerator to the next element of the collection.</summary>
        /// <returns>
        ///   <span class="keyword">
        ///     <span class="languageSpecificText">
        ///       <span class="cs">true</span>
        ///       <span class="vb">True</span>
        ///       <span class="cpp">true</span>
        ///     </span>
        ///   </span>
        ///   <span class="nu">
        ///     <span class="keyword">true</span> (<span class="keyword">True</span> in Visual Basic)</span> if the enumerator was successfully advanced to the next element; <span class="keyword"><span class="languageSpecificText"><span class="cs">false</span><span class="vb">False</span><span class="cpp">false</span></span></span><span class="nu"><span class="keyword">false</span> (<span class="keyword">False</span> in Visual Basic)</span> if the enumerator has passed the end of the collection.
        /// </returns>
        public bool MoveNext()
        {
            if (this.position >= -1 && this.position < this.queue.CurrentSize - 1)
            {
                this.position++;
                return true;
            }

            return false;
        }

        /// <summary>Sets the enumerator to its initial position, which is before the first element in the collection.</summary>
        public void Reset()
        {
            this.position = -1;
        }

        /// <summary>Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.</summary>
        public void Dispose()
        {
        }
    }
}
