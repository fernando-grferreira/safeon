using Safeon.Systems.Core.Filters;
using Safeon.Domain.Models;
using Safeon.Systems.Core.Results;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Safeon.Domain.Business.Contracts
{
    public interface IPointInterestBusiness
    {
        Task<PointInterest> Save(PointInterest request);
        Task<PointInterest> GetPointInterest(int id);
        Task<PaginatedListResult<PointInterest>> GetPointsInterest(FilterRequest request);
        Task<IEnumerable<PointInterestType>> GetPointsInterestTypes();
    }
}