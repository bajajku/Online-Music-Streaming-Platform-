using Microsoft.AspNetCore.Mvc;
using MusicApp.Models;
using System.Diagnostics;

namespace MusicApp.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }


    public IActionResult RegistrationPage()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
public IActionResult Error()
{
    return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
}
public IActionResult Search(string query)
    {
        // Implement search logic here
        var results = new List<SearchResult>
        {
            new SearchResult { Id = 1, Title = "Album Title", Artist = "Artist Name" },
            new SearchResult { Id = 2, Title = "Another Album", Artist = "Another Artist" }
        };

        return View(results); // Pass results to the Search view
    }
}

public class SearchResult
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Artist { get; set; }
}
