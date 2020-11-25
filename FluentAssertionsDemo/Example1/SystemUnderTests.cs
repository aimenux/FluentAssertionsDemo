using System;

namespace FluentAssertionDemo.Example1
{
    public class SystemUnderTests
    {
        public int ConvertsYearsToMonths(int years)
        {
            if (years < 0)
            {
                throw new ArgumentException(nameof(years));
            }

            return years * 12;
        }

        public int GetNumberInRange(int min, int max)
        {
            if (min > max)
            {
                throw new ArgumentException($"{nameof(min)} {nameof(max)}");
            }

            return (min + max) / 2;
        }

        public decimal ComputeMonthSalary(decimal annualSalary)
        {
            if (annualSalary < 0)
            {
                throw new ArgumentException(nameof(annualSalary));
            }

            return annualSalary / 12;
        }
    }
}
