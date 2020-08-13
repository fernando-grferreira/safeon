using Safeon.Domain.Models;
using System.Collections.Generic;

namespace Safeon.Web.Models.Result
{
    public class PointInterestResult
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Description { get; set; }
        public float Latitude { get; set; }
        public float Longitude { get; set; }
        public int PointInterestTypeId { get; set; }
        public bool Active { get; set; }

        public PointInterestResult FromModel(PointInterest model)
        {
            if (model == null)
                return null;

            return new PointInterestResult
            {
                Id = model.Id,
                Name = model.Name,
                Address = model.Address,
                Description = model.Description,
                Latitude = model.Latitude,
                Longitude = model.Longitude,
                PointInterestTypeId = model.PointInterestTypeId,
                Active = model.Active,
            };
        }

        public IEnumerable<PointInterestResult> ConvertTo(IEnumerable<PointInterest> models)
        {
            if (models == null)
                return null;

            List<PointInterestResult> result = new List<PointInterestResult>();

            foreach (var model in models)
            {
                result.Add(FromModel(model));
            }

            return result;
        }
    }
}
