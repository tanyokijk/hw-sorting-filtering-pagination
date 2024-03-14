using hw_sorting_filtering_pagination.Helpers;
using hw_sorting_filtering_pagination.Models;
using Microsoft.AspNetCore.Mvc;

namespace hw_sorting_filtering_pagination.Controllers;

public class ItemController : Controller
{
    private readonly List<Item> _items; // Припустимо, що це список всіх елементів.
    private readonly List<Category> _categories;

    public ItemController()
    {
        _categories= new List<Category>
        {
            new Category { Id = 1, Name = "Category 1"},
            new Category { Id = 2, Name = "Category 2" },
            new Category { Id = 3, Name = "Category 3" },
            new Category { Id = 4, Name = "Category 4" },
            new Category { Id = 5, Name = "Category 5" },
            new Category { Id = 6, Name = "Category 6" },
            new Category { Id = 7, Name = "Category 7" },
            new Category { Id = 8, Name = "Category 8" },
            new Category { Id = 9, Name = "Category 9" },
        };

        _items = new List<Item>
        {
            new Item { Id = 1, Name = "Item 1", Price = 10.99m, CreatedDate = DateTime.Now.AddDays(-5), Category = _categories[0]},
            new Item { Id = 2, Name = "Item 2", Price = 19.99m, CreatedDate = DateTime.Now.AddDays(-3), Category = _categories[1] },
            new Item { Id = 3, Name = "Item 3", Price = 5.99m, CreatedDate = DateTime.Now.AddDays(-1), Category = _categories[2] },
            new Item { Id = 4, Name = "Item 4", Price = 15.49m, CreatedDate = DateTime.Now.AddDays(-7), Category = _categories[3] },
            new Item { Id = 5, Name = "Item 5", Price = 7.89m, CreatedDate = DateTime.Now.AddDays(-10), Category = _categories[4] },
            new Item { Id = 6, Name = "Item 6", Price = 12.99m, CreatedDate = DateTime.Now.AddDays(-2), Category = _categories[5] },
            new Item { Id = 7, Name = "Item 7", Price = 8.59m, CreatedDate = DateTime.Now.AddDays(-4), Category = _categories[6] },
            new Item { Id = 8, Name = "Item 8", Price = 6.29m, CreatedDate = DateTime.Now.AddDays(-8), Category = _categories[7] },
            new Item { Id = 9, Name = "Item 9", Price = 11.79m, CreatedDate = DateTime.Now.AddDays(-6), Category = _categories[8] },
            new Item { Id = 10, Name = "Item 10", Price = 9.99m, CreatedDate = DateTime.Now.AddDays(-12), Category = _categories[2] },
            new Item { Id = 11, Name = "Item 11", Price = 13.49m, CreatedDate = DateTime.Now.AddDays(-9), Category = _categories[0] },
            new Item { Id = 12, Name = "Item 12", Price = 16.79m, CreatedDate = DateTime.Now.AddDays(-11), Category = _categories[1] },
            new Item { Id = 13, Name = "Item 13", Price = 18.99m, CreatedDate = DateTime.Now.AddDays(-15), Category = _categories[2] },
            new Item { Id = 14, Name = "Item 14", Price = 20.59m, CreatedDate = DateTime.Now.AddDays(-13), Category = _categories[3] },
            new Item { Id = 15, Name = "Item 15", Price = 22.99m, CreatedDate = DateTime.Now.AddDays(-17), Category = _categories[4] },
            new Item { Id = 16, Name = "Item 16", Price = 24.49m, CreatedDate = DateTime.Now.AddDays(-14), Category = _categories[5] },
            new Item { Id = 17, Name = "Item 17", Price = 26.79m, CreatedDate = DateTime.Now.AddDays(-16), Category = _categories[6] },
            new Item { Id = 18, Name = "Item 18", Price = 28.99m, CreatedDate = DateTime.Now.AddDays(-18), Category = _categories[7] },
            new Item { Id = 19, Name = "Item 19", Price = 30.49m, CreatedDate = DateTime.Now.AddDays(-20), Category = _categories[8] },
            new Item { Id = 20, Name = "Item 20", Price = 32.79m, CreatedDate = DateTime.Now.AddDays(-19), Category = _categories[7] },
            new Item { Id = 21, Name = "Item 21", Price = 34.99m, CreatedDate = DateTime.Now.AddDays(-25), Category = _categories[0] },
            new Item { Id = 22, Name = "Item 22", Price = 37.29m, CreatedDate = DateTime.Now.AddDays(-23), Category = _categories[1] },
            new Item { Id = 23, Name = "Item 23", Price = 40.59m, CreatedDate = DateTime.Now.AddDays(-21), Category = _categories[2] },
            new Item { Id = 24, Name = "Item 24", Price = 42.99m, CreatedDate = DateTime.Now.AddDays(-27), Category = _categories[3] },
            new Item { Id = 25, Name = "Item 25", Price = 45.79m, CreatedDate = DateTime.Now.AddDays(-30), Category = _categories[4] },
            new Item { Id = 26, Name = "Item 26", Price = 48.99m, CreatedDate = DateTime.Now.AddDays(-22), Category = _categories[5] },
            new Item { Id = 27, Name = "Item 27", Price = 50.49m, CreatedDate = DateTime.Now.AddDays(-24), Category = _categories[6] },
            new Item { Id = 28, Name = "Item 28", Price = 52.79m, CreatedDate = DateTime.Now.AddDays(-26), Category = _categories[7] },
            new Item { Id = 29, Name = "Item 29", Price = 54.99m, CreatedDate = DateTime.Now.AddDays(-28), Category = _categories[8] },
            new Item { Id = 30, Name = "Item 30", Price = 57.29m, CreatedDate = DateTime.Now.AddDays(-29), Category = _categories[6] },
            new Item { Id = 31, Name = "Item 31", Price = 59.99m, CreatedDate = DateTime.Now.AddDays(-35), Category = _categories[0] },
            new Item { Id = 32, Name = "Item 32", Price = 62.49m, CreatedDate = DateTime.Now.AddDays(-33), Category = _categories[1] },
            new Item { Id = 33, Name = "Item 33", Price = 64.79m, CreatedDate = DateTime.Now.AddDays(-31), Category = _categories[2] },
            new Item { Id = 34, Name = "Item 34", Price = 67.99m, CreatedDate = DateTime.Now.AddDays(-37), Category = _categories[3] },
            new Item { Id = 35, Name = "Item 35", Price = 70.59m, CreatedDate = DateTime.Now.AddDays(-40), Category = _categories[4] },
            new Item { Id = 36, Name = "Item 36", Price = 72.99m, CreatedDate = DateTime.Now.AddDays(-32), Category = _categories[5] },
            new Item { Id = 37, Name = "Item 37", Price = 75.79m, CreatedDate = DateTime.Now.AddDays(-34), Category = _categories[6] },
            new Item { Id = 38, Name = "Item 38", Price = 78.99m, CreatedDate = DateTime.Now.AddDays(-36), Category = _categories[7] },
            new Item { Id = 39, Name = "Item 39", Price = 80.49m, CreatedDate = DateTime.Now.AddDays(-38), Category = _categories[8] },
            new Item { Id = 40, Name = "Item 40", Price = 82.79m, CreatedDate = DateTime.Now.AddDays(-39), Category = _categories[5] },
            new Item { Id = 41, Name = "Item 41", Price = 84.99m, CreatedDate = DateTime.Now.AddDays(-45), Category = _categories[0] },
            new Item { Id = 42, Name = "Item 42", Price = 87.29m, CreatedDate = DateTime.Now.AddDays(-43), Category = _categories[1] },
            new Item { Id = 43, Name = "Item 43", Price = 89.59m, CreatedDate = DateTime.Now.AddDays(-41), Category = _categories[2] },
            new Item { Id = 44, Name = "Item 44", Price = 91.99m, CreatedDate = DateTime.Now.AddDays(-47), Category = _categories[3] },
            new Item { Id = 45, Name = "Item 45", Price = 94.79m, CreatedDate = DateTime.Now.AddDays(-50), Category = _categories[4] },
            new Item { Id = 46, Name = "Item 46", Price = 97.99m, CreatedDate = DateTime.Now.AddDays(-42), Category = _categories[5] },
            new Item { Id = 47, Name = "Item 47", Price = 100.49m, CreatedDate = DateTime.Now.AddDays(-44), Category = _categories[6] },
            new Item { Id = 48, Name = "Item 48", Price = 102.79m, CreatedDate = DateTime.Now.AddDays(-46), Category = _categories[7] },
            new Item { Id = 49, Name = "Item 49", Price = 104.99m, CreatedDate = DateTime.Now.AddDays(-48), Category = _categories[8] },
            new Item { Id = 50, Name = "Item 50", Price = 107.29m, CreatedDate = DateTime.Now.AddDays(-49), Category = _categories[7] }


        };
    }

