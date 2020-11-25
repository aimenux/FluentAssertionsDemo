using NUnit.Framework;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;

namespace FluentAssertionDemo.Example5
{
    public class NUnitTests
    {
        [Test]
        public void Should_Id_Property_Be_Required()
        {
            // arrange
            var propertyInfo = typeof(Product).GetProperty(nameof(Product.Id));

            // act
            var attribute = propertyInfo.GetCustomAttribute<RequiredAttribute>();

            // assert
            Assert.IsNotNull(attribute);
        }

        [Test]
        public void Should_Description_Property_Be_Virtual()
        {
            // arrange
            var propertyInfo = typeof(Product).GetProperty(nameof(Product.Description));

            // act
            var accessors = propertyInfo.GetAccessors();

            // assert
            Assert.IsNotNull(accessors);
            Assert.AreEqual(1, accessors.Length);
            Assert.IsTrue(accessors.Single().IsVirtual);
        }

        [Test]
        public void Should_System_Under_Tests_Implement_Valid_Interface()
        {
            // arrange
            var type = typeof(SystemUnderTests);

            // act
            var interfaces = type.GetInterfaces();

            // assert
            Assert.IsNotNull(interfaces);
            Assert.AreEqual(1, interfaces.Length);
            Assert.AreEqual(nameof(IProductService), interfaces.Single().Name);
        }
    }
}