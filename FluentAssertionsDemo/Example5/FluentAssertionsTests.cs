using FluentAssertions;
using NUnit.Framework;
using System.ComponentModel.DataAnnotations;

namespace FluentAssertionDemo.Example5
{
    public class FluentAssertionsTests
    {
        [Test]
        public void Should_Id_Property_Be_Required()
        {
            // arrange
            // act
            var propertyInfo = typeof(Product).GetProperty(nameof(Product.Id));

            // assert
            propertyInfo.Should().BeDecoratedWith<RequiredAttribute>();
        }

        [Test]
        public void Should_Description_Property_Be_Virtual()
        {
            // arrange
            // act
            var propertyInfo = typeof(Product).GetProperty(nameof(Product.Description));

            // assert
            propertyInfo.Should().BeVirtual();
        }

        [Test]
        public void Should_System_Under_Tests_Implement_Valid_Interface()
        {
            // arrange
            // act
            var type = typeof(SystemUnderTests);

            // assert
            type.Should().Implement<IProductService>();
        }
    }
}