using System.Collections.Generic;

namespace Safeon.Mysql.Entities
{
    public class UserEntity
    {
        public UserEntity()
        {
            Logs = new HashSet<LogEntity>();
            OccurrenceLogs = new HashSet<OccurrenceLogEntity>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Username { get; set; }
        public int PersonId { get; set; }
        public bool Active { get; set; }
        public int ProfileId { get; set; }

        public virtual ProfileEntity Profile { get; set; }        
        public virtual PersonEntity Person { get; set; }        
        public virtual ICollection<LogEntity> Logs { get; set; }
        public virtual ICollection<OccurrenceLogEntity> OccurrenceLogs { get; set; }
    }
}