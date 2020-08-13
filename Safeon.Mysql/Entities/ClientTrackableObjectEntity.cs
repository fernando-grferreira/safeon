using System.Collections.Generic;

namespace Safeon.Mysql.Entities
{
    public class ClientTrackableObjectEntity
    {
        public ClientTrackableObjectEntity()
        {
            Occurrences = new HashSet<OccurrenceEntity>();
        }

        public int Id { get; set; }
        public int ClientId { get; set; }
        public int TrackableObjectId { get; set; }

        public virtual ClientEntity Client { get; set; }
        public virtual TrackableObjectEntity TrackableObject { get; set; }
        public virtual ICollection<OccurrenceEntity> Occurrences { get; set; }
    }
}