using Safeon.Domain.Models;

namespace Safeon.Web.Models.Form
{
    public class PointInterestForm
    {
        public PointInterestForm()
        {
        }

        public PointInterestForm(PointInterest model)
        {
            Id = model.Id;
            Name = model.Name;
            Address = model.Address;
            Description = model.Description;
            Latitude = model.Latitude;
            Longitude = model.Longitude;
            PointInterestTypeId = model.PointInterestTypeId;
            PointInterestTypeName = model.PointInterestTypeName;
            Active = model.Active;
        }

        public int? Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Description { get; set; }
        public float Latitude { get; set; }
        public float Longitude { get; set; }
        public int PointInterestTypeId { get; set; }
        public string PointInterestTypeName { get; set; }
        public bool Active { get; set; }

        public PointInterest FromBusiness()
        {
            return new PointInterest
            {
                Id = Id,
                Name = Name,
                Address = Address,
                Description = Description,
                Latitude = Latitude,
                Longitude = Longitude,
                PointInterestTypeId = PointInterestTypeId,
                Active = Active,
            };
        }
    }
}
