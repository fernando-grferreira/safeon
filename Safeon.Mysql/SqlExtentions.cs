using Microsoft.EntityFrameworkCore;
using Safeon.Systems.Core.Filters;
using Safeon.Systems.Core.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Safeon.Mysql
{
    public static class SqlExtentions
    {
        public static PaginatedListResult<TResult> GetPaged<TEntity, TResult, TFilter>
            (this IQueryable<TEntity> query, Func<TEntity, TResult> creator,
            TFilter filter)
            where TEntity : class
            where TResult : class
            where TFilter : FilterRequest
        {
            int totalCount = 0;

            if (filter.ExecuteCount.Value)
                totalCount = query.Count();

            return new PaginatedListResult<TResult>(query.Select(x => creator(x)), totalCount);
        }

        public static async Task<PaginatedListResult<TResult>> GetPagedAsync<TEntity, TResult, TFilter>(this IQueryable<TEntity> query,
            Func<TEntity, TResult> creator, TFilter filter)
            where TEntity : class
            where TResult : class
            where TFilter : FilterRequest
        {
            int totalCount = 0;
            IList<TEntity> items;

            if (filter.ExecuteCount.Value)
                totalCount = query.Count();

            items = await query.Skip(filter.Start).Take(filter.Length).ToListAsync();

            return new PaginatedListResult<TResult>(items.Select(x => creator(x)), totalCount);
        }
    }
}
