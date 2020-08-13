using Safeon.Domain.Business.Contracts;
using Safeon.Domain.Models;
using Safeon.Domain.Repositories.Contracts;
using Safeon.Systems.Core.Filters;
using Safeon.Systems.Core.Results;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Safeon.Domain.Business
{
    public class ExternalSupportBusiness : IExternalSupportBusiness
    {
        private readonly IExternalSupportRepository _externalSupportRepository;

        public ExternalSupportBusiness(IExternalSupportRepository externalSupportRepository)
        {
            _externalSupportRepository = externalSupportRepository;
        }

        public async Task<ExternalSupport> Save(ExternalSupport request)
        {
            return await _externalSupportRepository.Save(request);
        }

        public async Task<ExternalSupport> Get(int id)
        {
            return await _externalSupportRepository.Get(id);
        }

        public async Task<PaginatedListResult<ExternalSupport>> GetList(FilterRequest request)
        {
            return await _externalSupportRepository.GetList(request);
        }

        public async Task<IEnumerable<ExternalSupportType>> GetTypeList()
        {
            return await _externalSupportRepository.GetTypeList();
        }
    }
}