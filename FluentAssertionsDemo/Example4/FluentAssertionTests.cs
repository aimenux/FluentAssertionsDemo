using FluentAssertions;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace FluentAssertionDemo.Example4
{
    public class FluentAssertionTests
    {
        [Test]
        public void Should_Products_Not_Be_Null_Or_Empty()
        {
            // arrange
            var sut = new SystemUnderTests();
            const int expectedCount = 3;

            // act
            var actualCollection = sut.Products;

            // assert
            actualCollection.Should()
                .NotBeNullOrEmpty().And
                .HaveCount(expectedCount);
        }

        [Test]
        public void Should_Products_Contains_Valid_Items()
        {
            // arrange
            var sut = new SystemUnderTests();
            var expectedCollection = new List<Product>
            {
                new Product
                {
                    Id = "P1",
                    Price = 2.3m,
                    Description = "Sugar"
                },
                new Product
                {
                    Id = "P2",
                    Price = 3.1m,
                    Description = "Salt"
                },
                new Product
                {
                    Id = "P3",
                    Price = 1.8m,
                    Description = "Butter"
                }
            };

            // act
            var actualCollection = sut.Products;

            // assert
            actualCollection.Should().BeEquivalentTo(expectedCollection);
        }


        [Test]
        public void Should_Products_Have_Unique_Ordered_Ids()
        {
            // arrange
            var sut = new SystemUnderTests();

            // act
            var actualCollection = sut.Products;

            // assert
            actualCollection
                .Should().NotContainNulls(x => x.Id)
                .And.OnlyHaveUniqueItems(x => x.Id)
                .And.BeInAscendingOrder(x => x.Id);
        }

        [TestCase(int.MinValue)]
        [TestCase(int.MaxValue)]
        public void Should_Throw_Exception_For_Invalid_Index(int index)
        {
            // arrange
            var sut = new SystemUnderTests();

            // act
            Func<Product> productFunc = () => sut[index];

            // assert
            productFunc
                .Should().Throw<ArgumentOutOfRangeException>()
                .And.ParamName.Should().Be(nameof(index));
        }
    }
}