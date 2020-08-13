using Safeon.Domain.Models;
using Safeon.Systems.Core.Filters;
using Safeon.Systems.Core.Results;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Safeon.Domain.Repositories.Contracts
{
    public interface IPointInterestRepository
    {
        Task<PointInterest> Save(PointInterest request);
        Task<PointInterest> GetPointInterest(int id);
        Task<PaginatedListResult<PointInterest>> GetPointsInterest(FilterRequest request);
        Task<IEnumerable<PointInterestType>> GetPointsInterestTypes();
    }
}