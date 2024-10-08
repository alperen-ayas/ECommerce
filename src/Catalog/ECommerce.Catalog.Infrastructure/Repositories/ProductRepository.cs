﻿using ECommerce.Catalog.Application.Abstractions.Repositories;
using ECommerce.Catalog.Domain.AggregateModels.ProductModels;
using ECommerce.Catalog.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Catalog.Infrastructure.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly CatalogDbContext _catalogDbContext;
        public ProductRepository(CatalogDbContext catalogDbContext)
        {
            _catalogDbContext = catalogDbContext;
        }

        public async Task CreateProduct(Product product)
        {
            await _catalogDbContext.Set<Product>().AddAsync(product);
        }

        public Task<int> SaveChangesAsync()
        {
            return _catalogDbContext.SaveChangesAsync();
        }
    }
}
