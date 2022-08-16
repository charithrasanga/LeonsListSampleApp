using LeonsList.Domain.Common;
using System.Collections.Generic;

namespace LeonsList.Domain.Entities
{
    public class Category : AuditableBaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        ICollection<Listing> Listings { get; set; }
    }
}
