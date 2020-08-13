using System.Collections.Generic;

namespace Safeon.Mysql.Entities
{
    public class PointInterestTypeEntity
    {
        public PointInterestTypeEntity()
        {
            PointInterests = new HashSet<PointInterestEntity>();
        }

        public int Id { get; set; }
        public string Description { get; set; }

        public virtual ICollection<PointInterestEntity> PointInterests { get; set; }
    }
}