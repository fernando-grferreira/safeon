using System;
using System.Collections.Generic;
using System.Text;

namespace Safeon.Mysql.Entities
{
    public class OccurrenceStatusEntity
    {
        public OccurrenceStatusEntity()
        {
            Occurrences = new HashSet<OccurrenceEntity>();
        }

        public int Id { get; set; }
        public string Description { get; set; }

        public virtual ICollection<OccurrenceEntity> Occurrences { get; set; }
    }
}