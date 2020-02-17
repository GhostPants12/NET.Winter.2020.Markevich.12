using System;
using GenericsDemo;
using Moq;
using NumberExtension;
using NUnit.Framework;

namespace GenericDemo.Tests
{
    [TestFixture]
    public class PredicateTests
    {
        private Mock<IPredicate<int>> mockPredicate;
        private Mock<ITransformer<double, string>> mockTransformer;
        private Mock<IComparer<int>> mockComparer;
        private IPredicate<int> predicate;
        private ITransformer<double, string> transformer;
        private IComparer<int> comparer;

        [SetUp]
        public void Setup()
        {
            mockPredicate = new Mock<IPredicate<int>>();
            mockTransformer = new Mock<ITransformer<double, string>>();
            mockComparer = new Mock<IComparer<int>>();
            mockPredicate
                .Setup(p => p.IsMatch(It.Is<int>(i => new PredicateDigit {Digit = 5}.ContainsKey(i))))
                .Returns(true);
            mockTransformer.Setup(p => p.Transform(It.Is<double>(i => i > 0))).Returns("double");
            mockComparer.Setup(p => p.Compare(It.Is<int>(a => a < 0), It.Is<int>(b => b > 0))).Returns(1);
            mockComparer.Setup(p => p.Compare(It.Is<int>(a => a > 0), It.Is<int>(b => b < 0))).Returns(-1);
            mockComparer.Setup(p => p.Compare(It.Is<int>(a => a >= 0), It.Is<int>(b => b >= 0))).Returns(0);
            mockComparer.Setup(p => p.Compare(It.Is<int>(a => a <= 0), It.Is<int>(b => b <= 0))).Returns(0);
            predicate = mockPredicate.Object;
            transformer = mockTransformer.Object;
            comparer = mockComparer.Object;
        }

        [TestCase(55)]
        [TestCase(551)]
        [TestCase(-12551)]
        [TestCase(-90551)]
        public void IsMatchTests_Return_True(int value)
        {
            Assert.IsTrue(predicate.IsMatch(value));

            mockPredicate.Verify(p => p.IsMatch(It.IsAny<int>()), Times.Exactly(1));
        }

        [TestCase(109)]
        [TestCase(67632)]
        [TestCase(-120943)]
        [TestCase(-2113)]
        public void IsMatchTests_Return_False(int value)
        {
            Assert.IsFalse(predicate.IsMatch(value));

            mockPredicate.Verify(p => p.IsMatch(It.IsAny<int>()), Times.Exactly(1));
        }

        [Test]
        public void FilterByTests()
        {
            int[] source = new int[] {12, 35, -65, 543, 23};

            var expected = new int[] {35, -65, 543};

            var actual = source.FilterBy(predicate);

            CollectionAssert.AreEqual(actual, expected);

            mockPredicate.Verify(p => p.IsMatch(It.IsAny<int>()), Times.Exactly(5));
        }

        [Test]
        public void TransformTests()
        {
            double[] source = new double[] {5, -1, 6, 20, 14};

            var expected = new string[] {"double", null, "double", "double", "double"};

            var actual = source.Transform(transformer);

            CollectionAssert.AreEqual(actual, expected);

            mockTransformer.Verify(p => p.Transform(It.IsAny<double>()), Times.Exactly(5));
        }

        [Test]
        public void OrderingTests()
        {
            int[] source = new int[] {5,4,-1,-2,0};

            var expected = new int[] {-1, -2, 5, 4, 0};

            var actual = source.OrderAccordingTo(comparer);

            CollectionAssert.AreEqual(actual, expected);

            mockComparer.Verify(p => p.Compare(It.IsAny<int>(), It.IsAny<int>()), Times.Exactly(15));
        }

        [Test]
        public void TypeOf_TestForInt()
        {
            object[] source = new object[] {1, 2, "123", 'a', 12.5};

            var expected = new int[] {1, 2};

            var actual = source.TypeOf<int>();

            CollectionAssert.AreEqual(expected, actual);
        }

        [Test]
        public void TypeOf_TestForString()
        {
            object[] source = new object[] { 1, 2, "123", 'a', 12.5 };

            var expected = new string[] { "123"};

            var actual = source.TypeOf<string>();

            CollectionAssert.AreEqual(expected, actual);
        }

        [Test]
        public void Reverse_TestForInt()
        {
            int[] source = new int[] {1, 2, 3, 4, 5};

            var expected = new int[] {5, 4, 3, 2, 1};

            var actual = source.Reverse();

            CollectionAssert.AreEqual(expected, actual);
        }

        [Test]
        public void Reverse_TestForChar()
        {
            char[] source = new char[] { 'o', 'l', 'l', 'e', 'H' };

            var expected = new char[] { 'H', 'e', 'l', 'l', 'o' };

            var actual = source.Reverse();

            CollectionAssert.AreEqual(expected, actual);
        }
    }
}