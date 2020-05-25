using System;
using System.Collections.Generic;
using System.Text;
using MyMovies1.Models;

namespace MyMovies1.Repository.Interfaces
{
   public interface IMovieRepository
    {
        List<Movie> GetAll();


       Movie GetById(int id);

       void Add(Movie movie);
        List<Movie> GetByTitle(string title);

        List<Movie> GetByLetter(string letter);
    }
}
