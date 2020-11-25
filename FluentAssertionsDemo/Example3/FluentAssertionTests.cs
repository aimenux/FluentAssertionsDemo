using FluentAssertions;
using NUnit.Framework;
using System.Collections.Generic;

namespace FluentAssertionDemo.Example3
{
    public class FluentAssertionTests
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
            actualCollection
                .Should().NotBeNullOrEmpty()
                .And.HaveCount(expectedCount);
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
            actualCollection.Should().BeEquivalentTo(expectedCollection);
        }

        [Test]
        public void Should_Numbers_Have_Unique_Ordered_Ids()
        {
            // arrange
            var sut = new SystemUnderTests();

            // act
            var actualCollection = sut.Numbers;

            // assert
            actualCollection
                .Should().BeInAscendingOrder()
                .And.OnlyHaveUniqueItems();
        }

        [Test]
        public void Should_Numbers_Be_Positive()
        {
            // arrange
            var sut = new SystemUnderTests();

            // act
            var actualCollection = sut.Numbers;

            // assert
            actualCollection.Should().OnlyContain(x => x >= 0);
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
            actualCollection
                .Should().StartWith(expectedFirstNumber)
                .And.EndWith(expectedLastNumber);
        }
    }
}