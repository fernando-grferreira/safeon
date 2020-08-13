using System.Collections.Generic;

namespace Safeon.Mysql.Entities
{
    public class ClientTypeEntity
    {
        public ClientTypeEntity()
        {
            Clients = new HashSet<ClientEntity>();
        }

        public int Id { get; set; }
        public string Description { get; set; }

        public virtual ICollection<ClientEntity> Clients { get; set; }
    }
}