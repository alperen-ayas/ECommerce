using ECommerce.Catalog.Domain.AggregateModels.ProductModels;
using ECommerce.Catalog.Domain.SeedWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Catalog.Application.Abstractions.Repositories
{
    public interface IProductRepository : IRepository
    {
        Task CreateProduct(Product product);
    }
}
