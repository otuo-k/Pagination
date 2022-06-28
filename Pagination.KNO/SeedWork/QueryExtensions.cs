using System;
using System.Linq;
using System.Linq.Expressions;

namespace Pagination.KNO.SeedWork
{
    public static class QueryExtensions
    {
        public static PaginatedEntities<T> PageEntities<T>
           (this IQueryable<T> query, Pager pager)
        {
            pager.SetUpRestOfDto(query);

            return new PaginatedEntities<T>
            {
                Pager = pager,
                Entities = query.Page(pager.PageNum - 1, pager.PageSize).ToList()
            };
        }

        public static IQueryable<T> SortByDynamic<T>
          (this IQueryable<T> query, string orderByMember, string direction)
        {
            var queryElementTypeParam = Expression.Parameter(typeof(T));
            var memberAccess = Expression.PropertyOrField(queryElementTypeParam, orderByMember);
            var keySelector = Expression.Lambda(memberAccess, queryElementTypeParam);

            var orderBy = Expression.Call(
            typeof(Queryable),
            direction == "ASC" ? "OrderBy" : "OrderByDescending",
            new Type[] { typeof(T), memberAccess.Type }, query.Expression,
            Expression.Quote(keySelector));

            return query.Provider.CreateQuery<T>(orderBy);
        }

        public static IQueryable<T> Page<T>(this IQueryable<T> query,
              int pageNumZeroStart, int pageSize)
        {
            if (pageSize == 0)
                throw new ArgumentOutOfRangeException
                    (nameof(pageSize), "pageSize cannot be zero");

            if (pageNumZeroStart != 0)
                query = query.Skip(pageNumZeroStart * pageSize);    //#A

            return query.Take(pageSize);                            //#B
        }
        /***************************************************************
        #A It skips the correct number of pages
        #B It then takes the number for this page size
         * ************************************************************/
    }
}
