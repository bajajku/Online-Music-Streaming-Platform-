using Microsoft.AspNetCore.Mvc;
using MusicApp.Models;
using SpotifyMVC.Models;
using System;
using System.Collections.Generic;

namespace MusicApp.Controllers
{
    public class MusicController : Controller
    {
        public IActionResult Player()
        {
            return View(); // Music player page
        }

        // Action for displaying album details
        // public IActionResult AlbumDetails(int id)
        // {
            // Sample album data, replace with actual data fetching logic
            
            // var album = new Album
            // {
            //     Title = "Sample Album",
            //     Artist = "Sample Artist",
            //     ReleaseDate = new DateTime(2024, 1, 1),
            //     Genre = "Pop",
            //     Songs = new List<Song>
            //     {
            //         new Song { Title = "Song 1", Duration = TimeSpan.Parse("3:30") },
            //         new Song { Title = "Song 2", Duration = TimeSpan.Parse("4:00") }
            //     }
            // };

            // // Return the view with album details
            // return View(album);
        // }
    }
}
