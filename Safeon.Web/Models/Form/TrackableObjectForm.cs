namespace Safeon.Web.Models.Form
{
    public class TrackableObjectForm
    {
        public int? Id { get; set; }
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
    }
}
