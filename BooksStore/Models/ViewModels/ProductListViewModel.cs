using BooksStore.Models.ViewModels;
using BooksStore.Models;
using Microsoft.AspNetCore.Mvc;

namespace BooksStore.Models.ViewModels
{
    public class ProductsListViewModel
    {
        public IEnumerable<Product> Products { get; set; }
            = Enumerable.Empty<Product>();
        public PagingInfo PagingInfo { get; set; } = new();
        public string? CurrentCategory { get; set; }
    }
}
