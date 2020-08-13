using Safeon.Domain.Contexts.Contracts;
using Safeon.Domain.Models;
using Safeon.Domain.Repositories.Contracts;
using Safeon.Mysql.Context;
using Safeon.Mysql.Factories;
using Safeon.Systems.Core.Filters;
using Safeon.Systems.Core.Results;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using Safeon.Mysql.Entities;
using Safeon.Systems.Utils;
using System;

namespace Safeon.Mysql.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly SafeonMysqlContext db;

        public UserRepository(ISafeonMysqlContext context)
        {
            db = (SafeonMysqlContext)context;
        }

        public PaginatedListResult<User> GetUsers(FilterRequest request)
        {
            var query = db.UserEntities
                .Include(x => x.Person)
                .Include(x => x.Profile)
                .AsQueryable();

            if (request.Search != null && !string.IsNullOrWhiteSpace(request.Search.Value))
                query = query.Where(x => x.Name.Contains(request.Search.Value) ||
                    x.Email.Contains(request.Search.Value) ||
                    x.Username.Contains(request.Search.Value));

            return query.GetPaged(SafeonMysqlModelFactory.Create, request);
        }

        public async Task<IEnumerable<Profile>> GetProfiles()
        {
            return await db.ProfileEntities
                .Select(x => SafeonMysqlModelFactory.Create(x))
                .OrderBy(x => x.Name)
                .ToListAsync();
        }

        private async Task<UserEntity> SearchId(int id)
        {
            return await db.UserEntities
                .Include(x => x.Profile)
                .Include(x => x.Person)
                .Where(x => x.Id == id)
                .FirstOrDefaultAsync();
        }

        public async Task<User> Save(User request)
        {
            UserEntity entity = new UserEntity();
            //Person
            PersonEntity person;

            if (request.Id.HasValue)
            {
                entity = await SearchId(request.Id.Value);
                if (entity == null)
                    throw new KeyNotFoundException();

                person = entity.Person;

                db.UserEntities.Update(entity);
            }
            else
            {
                db.UserEntities.Add(entity);
                request.Active = true;
                person = new PersonEntity();
            }
            
            string salt = Security.GenerateSalt();
            string password = Security.GenerateCryptoPass(salt, request.Password);
            

            person.Name = request.Person.Name;
            person.PersonType = request.Person.PersonType;
            person.Document = request.Person.Document;
            person.PhoneNumber = request.Person.PhoneNumber;

            entity.Name = request.Name;
            entity.Email = request.Email;
            if (!string.IsNullOrEmpty(request.Password))
                entity.Password = password;
            entity.ProfileId = request.ProfileId;
            entity.Username = request.UserName;
            entity.Active = request.Active;
            entity.Person = person;

            await db.SaveChangesAsync();

            return SafeonMysqlModelFactory.Create(await SearchId(entity.Id));
        }

        public async Task<User> GetUser(int id)
        {
            UserEntity user = await SearchId(id);

            return SafeonMysqlModelFactory.Create(user);
        }
    }
}