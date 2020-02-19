using Generic_Queue;
using GenericQueue;
using Notebook.Part1;
using NUnit.Framework;

namespace QueueTest
{
    public class Tests
    {
        [Test]
        public void QueueTest_Int_QueueMethods()
        {
            Queue<int> intQueue = new Queue<int>();
            intQueue.Enqueue(1);
            intQueue.Enqueue(2);
            intQueue.Enqueue(3);
            intQueue.Enqueue(4);
            Assert.AreEqual(1, intQueue.Peek());
            Assert.AreEqual(1, intQueue.Dequeue());
            intQueue.Enqueue(5);
            Assert.AreEqual(2, intQueue.Dequeue());
            Assert.AreEqual(3, intQueue.Dequeue());
            Assert.AreEqual(4, intQueue.Dequeue());
            Assert.AreEqual(5, intQueue.Dequeue());
        }

        [Test]
        public void QueueTest_Int_Foreach()
        {
            Queue<int> intQueue = new Queue<int>();
            intQueue.Enqueue(1);
            intQueue.Enqueue(2);
            intQueue.Enqueue(3);
            intQueue.Enqueue(4);
            int[] arr = new int[4];
            int i = 0;
            foreach (var number in intQueue)
            {
                arr[i] = (int) number;
                i++;
            }
            Assert.AreEqual(new int[]{1,2,3,4}, arr);
        }

        [Test]
        public void QueueTest_String_QueueMethods()
        {
            Queue<string> strQueue = new Queue<string>();
            strQueue.Enqueue("1");
            strQueue.Enqueue("2");
            strQueue.Enqueue("3");
            strQueue.Enqueue("4");
            Assert.AreEqual("1", strQueue.Peek());
            Assert.AreEqual("1", strQueue.Dequeue());
            Assert.AreEqual("2", strQueue.Dequeue());
            Assert.AreEqual("3", strQueue.Dequeue());
            Assert.AreEqual("4", strQueue.Dequeue());
        }

        [Test]
        public void QueueTest_String_Foreach()
        {
            Queue<string> strQueue = new Queue<string>();
            strQueue.Enqueue("1");
            strQueue.Enqueue("2");
            strQueue.Enqueue("3");
            strQueue.Enqueue("4");
            string[] arr = new string[4];
            int i = 0;
            foreach (var number in strQueue)
            {
                arr[i] = number.ToString();
                i++;
            }
            Assert.AreEqual(new string[] { "1", "2", "3", "4" }, arr);
        }

        [Test]
        public void QueueTest_Stuct_QueueMethods()
        {
            Queue<Point> pointQueue = new Queue<Point>();
            pointQueue.Enqueue(new Point(1, 1));
            pointQueue.Enqueue(new Point(2, 2));
            pointQueue.Enqueue(new Point(3, 3));
            pointQueue.Enqueue(new Point(4, 4));
            Assert.AreEqual(new Point(1, 1), pointQueue.Peek());
            Assert.AreEqual(new Point(1, 1), pointQueue.Dequeue());
            Assert.AreEqual(new Point(2, 2), pointQueue.Dequeue());
            Assert.AreEqual(new Point(3, 3), pointQueue.Dequeue());
            Assert.AreEqual(new Point(4, 4), pointQueue.Dequeue());
        }

        [Test]
        public void QueueTest_Struct_Foreach()
        {
            Queue<Point> pointQueue = new Queue<Point>();
            pointQueue.Enqueue(new Point(1,1));
            pointQueue.Enqueue(new Point(2, 2));
            pointQueue.Enqueue(new Point(3, 3));
            pointQueue.Enqueue(new Point(4, 4));
            Point[] arr = new Point[4];
            int i = 0;
            foreach (var point in pointQueue)
            {
                arr[i] = (Point)point;
                i++;
            }
            Assert.AreEqual(new Point[] { new Point(1, 1), new Point(2, 2), new Point(3, 3), new Point(4, 4) }, arr);
        }

        [Test]
        public void QueueTest_Note_QueueMethods()
        {
            Note noteOne= new Note("1");
            Note noteTwo = new Note("2");
            Note noteThree = new Note("3");
            Note noteFour = new Note("4");
            Queue<Note> pointQueue = new Queue<Note>();
            pointQueue.Enqueue(noteOne);
            pointQueue.Enqueue(noteTwo);
            pointQueue.Enqueue(noteThree);
            pointQueue.Enqueue(noteFour);
            Assert.AreEqual(noteOne, pointQueue.Peek());
            Assert.AreEqual(noteOne, pointQueue.Dequeue());
            Assert.AreEqual(noteTwo, pointQueue.Dequeue());
            Assert.AreEqual(noteThree, pointQueue.Dequeue());
            Assert.AreEqual(noteFour, pointQueue.Dequeue());
        }

        [Test]
        public void QueueTest_Note_Foreach()
        {
            Note noteOne = new Note("1");
            Note noteTwo = new Note("2");
            Note noteThree = new Note("3");
            Note noteFour = new Note("4");
            Queue<Note> pointQueue = new Queue<Note>();
            pointQueue.Enqueue(noteOne);
            pointQueue.Enqueue(noteTwo);
            pointQueue.Enqueue(noteThree);
            pointQueue.Enqueue(noteFour);
            Note[] arr = new Note[4];
            int i = 0;
            foreach (var note in pointQueue)
            {
                arr[i] = (Note)note;
                i++;
            }
            Assert.AreEqual(new Note[] { noteOne, noteTwo, noteThree, noteFour }, arr);
        }
    }
}