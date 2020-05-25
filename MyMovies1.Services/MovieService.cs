using System;
using System.Collections.Generic;
using MyMovies1.Models;
using MyMovies1.Repository;
using MyMovies1.Repository.Interfaces;
using MyMovies1.Services.Interfaces;

namespace MyMovies1.Services
{
    public class MovieService : IMovieService
    {
        public IMovieRepository MovieRepo { get; set; }

        public MovieService(IMovieRepository movieRepo)
        {
            MovieRepo = movieRepo;
        }
        public List<Movie> GetAll() 
        {
            var movies = MovieRepo.GetAll();
            return movies;
        }

        public Movie GetById(int id) 
        {
            var movie = MovieRepo.GetById(id);
            return movie;
        }

        public void CreateMovie(Movie movie) 
        {
            MovieRepo.Add(movie);
        }

        public List<Movie> GetByTitle(string title) 
        {
            var movies = MovieRepo.GetByTitle(title);
            return movies;
        }

        public List<Movie> GetByLetter(string letter) 
        {
            var movies = MovieRepo.GetByLetter(letter);
            return movies;
        }
    }
}
