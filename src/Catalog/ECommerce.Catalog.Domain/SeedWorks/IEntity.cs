using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Catalog.Domain.SeedWorks
{
    public interface IEntity<TKey>
        where TKey : IComparable
    {
        TKey Id { get; init; }
    }
}
