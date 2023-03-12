using System;

namespace Shared.Core.Entities
{
	public partial interface IBaseEntity<TKey> where TKey : IEquatable<TKey>
	{
		public TKey Id { get; set; }
	}
}
