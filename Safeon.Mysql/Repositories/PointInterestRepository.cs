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
    public class PointInterestRepository : IPointInterestRepository
    {
        private readonly SafeonMysqlContext db;

        public PointInterestRepository(ISafeonMysqlContext context)
        {
            db = (SafeonMysqlContext)context;
        }

        public async Task<PointInterest> Save(PointInterest request)
        {
            PointInterestEntity entity = new PointInterestEntity();

            if (request.Id.HasValue)
            {
                entity = await SearchId(request.Id.Value);
                if (entity == null)
                    throw new KeyNotFoundException();

                db.PointInterestEntities.Update(entity);
            }
            else
                db.PointInterestEntities.Add(entity);

            entity.Name = request.Name;
            entity.Address = request.Address;
            entity.Description = request.Description;
            entity.Latitude = request.Latitude;
            entity.Longitude = request.Longitude;
            entity.PointInterestTypeId = request.PointInterestTypeId;
            entity.Active = request.Active;

            await db.SaveChangesAsync();

            return SafeonMysqlModelFactory.Create(await SearchId(entity.Id));
        }

        public async Task<PointInterest> GetPointInterest(int id)
        {
            PointInterestEntity point = await SearchId(id);

            return SafeonMysqlModelFactory.Create(point);
        }

        public async Task<PaginatedListResult<PointInterest>> GetPointsInterest(FilterRequest request)
        {
            var query = db.PointInterestEntities
                .Include(x => x.PointInterestType)
                .AsQueryable();

            if (request.Search != null && !string.IsNullOrWhiteSpace(request.Search.Value))
                query = query.Where(x => x.Name.Contains(request.Search.Value) ||
                    x.Address.Contains(request.Search.Value) ||
                    x.Description.Contains(request.Search.Value));

            return await query.GetPagedAsync(SafeonMysqlModelFactory.Create, request);
        }

        public async Task<IEnumerable<PointInterestType>> GetPointsInterestTypes()
        {
            return await db.PointInterestTypeEntities
                .Select(x => SafeonMysqlModelFactory.Create(x))
                .OrderBy(x => x.Description)
                .ToListAsync();
        }

        private async Task<PointInterestEntity> SearchId(int id)
        {
            return await db.PointInterestEntities
                .Include(x => x.PointInterestType)
                .Where(x => x.Id == id)
                .FirstOrDefaultAsync();
        }
    }
}
