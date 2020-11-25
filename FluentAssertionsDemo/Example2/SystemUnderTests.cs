using System;

namespace FluentAssertionDemo.Example2
{
    public class SystemUnderTests
    {
        public DateTime Now => DateTime.Now;

        public DateTime GetDate(int year, int month, int day)
        {
            return new DateTime(year, month, day);
        }
    }
}
