namespace Safeon.Mysql.Entities
{
    public class ProfileFunctionalityEntity
    {
        public int ProfileId { get; set; }
        public int FunctionalityId { get; set; }

        public virtual ProfileEntity Profile { get; set; }
        public virtual FunctionalityEntity Functionality { get; set; }
    }
}
