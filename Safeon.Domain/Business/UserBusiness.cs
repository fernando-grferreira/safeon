using System.Collections.Generic;
using System.Threading.Tasks;
using Safeon.Domain.Business.Contracts;
using Safeon.Domain.Models;
using Safeon.Domain.Repositories.Contracts;
using Safeon.Systems.Core.Enums;
using Safeon.Systems.Core.Filters;
using Safeon.Systems.Core.Results;

namespace Safeon.Domain.Business
{
    public class UserBusiness : IUserBusiness
    {
        private readonly IUserRepository _userRepository;

        public UserBusiness(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public Task<User> Login(User request, string deviceToken, ESmartphoneOS oSSmartphone)
        {
            throw new System.NotImplementedException();
        }

        public PaginatedListResult<User> GetUsers(FilterRequest request)
        {
            return _userRepository.GetUsers(request);
        }

        public async Task<IEnumerable<Profile>> GetProfiles()
        {
            return await _userRepository.GetProfiles();
        }

        public async Task<User> Save(User request)
        {
            return await _userRepository.Save(request);
        }

        public async Task<User> GetUser(int id)
        {
            return await _userRepository.GetUser(id);
        }
    }
}