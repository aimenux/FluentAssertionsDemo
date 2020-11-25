using System;
using System.Collections.Generic;
using System.Linq;

namespace FluentAssertionDemo.Example4
{
    public class SystemUnderTests
    {
        public ICollection<Product> Products { get; }

        public SystemUnderTests()
        {
            Products = new List<Product>
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
        }

        public Product this[int index]
        {
            get
            {
                if (index < 0 || index >= Products.Count)
                {
                    throw new ArgumentOutOfRangeException(nameof(index));
                }

                return Products.ElementAt(index);
            }
        }
    }

    public class Product
    {
        public string Id { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
    }
}
