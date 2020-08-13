using System.Collections.Generic;

namespace Safeon.Mysql.Entities
{
    public class PersonEntity
    {
        public PersonEntity()
        {
            Users = new HashSet<UserEntity>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string SocialName { get; set; }
        public string Document { get; set; }
        public char PersonType { get; set; }
        public string PhoneNumber { get; set; }

        public virtual ICollection<UserEntity> Users { get; set; }
        public virtual ClientEntity Client { get; set; }
    }
}