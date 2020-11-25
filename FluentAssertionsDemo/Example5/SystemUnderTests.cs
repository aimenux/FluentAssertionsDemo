using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FluentAssertionDemo.Example5
{
    public class SystemUnderTests : IProductService
    {
        public ICollection<Product> GetProducts()
        {
            return new List<Product>();
        }
    }

    public class Product
    {
        [Required]
        public string Id { get; set; }

        public virtual string Description => nameof(Product);
    }

    public interface IProductService
    {
        ICollection<Product> GetProducts();
    }
}
