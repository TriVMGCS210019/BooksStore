using BooksStore.Models;
using Microsoft.AspNetCore.Mvc;
using BooksStore.Models.ViewModels;
using Microsoft.EntityFrameworkCore;
using BooksStore;
using BooksStore.Repository;
using Microsoft.Extensions.Logging;

namespace BooksStore.Controllers {
    public class HomeController : Controller
    {
        private IStoreRepository repository;
        public int PageSize = 4;
        public HomeController(IStoreRepository repo, ILogin loguser) {
            repository = repo;
            _loginUser = loguser;
        }
        private readonly ILogin _loginUser;

        [HttpPost]
        public IActionResult Index(string username, string passcode)
        {
            var issuccess = _loginUser.AuthenticateUser(username, passcode);


            if (issuccess.Result != null)
            {
                ViewBag.username = string.Format("Successfully logged-in", username);

                TempData["username"] = "Ahmed";
                return RedirectToAction("Index", "Layout");
            }
            else
            {
                ViewBag.username = string.Format("Login Failed ", username);
                return View();
            }
        }
        public ViewResult Index(string? category, int productPage = 1)
            => View(new ProductsListViewModel {
                Products = repository.Products
                    .Where(p => category == null || p.Category == category)
                    .OrderBy(p => p.ProductID)
                    .Skip((productPage - 1) * PageSize)
                    .Take(PageSize),
                PagingInfo = new PagingInfo {
                    CurrentPage = productPage,
                    ItemsPerPage = PageSize,
                    TotalItems = category == null
                        ? repository.Products.Count()
                        : repository.Products.Where(e =>
                            e.Category == category).Count()
                },
                CurrentCategory = category
            });
    }

}