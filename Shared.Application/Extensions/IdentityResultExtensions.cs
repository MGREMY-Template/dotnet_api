namespace Shared.Application.Extensions;

using Microsoft.AspNetCore.Identity;
using System.Linq;

internal static class IdentityResultExtensions
{
    public static string[] ErrorsToStringArray(
        this IdentityResult result) => result.Errors.Select(x => x.Description).Distinct().ToArray();
}
