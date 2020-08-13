namespace Safeon.Mysql.Entities
{
    public class DeviceEntity
    {
        public int Id { get; set; }
        public string SerialNumber { get; set; }
        public string Model { get; set; }
        public string Manufacturer { get; set; }
        public int TrackableObjectId { get; set; }

        public virtual TrackableObjectEntity TrackableObject { get; set; }
    }
}