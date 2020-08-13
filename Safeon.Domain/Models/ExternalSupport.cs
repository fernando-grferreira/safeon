namespace Safeon.Domain.Models
{
    public class ExternalSupport
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public int ExternalSupportTypeId { get; set; }
        public string ExternalSupportTypeName { get; set; }
        public float Latitude { get; set; }
        public float Longitude { get; set; }
        public string City { get; set; }
        public string UF { get; set; }
        public string PhoneNumber { get; set; }
        public string CellPhoneNumber { get; set; }
        public string Email { get; set; }
        public string Note { get; set; }
        public bool Active { get; set; }
    }
}