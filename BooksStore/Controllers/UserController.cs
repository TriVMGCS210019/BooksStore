using BooksStore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using BooksStore.Repository;

namespace BooksStore.Controllers
{
    public class UserController : Controller
    {
        private readonly ILogin _loginUser;

        public UserController(ILogin loguser)
        {
            _loginUser = loguser;
        }

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

    }
}