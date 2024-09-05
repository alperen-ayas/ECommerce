using ECommerce.Catalog.Domain.SeedWorks;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Catalog.Domain.AggregateModels.ProductModels
{
    public class ProductVariant : Entity<int>
    {
        public string ProductVariantName { get; private set; }
        public string Description { get; private set; }
        public DateTime CreateTimeUtc { get; init; }
        public DateTime UpdateTimeUtc { get; private set; }
        public List<VariantProperty> VariantProperties { get; private set; }
        public bool IsActive { get; private set; }
        public bool AvalibleForSale { get; private set; }

        public ProductVariant(
            string productVariantName,
            string description,
            bool isActive,
            bool avalibleForSale
            )
        {
            this.ProductVariantName = productVariantName;
            this.Description = description;
            this.IsActive = isActive;
            this.AvalibleForSale = avalibleForSale;
        }

        public static ProductVariant CreateProductVariant(string productVariantName,
            string description,
            IList<VariantProperty> variantProperties,
            bool isActive,
            bool avalibleForSale)
        {
            ProductVariant variant = new(productVariantName, description, isActive, avalibleForSale);
            Guard.CannotNull(variantProperties, nameof(variantProperties));
            variant.VariantProperties.AddRange(variantProperties);

            return variant;
        }

        public void AddVariantProperty(VariantProperty variantProperty)
        {
            Guard.CannotNull(variantProperty, nameof(variantProperty));
            this.VariantProperties.Add(variantProperty);
        }

        public void RemoveVariantProperty(VariantProperty variantProperty)
        {
            Guard.CannotNull(variantProperty,nameof(variantProperty));
            
            this.VariantProperties.Remove(variantProperty);
        }
        public void UpdateVariantProperty(VariantProperty variantProperty)
        {
            Guard.CannotNull(variantProperty, nameof(variantProperty));

            var currentVariantProperty = this.VariantProperties.Find(x=>x.VariantName==variantProperty.VariantName);

            currentVariantProperty = variantProperty;
        }

    }
}
