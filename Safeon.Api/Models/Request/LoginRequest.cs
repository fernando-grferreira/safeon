using Safeon.Domain.Models;
using Safeon.Systems.Core.Swagger.Attributes;
using System.ComponentModel.DataAnnotations;

namespace Safeon.Api.Models.Request
{
    public class LoginRequest
    {
        [Required]
        [DescriptionLocalized("Senha do usuário")]
        public string Password { get; set; }

        [Required]
        [DescriptionLocalized("Login")]
        public string Username { get; set; }

        public LoginRequest()
        {
        }

        public User ToBusiness()
        {
            return new User
            {
                //Password = Password,
                //Username = Username
            };
        }
    }
}