using Microsoft.AspNetCore.Mvc;

public class AccountController : Controller
{
    [HttpGet]
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

    [HttpGet]
    public IActionResult SignupPage()
    {
        return View();
    }

    [HttpPost]
    public IActionResult SignupPage(User user)
    {
        // Simulate user storage (replace with actual database or repository logic)
        var existingUsers = new List<User>
        {
            new User { Username = "test", Password = "123", Email = "test@example.com", IsPremium = false }
        };

        // Check if username already exists
        if (existingUsers.Any(u => u.Username == user.Username))
        {
            TempData["ErrorMessage"] = "Username already exists. Please choose a different username.";
            return RedirectToAction("SignupPage");
        }

        // Validate inputs
        if (string.IsNullOrWhiteSpace(user.Username) || string.IsNullOrWhiteSpace(user.Password) || string.IsNullOrWhiteSpace(user.Email))
        {
            TempData["ErrorMessage"] = "All fields are required.";
            return RedirectToAction("SignupPage");
        }

        // Save the user (in-memory storage for now)
        existingUsers.Add(user);

        TempData["SuccessMessage"] = "Signup successful! Please log in.";
        return RedirectToAction("LoginPage");
    }

    public IActionResult Profile()
    {
        return View(); // Profile page placeholder
    }
}
