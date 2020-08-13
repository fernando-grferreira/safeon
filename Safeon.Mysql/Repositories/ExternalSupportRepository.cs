using Microsoft.EntityFrameworkCore;
using Safeon.Domain.Contexts.Contracts;
using Safeon.Domain.Models;
using Safeon.Domain.Repositories.Contracts;
using Safeon.Mysql.Context;
using Safeon.Mysql.Entities;
using Safeon.Mysql.Factories;
using Safeon.Systems.Core.Filters;
using Safeon.Systems.Core.Results;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Safeon.Mysql.Repositories
{
    public class ExternalSupportRepository : IExternalSupportRepository
    {
        private readonly SafeonMysqlContext db;

        public ExternalSupportRepository(ISafeonMysqlContext context)
        {
            db = (SafeonMysqlContext)context;
        }

        public async Task<ExternalSupport> Save(ExternalSupport request)
        {
            ExternalSupportEntity entity = new ExternalSupportEntity();

            if (request.Id.HasValue)
            {
                entity = await SearchId(request.Id.Value);
                if (entity == null)
                    throw new KeyNotFoundException();

                db.ExternalSupportEntities.Update(entity);
            }
            else
                db.ExternalSupportEntities.Add(entity);

            entity.Name = request.Name;
            entity.ExternalSupportTypeId = request.ExternalSupportTypeId;
            entity.Latitude = request.Latitude;
            entity.Longitude = request.Longitude;
            entity.City = request.City;
            entity.UF = request.UF;
            entity.PhoneNumber = request.PhoneNumber;
            entity.CellPhoneNumber = request.CellPhoneNumber;
            entity.Email = request.Email;
            entity.Note = request.Note;
            entity.Active = request.Active;

            await db.SaveChangesAsync();

            return SafeonMysqlModelFactory.Create(await SearchId(entity.Id));
        }

        public async Task<ExternalSupport> Get(int id)
        {
            ExternalSupportEntity entity = await SearchId(id);

            return SafeonMysqlModelFactory.Create(entity);
        }

        public async Task<PaginatedListResult<ExternalSupport>> GetList(FilterRequest request)
        {
            var query = db.ExternalSupportEntities
                .Include(x => x.ExternalSupportType)
                .AsQueryable();

            if (request.Search != null && !string.IsNullOrWhiteSpace(request.Search.Value))
                query = query.Where(x => x.Name.Contains(request.Search.Value) ||
                    x.City.Contains(request.Search.Value) ||
                    x.Email.Contains(request.Search.Value));

            return await query.GetPagedAsync(SafeonMysqlModelFactory.Create, request);
        }

        public async Task<IEnumerable<ExternalSupportType>> GetTypeList()
        {
            return await db.ExternalSupportTypeEntities
                .Select(x => SafeonMysqlModelFactory.Create(x))
                .OrderBy(x => x.Description)
                .ToListAsync();
        }

        private async Task<ExternalSupportEntity> SearchId(int id)
        {
            return await db.ExternalSupportEntities
                .Include(x => x.ExternalSupportType)
                .Where(x => x.Id == id)
                .FirstOrDefaultAsync();
        }
    }
}