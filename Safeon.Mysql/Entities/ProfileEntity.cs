using System.Collections.Generic;

namespace Safeon.Mysql.Entities
{
    public class ProfileEntity
    {
        public ProfileEntity()
        {
            ProfileFunctionalities = new HashSet<ProfileFunctionalityEntity>();
            Users = new HashSet<UserEntity>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public bool Active { get; set; }

        public virtual ICollection<ProfileFunctionalityEntity> ProfileFunctionalities { get; set; }
        public virtual ICollection<UserEntity> Users { get; set; }
    }
}