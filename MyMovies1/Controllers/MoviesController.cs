using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MyMovies1.Models;
using MyMovies1.Services;
using MyMovies1.Services.Interfaces;

namespace MyMovies1.Controllers
{
    public class MoviesController:Controller
    {
        public IMovieService MovieService { get; set; }
        public MoviesController(IMovieService service)
        {
            MovieService = service;
        }
        public IActionResult Overview(string title)
        {
            //var movies = MovieService.GetByTitle(title);
            var movies = MovieService.GetByLetter(title);
            if (movies.Count == 0) 
            {
                movies = MovieService.GetByTitle(title);
            }
            return View(movies);
        }

       

        public IActionResult Details(int id)
        {
            var movie = MovieService.GetById(id);
            return View(movie);
        }
        [HttpGet]
        public IActionResult Create() 
        {
            var movie = new Movie();
            return View(movie);
        }

        [HttpPost]
        public IActionResult Create(Movie movie)
        {    //call service to create new recipe;

            if (ModelState.IsValid)
            {
                MovieService.CreateMovie(movie); 
                return RedirectToAction("Overview");
            }
            else 
            {
                return View(movie);
            }
            
        }
    }
}
