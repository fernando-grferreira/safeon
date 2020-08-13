using System.Collections.Generic;

namespace Safeon.Mysql.Entities
{
    public class ExternalSupportTypeEntity
    {
        public ExternalSupportTypeEntity()
        {
            ExternalSupports = new HashSet<ExternalSupportEntity>();
        }

        public int Id { get; set; }
        public string Description { get; set; }

        public virtual ICollection<ExternalSupportEntity> ExternalSupports { get; set; }
    }
}