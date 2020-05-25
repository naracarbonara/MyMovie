using System;
using System.Collections.Generic;
using System.Text;
using MyMovies1.Models;

namespace MyMovies1.Services.Interfaces
{
   public interface IMovieService
    {
        List<Movie> GetAll();


        Movie GetById(int id);
        void CreateMovie(Movie movie);
        List<Movie> GetByTitle(string title);
        List<Movie> GetByLetter(string letter);
    }
}