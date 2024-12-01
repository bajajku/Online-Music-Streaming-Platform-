using Microsoft.AspNetCore.Mvc;
using MusicApp.Models;

public class AccountController : Controller
{
    public IActionResult LoginPage()
    {
        return View();
    }

    [HttpPost]
    public IActionResult LoginPage(string username, string password)
    {
        if (username == "test" && password == "123") // Dummy validation
        {
            TempData["SuccessMessage"] = "Login successful!";
            return RedirectToAction("Index", "Home");
        }
        else
        {
            TempData["ErrorMessage"] = "Invalid username or password.";
            return RedirectToAction("LoginPage");
        }
    }

    public IActionResult SignupPage()
    {
        return View();
    }

    [HttpPost]
    public IActionResult SignupPage(User user)
    {
        TempData["SuccessMessage"] = "Signup successful! Please login.";
        return RedirectToAction("LoginPage");
    }

    public IActionResult Profile()
    {
        return View(); // Profile page placeholder
    }
}
