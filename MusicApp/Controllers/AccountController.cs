using Microsoft.AspNetCore.Mvc;

namespace MusicApp.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult LoginPage()
        {
            return View();
        }

        [HttpPost]
        public IActionResult LoginPage(string username, string password)
        {
            // Add logic for user authentication
            return RedirectToAction("Index", "Home");
        }

        public IActionResult SignupPage()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SignupPage(User user)
        {
            // Add logic to save the user to the database
            return RedirectToAction("LoginPage");
        }

        public IActionResult Profile()
        {
            return View(); // Future profile page
        }
    }
}
