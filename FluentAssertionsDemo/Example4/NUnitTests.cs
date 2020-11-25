using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FluentAssertionDemo.Example4
{
    public class NUnitTests
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
            Assert.IsNotNull(actualCollection);
            Assert.IsTrue(actualCollection.Count > 0);
            Assert.AreEqual(expectedCount, actualCollection.Count);
            Assert.That(actualCollection, Is.Not.Null);
            Assert.That(actualCollection, Is.Not.Empty);
            Assert.That(actualCollection, Has.Exactly(expectedCount).Items);
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
            Assert.AreEqual(expectedCollection.Count, actualCollection.Count);
            for (var index = 0; index < expectedCollection.Count; index++)
            {
                AssertAreEquals(expectedCollection[index], actualCollection.ElementAt(index));
            }
        }

        [Test]
        public void Should_Products_Have_Unique_Ordered_Ids()
        {
            // arrange
            var sut = new SystemUnderTests();

            // act
            var actualCollection = sut.Products;
            var ids = actualCollection.Select(x => x.Id);

            // assert
            CollectionAssert.AllItemsAreUnique(ids);
            CollectionAssert.AllItemsAreNotNull(ids);
            CollectionAssert.IsOrdered(ids);
            Assert.That(ids, Is.Unique);
            Assert.That(ids, Is.Not.Contain(null));
            Assert.That(ids, Is.Ordered);
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
            Assert.Throws<ArgumentOutOfRangeException>(() => productFunc());
            Assert.That(productFunc, Throws.TypeOf<ArgumentOutOfRangeException>());
        }

        private static void AssertAreEquals(Product x, Product y)
        {
            Assert.AreEqual(x.Id, y.Id);
            Assert.AreEqual(x.Price, y.Price);
            Assert.AreEqual(x.Description, y.Description);
        }
    }
}