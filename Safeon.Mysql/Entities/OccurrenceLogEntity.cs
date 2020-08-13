using System;

namespace Safeon.Mysql.Entities
{
    public class OccurrenceLogEntity
    {
        public int Id { get; set; }
        public int OccurrenceId { get; set; }
        public int OccurrenceLogTypeId { get; set; }
        public string Description { get; set; }
        public int UserId { get; set; }
        public DateTime DateTime { get; set; }

        public virtual OccurrenceEntity Occurrence { get; set; }
        public virtual OccurrenceLogTypeEntity OccurrenceLogType { get; set; }
        public virtual UserEntity User { get; set; }
    }
}