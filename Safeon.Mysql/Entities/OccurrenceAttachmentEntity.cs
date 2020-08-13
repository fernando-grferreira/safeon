namespace Safeon.Mysql.Entities
{
    public class OccurrenceAttachmentEntity
    {
        public int Id { get; set; }
        public int OccurrenceId { get; set; }
        public string Filename { get; set; }
        public string Location { get; set; }

        public virtual OccurrenceEntity Occurrence { get; set; }
    }
}