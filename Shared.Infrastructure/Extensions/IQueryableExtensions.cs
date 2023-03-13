namespace Shared.Infrastructure.Extensions;

using Shared.Core.Paging;
using System.Linq;
using System.Linq.Dynamic.Core;

public static class IQueryableExtensions
{
    public static IQueryable<T> ApplyPaging<T>(
        this IQueryable<T> inputQuery,
        IPaging paging)
    {
        IQueryable<T> query = inputQuery.AsQueryable();

        query = query.Skip(paging.Skip).Take(paging.Take);
        query = query.OrderBy(paging.OrderBy, paging.IsOrderByDescending ? "desc" : "asc");

        return query;
    }
}
