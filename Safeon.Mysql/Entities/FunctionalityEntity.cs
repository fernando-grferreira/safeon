using System.Collections.Generic;

namespace Safeon.Mysql.Entities
{
    public class FunctionalityEntity
    {
        public FunctionalityEntity()
        {
            ProfileFunctionalities = new HashSet<ProfileFunctionalityEntity>();
        }

        public int Id { get; set; }
        public int Name { get; set; }

        public virtual ICollection<ProfileFunctionalityEntity> ProfileFunctionalities { get; set; }
    }
}
