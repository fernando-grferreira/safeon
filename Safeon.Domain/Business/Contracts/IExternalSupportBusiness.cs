using Safeon.Domain.Models;
using Safeon.Systems.Core.Filters;
using Safeon.Systems.Core.Results;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Safeon.Domain.Business.Contracts
{
    public interface IExternalSupportBusiness
    {
        Task<ExternalSupport> Save(ExternalSupport request);
        Task<ExternalSupport> Get(int id);
        Task<PaginatedListResult<ExternalSupport>> GetList(FilterRequest request);
        Task<IEnumerable<ExternalSupportType>> GetTypeList();
    }
}