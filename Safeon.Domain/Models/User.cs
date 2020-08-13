namespace Safeon.Domain.Models
{
    public class User
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public string Profile { get; set; }
        public int ProfileId { get; set; }
        public string RegisterDateTime { get; set; }
        public string Password { get; set; }
        public bool Active { get; set; }

        public Person Person { get; set; }
    }
}