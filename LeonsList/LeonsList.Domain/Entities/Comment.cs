using LeonsList.Domain.Common;

namespace LeonsList.Domain.Entities
{
    public class Comment : AuditableBaseEntity
    {
      
        public string Message { get; set; }
        public bool IsPrivate { get; set; } = false;
        public Listing Listing { get; set; }


    }
}
