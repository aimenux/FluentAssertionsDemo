using FluentAssertions;
using NUnit.Framework;

namespace FluentAssertionDemo.Example1
{
    public class FluentAssertionTests
    {
        [TestCase(3, 36)]
        public void Should_Get_Valid_Months_For_Input_Years(int inputYears, int expectedMonths)
        {
            // arrange
            var sut = new SystemUnderTests();

            // act
            var actualMonths = sut.ConvertsYearsToMonths(inputYears);

            // assert
            actualMonths.Should().Be(expectedMonths);
        }

        [TestCase(1, 5)]
        public void Should_Get_Valid_Number_In_Range(int min, int max)
        {
            // arrange
            var sut = new SystemUnderTests();

            // act
            var actualNumber = sut.GetNumberInRange(min, max);

            // assert
            actualNumber.Should().BeGreaterOrEqualTo(min);
            actualNumber.Should().BeLessOrEqualTo(max);
            actualNumber.Should().BeInRange(min,max);
        }

        [TestCase(34577.257, 2881.438)]
        public void Should_Get_Valid_Month_Salary(decimal annualSalary, decimal expectedMonthSalary)
        {
            // arrange
            var sut = new SystemUnderTests();
            const decimal precision = 0.0001m;

            // act
            var actualMonthSalary = sut.ComputeMonthSalary(annualSalary);

            // assert
            actualMonthSalary.Should().BeApproximately(expectedMonthSalary, precision);
        }

        [Test]
        [Ignore("Uncomment this line to run failed test")]
        public void Lets_See_Output_Message_For_A_Failed_Test()
        {
            // arrange
            var sut = new SystemUnderTests();

            // act
            var actualMonths = sut.ConvertsYearsToMonths(1);

            // assert
            actualMonths.Should().Be(0);
        }
    }
}