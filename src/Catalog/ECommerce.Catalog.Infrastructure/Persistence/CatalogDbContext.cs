using ECommerce.Catalog.Domain.SeedWorks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Catalog.Infrastructure.Persistence
{
    public class CatalogDbContext : DbContext
    {
        private readonly IMediator _mediator;
        public CatalogDbContext(DbContextOptions options, IMediator mediator) : base(options)
        {
            _mediator = mediator;
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {

            var domainEntities = this.ChangeTracker
                .Entries<AggregateRoot<int>>()
                .Where(x => x.Entity._domainEvents != null && x.Entity._domainEvents.Any());

            var domainEvents = domainEntities
                .SelectMany(x=>x.Entity._domainEvents)
                .ToList();

            foreach (var domainEvent in domainEvents)
                await _mediator.Publish(domainEvent);


            return await base.SaveChangesAsync(cancellationToken);
        }
    }
}
