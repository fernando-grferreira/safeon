using System.Collections.Generic;
using System.Linq;

namespace Safeon.Systems.Core.Results
{
    public class PaginatedListResult<T> where T : class
    {
        public PaginatedListResult()
        {
        }
        
        public PaginatedListResult(IEnumerable<T> collection, int? totalCount = null)
        {
            var total = collection.Count();

            TotalCount = totalCount ?? total;
            Data = collection;
        }

        public PaginatedListResult(PaginatedListResult<T> collection)
        {
            TotalCount = collection.TotalCount;
            Data = collection.Data;
        }

        public IEnumerable<T> Data { get; set; }
        public int TotalCount { get; set; }
    }
}
