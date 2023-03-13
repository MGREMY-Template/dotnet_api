namespace Shared.Core.Paging;

public partial class BasePaging : IPaging
{
    public int Take { get; set; } = 10;

    public int Skip { get; set; } = 0;

    public string OrderBy { get; set; }

    public bool IsOrderByDescending { get; set; } = true;

}
