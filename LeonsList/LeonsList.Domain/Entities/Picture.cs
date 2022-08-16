using LeonsList.Domain.Common;

namespace LeonsList.Domain.Entities
{
    public class Picture : AuditableBaseEntity
    {
        public byte[] Content { get; set; }
        public bool IsDeleted { get; set; }
        public Listing Listing { get; set; }
        public Picture()
        {
            IsDeleted = false;
        }
    }
}
