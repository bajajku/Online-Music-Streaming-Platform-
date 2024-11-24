using Microsoft.AspNetCore.Mvc;

namespace MusicApp.Controllers
{
    public class MusicController : Controller
    {
        public IActionResult Player()
        {
            return View(); // Music player page
        }
    }

}
