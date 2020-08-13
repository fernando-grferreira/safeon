using System;
using System.Collections.Generic;
using System.Text;

namespace Safeon.Mysql.Entities
{
    public class OccurrenceTypeEntity
    {
        public OccurrenceTypeEntity()
        {
            Occurrences = new HashSet<OccurrenceEntity>();
        }

        public int Id { get; set; }
        public string Description { get; set; }

        public virtual ICollection<OccurrenceEntity> Occurrences { get; set; }
    }
}