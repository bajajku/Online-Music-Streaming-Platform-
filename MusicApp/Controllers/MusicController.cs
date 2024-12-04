using Microsoft.AspNetCore.Mvc;
using MusicApp.Models;
using SpotifyMVC.Models;
using SpotifyMVC.Services;
using System;
using System.Collections.Generic;

namespace MusicApp.Controllers
{
    public class MusicController : Controller
    {
        private readonly ISpotifyService _spotifyService;

        public MusicController(ISpotifyService spotifyService)
        {
            _spotifyService = spotifyService;
        }

        public IActionResult Player()
        {
            return View(); // Music player page
        }

        public async Task<IActionResult> AlbumDetails(string id)
        {
            if (string.IsNullOrEmpty(id))
                return NotFound();

            try
            {
                var album = await _spotifyService.GetAlbumAsync(id);
                if (album == null)
                    return NotFound();

                return View(album); // Pass the album to the view
            }
            catch (Exception ex)
            {
                // Log the error (optional)
                Console.WriteLine(ex.Message);
                return StatusCode(500, "An error occurred while fetching album details.");
            }
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
