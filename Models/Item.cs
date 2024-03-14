namespace hw_sorting_filtering_pagination.Models;

public class Item
{
    public int Id { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
    public DateTime CreatedDate { get; set; }
    public Category Category { get; set; }
}
