using Safeon.Domain.Models;
using Safeon.Systems.Core.Enums;
using Safeon.Systems.Core.Filters;
using Safeon.Systems.Core.Results;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Safeon.Domain.Business.Contracts
{
    public interface IUserBusiness
    {
        Task<User> Login(User request, string deviceToken, ESmartphoneOS oSSmartphone);
        PaginatedListResult<User> GetUsers(FilterRequest request);
        Task<IEnumerable<Profile>> GetProfiles();
        Task<User> Save(User request);
        Task<User> GetUser(int id);
    }
}