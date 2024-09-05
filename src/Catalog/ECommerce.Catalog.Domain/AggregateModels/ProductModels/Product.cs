using ECommerce.Catalog.Domain.SeedWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Catalog.Domain.AggregateModels.ProductModels
{
    public class Product : AggregateRoot<int>
    {
        public string Name { get; private set; }
        public string Description { get; private set; }
        public DateTime CreateTimeUtc { get; private set; }
        public DateTime UpdateTimeUtc { get; private set; }
        public List<ProductVariant> ProductVariants { get; private set; }
        public bool IsActive { get; private set; }
        public bool AvaibleForSale { get; private set; }

        public Product(
            string name,
            string description,
            bool isActive,
            bool avalibleForSale
            )
        {
            this.Name = name;
            this.Description = description;
            this.IsActive = isActive;
            this.AvaibleForSale = avalibleForSale;
            this.ProductVariants = new List<ProductVariant>();
        }

        public static Product CreateProduct(string name,
            string description,
            bool isActive,
            bool avalibleForSale,
            List<ProductVariant> productVariants)
        {
            var product = new Product(name,description, isActive, avalibleForSale);

            Guard.CannotNull(productVariants, nameof(productVariants));

            product.ProductVariants.AddRange(productVariants);

            return product;

        }

        public void AddProductVariant(ProductVariant variant)
        {
            Guard.CannotNull(variant, nameof(variant));

            ProductVariants.Add(variant);
        }

        public void RemoveProductVariant(ProductVariant variant)
        {
            Guard.CannotNull(variant, nameof(variant));

            ProductVariants.Remove(variant);
        }

        public void UpdateVariantProperty(ProductVariant variant)
        {
            Guard.CannotNull(variant,nameof(variant));
            
            var currentVariant = this.ProductVariants.Find(x => x.Id == variant.Id);

            currentVariant = variant;
        }
    }
}
