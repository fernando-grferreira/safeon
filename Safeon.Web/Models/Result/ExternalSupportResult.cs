using Safeon.Domain.Models;
using System.Collections.Generic;

namespace Safeon.Web.Models.Result
{
    public class ExternalSupportResult
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

        public ExternalSupportResult FromModel(ExternalSupport model)
        {
            if (model == null)
                return null;

            return new ExternalSupportResult
            {
                Id = model.Id,
                Name = model.Name,
                ExternalSupportTypeId = model.ExternalSupportTypeId,
                ExternalSupportTypeName = model.ExternalSupportTypeName,
                Latitude = model.Latitude,
                Longitude = model.Longitude,
                City = model.City,
                UF = model.UF,
                PhoneNumber = model.PhoneNumber,
                CellPhoneNumber = model.CellPhoneNumber,
                Email = model.Email,
                Note = model.Note,
                Active = model.Active,
            };
        }

        public IEnumerable<ExternalSupportResult> ConvertTo(IEnumerable<ExternalSupport> models)
        {
            if (models == null)
                return null;

            List<ExternalSupportResult> result = new List<ExternalSupportResult>();

            foreach (var model in models)
            {
                result.Add(FromModel(model));
            }

            return result;
        }
    }
}