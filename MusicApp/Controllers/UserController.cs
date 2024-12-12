using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MusicApp.Data;
using MusicApp.Models.Dtos;
using SpotifyMVC.Models;
using System.Security.Claims;

namespace MusicApp.Controllers
{
    public class UserController : Controller
    {
        private readonly MusicAppDbContext _context;

        public UserController(MusicAppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View(_context.Users.ToList());
        }

        public IActionResult Registration()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Registration(RegistrationDto registrationDto)
        {
            if (ModelState.IsValid)
            {
                User user = new User();
                user.Email = registrationDto.Email;
                user.FirstName = registrationDto.FirstName;
                user.LastName = registrationDto.LastName;
                user.Password = registrationDto.Password;
                user.Username = registrationDto.Username;
                user.IsPremium = false;
                user.Albums = new List<Album>();

                try
                {
                    _context.Users.Add(user);
                    _context.SaveChanges();

                    ModelState.Clear();
                    ViewBag.Message = $"{user.FirstName} {user.LastName} registered successfully. Please Login.";
                }
                catch (DbUpdateException ex)
                {
                    ModelState.AddModelError("", "Please enter unique Email or Password.");
                    return View(registrationDto);
                }

                return View();
            }
            return View(registrationDto);
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginDto loginDto)
        {
            if (ModelState.IsValid)
            {
                var user = _context.Users.Where(x => (x.Username == loginDto.UsernameOrEmail || x.Email == loginDto.UsernameOrEmail) && x.Password == loginDto.Password).FirstOrDefault();
                if (user != null)
                {
                    var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Name, user.Email),
                        new Claim("Name", user.FirstName),
                        new Claim(ClaimTypes.Role, "User")
                    };

                    var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));

                    return RedirectToAction("SecurePage");
                }
                else
                {
                    ModelState.AddModelError("", "Username/Email or Password is not correct");
                }
            }
            return View(loginDto);
        }

        public IActionResult LogOut()
        {
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("RegistrationPage", "Home");
        }

        [Authorize]
        public IActionResult SecurePage()
        {
            ViewBag.Name = HttpContext.User.Identity.Name;
            return RedirectToAction("Index", "Home");
        }

        public IActionResult IsUserLoggedIn()
        {
            var isLoggedIn = HttpContext.User.Identity?.IsAuthenticated ?? false;
            return Json(new { IsLoggedIn = isLoggedIn });
        }

        [HttpPost]
[Authorize]
public IActionResult AddAlbumToUser(string albumId)
{
    var userEmail = HttpContext.User.Identity?.Name;
    if (userEmail == null)
    {
        return Unauthorized();
    }

    var user = _context.Users.Include(u => u.Albums).FirstOrDefault(u => u.Email == userEmail);
    if (user == null)
    {
        return NotFound("User not found.");
    }

    var album = _context.Albums.FirstOrDefault(a => a.Id == albumId);
    if (album == null)
    {
        return NotFound("Album not found.");
    }

    if (!user.Albums.Contains(album))
    {
        user.Albums.Add(album);
        _context.SaveChanges();
    }

    return Json(new { success = true, message = "Album added successfully." });
}


    }
}
