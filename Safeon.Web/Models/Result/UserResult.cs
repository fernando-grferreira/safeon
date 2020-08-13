using Safeon.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Safeon.Web.Models.Result
{
    public class UserResult
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public string Profile { get; set; }
        public int ProfileId { get; set; }
        public string RegisterDateTime { get; set; }
        public string Stats { get; set; }
        public int? Id { get; set; }

        public UserResult FromModel(User model)
        {
            if (model == null)
                return null;

            return new UserResult
            {
                Id = model.Id,
                Name = model.Name,
                Email = model.Email,
                UserName = model.UserName,
                Profile = model.Profile,
                RegisterDateTime = model.RegisterDateTime,
                Stats = model.Active ? "Ativo" : "Inativo"
            };
        }

        public IEnumerable<UserResult> ConvertTo(IEnumerable<User> models)
        {
            if (models == null)
                return null;

            List<UserResult> result = new List<UserResult>();

            foreach (var model in models)
            {
                result.Add(FromModel(model));
            }

            return result;
        }
    }
}
