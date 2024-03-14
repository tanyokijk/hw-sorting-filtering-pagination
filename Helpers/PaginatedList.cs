using hw_sorting_filtering_pagination.Models;

namespace hw_sorting_filtering_pagination.Helpers;

public class PaginatedList<T> : List<T>
{
    public int PageIndex { get; private set; }
    public int TotalPages { get; private set; }
    public List<Category> categories { get; private set; }

    public PaginatedList(List<T> items, int count, int pageIndex, int pageSize, List<Category> categories)
    {
        PageIndex = pageIndex;
        TotalPages = (int)Math.Ceiling(count / (double)pageSize);

        this.AddRange(items);
        this.categories = categories;
    }

    public bool HasPreviousPage
    {
        get
        {
            return (PageIndex > 1);
        }
    }

    public bool HasNextPage
    {
        get
        {
            return (PageIndex < TotalPages);
        }
    }

    public static PaginatedList<T> Create(IQueryable<T> source, int pageIndex, int pageSize, List<Category> categories)
    {
        var count = source.Count();
        var items = source.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
        return new PaginatedList<T>(items, count, pageIndex, pageSize, categories);
    }
}
