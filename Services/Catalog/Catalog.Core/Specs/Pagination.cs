using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Core.Specs
{
    public class Pagination<T>(int pageIndex, int pageSize, int count, IReadOnlyList<T> data) where T : class
    {
        //private readonly int pageIndex = pageIndex;
        //private readonly int pageSize = pageSize;
        //private readonly int count = count;
        //private readonly IReadOnlyList<T> data = data;

        public int PageIndex { get; set; } = pageIndex;
        public int PageSize { get; set; } = pageSize;
        public int Count { get; set; } = count;
        public IReadOnlyList<T> Data { get; set; } = data;

    }
}
