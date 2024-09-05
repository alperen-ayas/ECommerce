using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Catalog.Domain.SeedWorks
{
    public abstract class Entity<TKey> : IEntity<TKey>
        where TKey : IComparable
    {
        public required TKey Id { get; init ; }
    }


}
