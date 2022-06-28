using System;
using System.Collections.Generic;
using System.Linq;

namespace Pagination.KNO.SeedWork
{
    public class Pager
    {
        public string SortField { get; set; }
        public string SortDirection { get; set; }
        public int PageSize { get; set; } = 10;
        public int PageNum { get; set; } = 1;  //indicates the current page number
        public double Total { get; private set; }
        public int NumPages { get; private set; }

        public void SetUpRestOfDto<T>(IQueryable<T> query)
        {
            Total = (double)query.Count();

            if (Total > 0)       //#A
                NumPages = (int)Math.Ceiling(Total / PageSize);

            //used if PageNum posted value is greater than the calculated number of pages
            //and also prevent page number from being zero
            PageNum = Total == 0 ? 1 : Math.Min(Math.Max(1, PageNum), NumPages);
        }
    }


    public class PaginatedEntities<T>
    {
        public Pager Pager { get; set; }
        public IEnumerable<T> Entities { get; set; }
    }
}
