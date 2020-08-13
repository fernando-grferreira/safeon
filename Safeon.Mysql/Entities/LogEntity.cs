using System;

namespace Safeon.Mysql.Entities
{
    public class LogEntity
    {
        public LogEntity()
        {            
        }

        public int Id { get; set; }
        public string EntityName { get; set; }
        public int EntityId { get; set; }
        public int UserId { get; set; }
        public DateTime DateTime { get; set; }
        public string Record { get; set; }

        public virtual UserEntity User { get; set; }
    }
}