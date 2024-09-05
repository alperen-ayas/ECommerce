using ECommerce.Catalog.Domain.SeedWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Catalog.Domain.AggregateModels.ProductModels
{
    public class VariantProperty : ValueObject
    {
        public string VariantName { get; set; }
        public string VariantValue { get; set; }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return VariantName; 
            yield return VariantValue;
        }
    }
}
