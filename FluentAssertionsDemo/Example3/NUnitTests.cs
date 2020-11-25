using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace FluentAssertionDemo.Example3
{
    public class NUnitTests
    {
        [Test]
        public void Should_Numbers_Not_Be_Null_Or_Empty()
        {
            // arrange
            var sut = new SystemUnderTests();
            const int expectedCount = SystemUnderTests.MaxItems;

            // act
            var actualCollection = sut.Numbers;

            // assert
            Assert.IsNotNull(actualCollection);
            Assert.IsTrue(actualCollection.Count > 0);
            Assert.AreEqual(expectedCount, actualCollection.Count);
            Assert.That(actualCollection, Is.Not.Null);
            Assert.That(actualCollection, Is.Not.Empty);
            Assert.That(actualCollection, Has.Exactly(expectedCount).Items);
        }

        [Test]
        public void Should_Numbers_Contains_Valid_Items()
        {
            // arrange
            var sut = new SystemUnderTests();
            var expectedCollection = new List<int>
            {
                1,2,3,4,5
            };

            // act
            var actualCollection = sut.Numbers;

            // assert
            CollectionAssert.AreEquivalent(expectedCollection, actualCollection);
        }

        [Test]
        public void Should_Numbers_Have_Unique_Ordered_Ids()
        {
            // arrange
            var sut = new SystemUnderTests();

            // act
            var actualCollection = sut.Numbers;

            // assert
            CollectionAssert.AllItemsAreUnique(actualCollection);
            CollectionAssert.AllItemsAreNotNull(actualCollection);
            CollectionAssert.IsOrdered(actualCollection);
            Assert.That(actualCollection, Is.Unique);
            Assert.That(actualCollection, Is.Not.Contain(null));
            Assert.That(actualCollection, Is.Ordered);
        }

        [Test]
        public void Should_Numbers_Be_Positive()
        {
            // arrange
            var sut = new SystemUnderTests();

            // act
            var actualCollection = sut.Numbers;

            // assert
            foreach(var number in actualCollection)
            {
                Assert.IsTrue(number >= 0);
                Assert.That(number, Is.Positive);
            }
        }

        [Test]
        public void Should_First_And_Last_Numbers_Be_Valid()
        {
            // arrange
            var sut = new SystemUnderTests();
            const int expectedFirstNumber = 1;
            const int expectedLastNumber = 5;

            // act
            var actualCollection = sut.Numbers;

            // assert
            Assert.AreEqual(expectedFirstNumber, actualCollection.First());
            Assert.AreEqual(expectedLastNumber, actualCollection.Last());
        }
    }
}