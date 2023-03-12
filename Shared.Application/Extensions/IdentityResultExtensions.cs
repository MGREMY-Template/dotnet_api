using Microsoft.AspNetCore.Identity;
using System.Linq;

namespace Shared.Application.Extensions
{
	internal static class IdentityResultExtensions
	{
		public static string[] ErrorsToStringArray(
			this IdentityResult result)
		{
			return result.Errors.Select(x => x.Description).Distinct().ToArray();
		}
	}
}
