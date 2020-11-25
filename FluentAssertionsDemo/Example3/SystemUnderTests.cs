using System.Collections.Generic;
using System.Linq;

namespace FluentAssertionDemo.Example3
{
    public class SystemUnderTests
    {
        public const int MaxItems = 5;

        public ICollection<int> Numbers { get; }

        public SystemUnderTests()
        {
            Numbers = Enumerable.Range(1, MaxItems).ToList();
        }
    }
}
