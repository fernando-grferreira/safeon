using Safeon.Domain.Business.Contracts;
using Safeon.Domain.Models;
using Safeon.Domain.Repositories.Contracts;
using Safeon.Systems.Core.Filters;
using Safeon.Systems.Core.Results;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Safeon.Domain.Business
{
    public class PointInterestBusiness : IPointInterestBusiness
    {
        private readonly IPointInterestRepository _pointInterestRepository;

        public PointInterestBusiness(IPointInterestRepository pointInterestRepository)
        {
            _pointInterestRepository = pointInterestRepository;
        }

        public async Task<PointInterest> Save(PointInterest request)
        {
            return await _pointInterestRepository.Save(request);
        }

        public async Task<PointInterest> GetPointInterest(int id)
        {
            return await _pointInterestRepository.GetPointInterest(id);
        }

        public async Task<PaginatedListResult<PointInterest>> GetPointsInterest(FilterRequest request)
        {
            return await _pointInterestRepository.GetPointsInterest(request);
        }

        public async Task<IEnumerable<PointInterestType>> GetPointsInterestTypes()
        {
            return await _pointInterestRepository.GetPointsInterestTypes();
        }
    }
}