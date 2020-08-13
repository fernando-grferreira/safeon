using Safeon.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Safeon.Web.Models.Form
{
    public class UserForm
    {
        public int? Id { get; set; }
        public string Name { get; set; }

        //Person
        public string Document { get; set; }
        public char PersonType { get; set; }
        public string PhoneNumber { get; set; }

        //User
        public string Email { get; set; }
        public string UserName { get; set; }
        public string Profile { get; set; }
        public int ProfileId { get; set; }
        public string RegisterDateTime { get; set; }
        public bool Active { get; set; }
        public string Password { get; set; }
        public int? PersonId { get; set; }



        public UserForm()
        {
        }

        public UserForm(User model)
        {
            Id = model.Id;
            Name = model.Name;

            Document = model.Person.Document;
            PersonType = model.Person.PersonType;
            PhoneNumber = model.Person.PhoneNumber;

            Email = model.Email;
            UserName = model.UserName;
            Profile = model.Profile;
            ProfileId = model.ProfileId;
            PersonId = model.Person.Id;
            Active = model.Active;
        }

        public User FromBusiness()
        {
            return new User
            {
                Id = Id,
                Name = Name,
                Email = Email,
                Password = Password,
                ProfileId = ProfileId,
                RegisterDateTime = RegisterDateTime,
                UserName = UserName,
                Active = Active,
                Person = new Person()
                {
                    Name = Name,
                    Document = Document,
                    Id = PersonId,
                    PersonType = PersonType,
                    PhoneNumber = PhoneNumber
                }
            };
        }
    }
}
