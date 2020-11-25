using FluentAssertions;
using FluentAssertions.Extensions;
using NUnit.Framework;
using System;

namespace FluentAssertionDemo.Example2
{
    public class FluentAssertionsTests
    {
        [Test]
        public void Should_Get_Valid_Now_DateTime()
        {
            // arrange
            var sut = new SystemUnderTests();

            // act
            var actualNow = sut.Now;

            // assert
            actualNow.Should().BeOnOrBefore(DateTime.Now);
            actualNow.Should().BeSameDateAs(DateTime.Now);
            actualNow.Should().BeCloseTo(DateTime.Now);
        }

        [TestCase(2020, 12, 03)]
        public void Should_Get_Valid_DateTime(int year, int month, int day)
        {
            // arrange
            var sut = new SystemUnderTests();

            // act
            var actualDate = sut.GetDate(year, month, day);

            // assert
            actualDate
                .Should().HaveYear(year)
                .And.HaveMonth(month)
                .And.HaveDay(day);
        }

        [Test]
        public void Should_Get_Valid_DateTime()
        {
            // arrange
            var sut = new SystemUnderTests();
            const int year = 2020;
            const int month = 1;
            const int day = 10;

            // act
            var actualDate = sut.GetDate(year, month, day);

            // assert
            actualDate.Should().Be(10.January(2020).At(0,0));
        }
    }
}