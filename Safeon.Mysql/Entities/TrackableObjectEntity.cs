using System.Collections.Generic;

namespace Safeon.Mysql.Entities
{
    public class TrackableObjectEntity
    {
        public TrackableObjectEntity()
        {
            ClientTrackableObjects = new HashSet<ClientTrackableObjectEntity>();
            Devices = new HashSet<DeviceEntity>();
        }

        public int Id { get; set; }
        public string ClientCode { get; set; }
        public string Plate { get; set; }
        public string Chassis { get; set; }
        public string Color { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public string Manufacturer { get; set; }
        public string Fipe { get; set; }
        public int YearModel { get; set; }
        public int YearManufacture { get; set; }

        public virtual ICollection<ClientTrackableObjectEntity> ClientTrackableObjects { get; set; }
        public virtual ICollection<DeviceEntity> Devices { get; set; }
    }
}