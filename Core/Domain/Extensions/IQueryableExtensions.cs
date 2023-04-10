namespace Domain.Extensions;

using Domain.Paging;
using System.Linq;
using System.Linq.Dynamic.Core;

public static class IQueryableExtensions
{
    public static IQueryable<T> ApplyPaging<T>(
        this IQueryable<T> query,
        IPaging paging)
    {
        query = query.Skip(paging.Skip).Take(paging.Take);
        if (typeof(T).PropertyExist(paging.OrderBy))
        {
            query = query.OrderBy(paging.OrderBy, paging.IsOrderByDescending ? "desc" : "asc");
        }

        return query;
    }
}
