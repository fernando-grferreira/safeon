using Safeon.Domain.Models;
using Safeon.Mysql.Entities;

namespace Safeon.Mysql.Factories
{
    public class SafeonMysqlModelFactory
    {
        public static PointInterest Create(PointInterestEntity entity)
        {
            if (entity == null)
                return null;

            return new PointInterest
            {
                Id = entity.Id,
                Name = entity.Name,
                Address = entity.Address,
                Description = entity.Description,
                Latitude = entity.Latitude,
                Longitude = entity.Longitude,
                PointInterestTypeId = entity.PointInterestTypeId,
                PointInterestTypeName = entity.PointInterestType.Description,
                Active = entity.Active,
            };
        }

        public static PointInterestType Create(PointInterestTypeEntity entity)
        {
            if (entity == null)
                return null;

            return new PointInterestType
            {
                Id = entity.Id,
                Description = entity.Description
            };
        }

        public static ExternalSupport Create(ExternalSupportEntity entity)
        {
            if (entity == null)
                return null;

            return new ExternalSupport
            {
                Id = entity.Id,
                Name = entity.Name,
                ExternalSupportTypeId = entity.ExternalSupportTypeId,
                ExternalSupportTypeName = entity.ExternalSupportType.Description,
                Latitude = entity.Latitude,
                Longitude = entity.Longitude,
                City = entity.City,
                UF = entity.UF,
                PhoneNumber = entity.PhoneNumber,
                CellPhoneNumber = entity.CellPhoneNumber,
                Email = entity.Email,
                Note = entity.Note,
                Active = entity.Active,
            };
        }

        public static ExternalSupportType Create(ExternalSupportTypeEntity entity)
        {
            if (entity == null)
                return null;

            return new ExternalSupportType
            {
                Id = entity.Id,
                Description = entity.Description
            };
        }

        public static Person Create(PersonEntity entity)
        {
            if (entity == null)
                return null;

            return new Person
            {
                Document = entity?.Document,
                Id = entity?.Id,
                Name = entity?.Name,
                PersonType = entity == null ? ' ' : entity.PersonType,
                PhoneNumber = entity?.PhoneNumber
                
            };
        }

        public static User Create(UserEntity entity)
        {
            if (entity == null)
                return null;

            return new User
            {
                Name = entity.Name,
                Email = entity.Email,
                UserName = entity.Username,
                Profile = entity.Profile?.Name,
                ProfileId = entity.ProfileId,
                //RegisterDateTime = entity.,
                Active = entity.Active,
                Id = entity.Id,
                Person = Create(entity.Person)
            };
        }

        public static Profile Create(ProfileEntity entity)
        {
            if (entity == null)
                return null;

            return new Profile
            {
                Id = entity.Id,
                Name = entity.Name,
                Active = entity.Active
                
            };
        }

        public static Customer Create(ClientEntity entity)
        {
            if (entity == null)
                return null;

            return new Customer
            {
                Person = Create(entity.Person),
                Id = entity.Id,
                //RegisterDateTime
                CustomerType = new CustomerType()
                {
                    Id = entity.ClientTypeId,
                    Description = entity.ClientType.Description
                }
            };
        }
    }
}
