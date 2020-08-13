using System.Collections.Generic;

namespace Safeon.Mysql.Entities
{
    public class OccurrenceLogTypeEntity
    {
        public OccurrenceLogTypeEntity()
        {
            OccurrenceLogs = new HashSet<OccurrenceLogEntity>();
        }

        public int Id { get; set; }
        public string Description { get; set; }

        public virtual ICollection<OccurrenceLogEntity> OccurrenceLogs { get; set; }
    }
}