namespace Shared.Core.Extensions
{
	public static class StringExtensions
	{
		public static string[] ToStringArray(
			this object result)
		{
			return result is null ?
				null :
				new[] { result.ToString() };
		}
	}
}