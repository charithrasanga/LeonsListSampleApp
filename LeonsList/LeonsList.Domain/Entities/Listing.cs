using LeonsList.Domain.Common;
using System.Collections.Generic;

namespace LeonsList.Domain.Entities
{
    public class Listing : AuditableBaseEntity
    {
        public string Title { get; set; }
        public string Content { get; set; }
        ICollection<Picture> ListingPictures { get; set;}
        public Category Category { get; set; }
        public bool IsPrivate { get; set; } = false;
    }
}
