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
        if (typeof(T).PropertyExist(paging.OrderBy, out var property))
        {
            query = query.OrderBy($"{property} {(paging.IsOrderByDescending ? "desc" : "asc")}");
        }

        query = query.Skip(paging.Skip).Take(paging.Take);

        return query;
    }
}