    public IActionResult Index(string searchString, string sortOrder, int? pageNumber)
    {
        ViewData["CurrentSort"] = sortOrder;
        ViewData["NameSortParm"] = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
        ViewData["DateSortParm"] = sortOrder == "Date" ? "date_desc" : "Date";
        ViewData["PriceSortParm"] = sortOrder == "Price" ? "price_desc" : "Price";
        ViewData["CategorySortParm"] = String.IsNullOrEmpty(sortOrder) ? "categoryname_desc" : "";

        var items = from s in _items
                    select s;
        var category = _categories.FirstOrDefault(c => c.Name== searchString);
        if (category!=null)
        {
            items = items.Where(s => s.Category== category);
        }
        else { 
        if (!String.IsNullOrEmpty(searchString))
        {
            items = items.Where(s => s.Name.Contains(searchString));
        }
        }
        switch (sortOrder)
        {
            case "name_desc":
                items = items.OrderByDescending(s => s.Name);
                break;
            case "Date":
                items = items.OrderBy(s => s.CreatedDate);
                break;
            case "date_desc":
                items = items.OrderByDescending(s => s.CreatedDate);
                break;
            case "Price":
                items = items.OrderBy(s => s.Price);
                break;
            case "price_desc":
                items = items.OrderByDescending(s => s.Price);
                break;
            case "categoryname_desc":
                items = items.OrderBy(s => s.Category.Name);
                break;
            default:
                items = items.OrderBy(s => s.Name);
                break;
        }

        int pageSize = 8;

        // Зберегти параметри сортування та пошуку в URL
        ViewBag.CurrentFilter = searchString;
        ViewBag.CurrentSort = sortOrder;

        return View(PaginatedList<Item>.Create(items.AsQueryable(), pageNumber ?? 1, pageSize, _categories));
    }

    
}
