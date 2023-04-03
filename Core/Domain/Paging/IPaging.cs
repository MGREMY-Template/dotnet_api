namespace Domain.Paging;

public interface IPaging
{
    int Take { get; }
    int Skip { get; }
    string OrderBy { get; set; }
    bool IsOrderByDescending { get; }
}
