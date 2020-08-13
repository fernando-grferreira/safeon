using Safeon.Domain.Models;

namespace Safeon.Web.Models.Form
{
    public class ExternalSupportForm
    {
        public ExternalSupportForm()
        {
        }

        public ExternalSupportForm(ExternalSupport model)
        {
            Id = model.Id;
            Name = model.Name;
            ExternalSupportTypeId = model.ExternalSupportTypeId;
            ExternalSupportTypeName = model.ExternalSupportTypeName;
            Latitude = model.Latitude;
            Longitude = model.Longitude;
            City = model.City;
            UF = model.UF;
            PhoneNumber = model.PhoneNumber;
            CellPhoneNumber = model.CellPhoneNumber;
            Email = model.Email;
            Note = model.Note;
            Active = model.Active;
        }

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

        public ExternalSupport FromBusiness()
        {
            return new ExternalSupport
            {
                Id = Id,
                Name = Name,
                ExternalSupportTypeId = ExternalSupportTypeId,
                ExternalSupportTypeName = ExternalSupportTypeName,
                Latitude = Latitude,
                Longitude = Longitude,
                City = City,
                UF = UF,
                PhoneNumber = PhoneNumber,
                CellPhoneNumber = CellPhoneNumber,
                Email = Email,
                Note = Note,
                Active = Active,
            };
        }
    }
}