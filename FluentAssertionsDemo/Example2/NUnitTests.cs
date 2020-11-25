using NUnit.Framework;
using System;

namespace FluentAssertionDemo.Example2
{
    public class NUnitTests
    {
        [Test]
        public void Should_Get_Valid_Now_DateTime()
        {
            // arrange
            var sut = new SystemUnderTests();

            // act
            var actualNow = sut.Now;

            // assert
            Assert.That(actualNow, Is.EqualTo(DateTime.Now).Within(1).Seconds);
        }

        [TestCase(2020, 12, 03)]
        public void Should_Get_Valid_DateTime(int year, int month, int day)
        {
            // arrange
            var sut = new SystemUnderTests();

            // act
            var actualDate = sut.GetDate(year, month, day);

            // assert
            Assert.That(actualDate.Year, Is.EqualTo(year));
            Assert.That(actualDate.Month, Is.EqualTo(month));
            Assert.That(actualDate.Day, Is.EqualTo(day));
        }
    }
}