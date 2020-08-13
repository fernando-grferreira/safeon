using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Safeon.Api.Configuration;
using Safeon.Api.Models.Request;
using Safeon.Api.Models.Result;
using Safeon.Domain.Business.Contracts;
using Safeon.Domain.Models;
using Safeon.Systems.Core.Swagger.Attributes;
using System.Threading.Tasks;

namespace Safeon.Api.Controllers
{
    [ApiVersion("1")]
    [Produces("application/json")]
    [Route(ApiGatewayStages.Version1 + "users")]
    [AuthorizeHeaderRequired]
    public class UserController : ControllerBase
    {
        private readonly IUserBusiness _userBusiness;

        public UserController(IUserBusiness userBusiness)
        {
            _userBusiness = userBusiness;
        }

        [NonBodyParameter("DeviceToken", "Device token do dispositivo", true)]
        [NonBodyParameter("OSSmartphone", "Sistema operacional do aparelho", true)]
        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<LoginResult> Login([FromBody] LoginRequest request)
        {
            User result = await _userBusiness.Login(request.ToBusiness(), DeviceToken, OSSmartphone);
            return new LoginResult(result);
        }
    }
}