namespace Domain.Paging;

using System.ComponentModel;

public partial class BasePaging : IPaging
{
    [DefaultValue(10)] public int Take { get; set; } = 10;

    [DefaultValue(0)] public int Skip { get; set; } = 0;

    [DefaultValue("Id")] public string OrderBy { get; set; } = "Id";

    [DefaultValue(true)] public bool IsOrderByDescending { get; set; } = false;
}
