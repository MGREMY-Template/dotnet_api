namespace Shared.Core.Entities;

using System;

public partial interface IBaseEntity<TKey> where TKey : IEquatable<TKey>
{
    public TKey Id { get; set; }
}
