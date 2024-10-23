using Microsoft.AspNetCore.Mvc;

namespace MusicApp.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string username, string password)
        {
            // Add logic for user authentication
            return RedirectToAction("Index", "Home");
        }

        public IActionResult Signup()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Signup(User user)
        {
            // Add logic to save the user to the database
            return RedirectToAction("Login");
        }

        public IActionResult Profile()
        {
            return View(); // Future profile page
        }
    }
}
