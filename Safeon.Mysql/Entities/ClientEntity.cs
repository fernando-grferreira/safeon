using System.Collections.Generic;

namespace Safeon.Mysql.Entities
{
    public class ClientEntity
    {
        public ClientEntity()
        {
            ClientTrackableObjects = new HashSet<ClientTrackableObjectEntity>();
        }

        public int Id { get; set; }
        public int ClientTypeId { get; set; }

        public virtual PersonEntity Person { get; set; }
        public virtual ClientTypeEntity ClientType { get; set; }
        public virtual ICollection<ClientTrackableObjectEntity> ClientTrackableObjects { get; set; }
    }
}