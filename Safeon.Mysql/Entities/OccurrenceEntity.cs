using System;
using System.Collections.Generic;

namespace Safeon.Mysql.Entities
{
    public class OccurrenceEntity
    {
        public OccurrenceEntity()
        {
            OccurrenceLogs = new HashSet<OccurrenceLogEntity>();
            OccurrenceAttachments = new HashSet<OccurrenceAttachmentEntity>();
        }

        public int Id { get; set; }
        public int OccurrenceTypeId { get; set; }
        public int OccurrenceStatusId { get; set; }
        public DateTime DateTimeRegister { get; set; }
        public DateTime DateTimeStart { get; set; }
        public DateTime DateTimeEnd { get; set; }
        public string Note { get; set; }
        public int ClientTrackableObjectId { get; set; }

        public virtual OccurrenceTypeEntity OccurrenceType { get; set; }
        public virtual OccurrenceStatusEntity OccurrenceStatus { get; set; }
        public virtual ClientTrackableObjectEntity ClientTrackableObject { get; set; }
        public virtual ICollection<OccurrenceLogEntity> OccurrenceLogs { get; set; }
        public virtual ICollection<OccurrenceAttachmentEntity> OccurrenceAttachments { get; set; }
    }
}