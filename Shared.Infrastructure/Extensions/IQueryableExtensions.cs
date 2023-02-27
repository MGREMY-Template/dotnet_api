using Shared.Domain.Specification;
using System.Linq;
using System.Linq.Dynamic.Core;

namespace Shared.Infrastructure.Extensions
{
	public static class IQueryableExtensions
	{
		public static IQueryable<T> ApplyPaging<T>(
			this IQueryable<T> inputQuery,
			IPaging paging)
		{
			var query = inputQuery.AsQueryable();

			query = query.Skip(paging.Skip).Take(paging.Take);
			query = query.OrderBy(paging.OrderBy, paging.IsOrderByDescending ? "desc" : "asc");

			return query;
		}
	}
}
