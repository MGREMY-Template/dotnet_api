namespace Shared.Application.Extensions;

using Microsoft.AspNetCore.Identity;
using System.Linq;

internal static class IdentityResultExtensions
{
    public static string[] ErrorsToStringArray(
        this IdentityResult result)
    {
        return result.Errors.Select(x =>
        {
            return x.Description;
        }).Distinct().ToArray();
    }
}
