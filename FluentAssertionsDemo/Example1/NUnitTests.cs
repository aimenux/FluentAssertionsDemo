using NUnit.Framework;

namespace FluentAssertionDemo.Example1
{
    public class NUnitTests
    {
        [TestCase(3, 36)]
        public void Should_Get_Valid_Months_For_Input_Years(int inputYears, int expectedMonths)
        {
            // arrange
            var sut = new SystemUnderTests();

            // act
            var actualMonths = sut.ConvertsYearsToMonths(inputYears);

            // assert
            Assert.AreEqual(expectedMonths, actualMonths);
            Assert.That(actualMonths, Is.EqualTo(expectedMonths));
        }

        [TestCase(1, 5)]
        public void Should_Get_Valid_Number_In_Range(int min, int max)
        {
            // arrange
            var sut = new SystemUnderTests();

            // act
            var actualNumber = sut.GetNumberInRange(min, max);

            // assert
            Assert.GreaterOrEqual(actualNumber, min);
            Assert.That(actualNumber, Is.GreaterThanOrEqualTo(min));
            Assert.LessOrEqual(actualNumber, max);
            Assert.That(actualNumber, Is.LessThanOrEqualTo(max));
            Assert.That(actualNumber, Is.InRange(min,max));
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
            Assert.That(actualMonthSalary, Is.EqualTo(expectedMonthSalary).Within(precision));
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
            Assert.AreEqual(0, actualMonths);
        }
    }
}