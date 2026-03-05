namespace QebeleEShop.Common.GlobalResponse;

public class Pagination<T>
{
    public Pagination(List<T> data, int totalCount, int page, int size)
    {
        Data = data;
        TotalCount = totalCount;
        Page = page;
        Size = size;
    }

    public List<T> Data { get; set; }
    public int TotalCount { get; set; }
    public int Page { get; set; }
    public int Size { get; set; }

    public Pagination()
    {
        Data = new List<T>();
        TotalCount = 0;
    }
}
