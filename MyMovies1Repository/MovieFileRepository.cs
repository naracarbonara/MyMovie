using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using MyMovies1.Models;
using MyMovies1.Repository.Interfaces;
using Newtonsoft.Json;

namespace MyMovies1.Repository
{
   public class MovieFileRepository: IMovieRepository
    {
        public List<Movie> Movies { get; set; }

        public MovieFileRepository()
        {
            var movies = File.ReadAllText("movies.txt");
            Movies = JsonConvert.DeserializeObject<List<Movie>>(movies);
        }
        public List<Movie> GetAll() 
        {
            return Movies;
        }


        public Movie GetById(int id) 
        {
            return Movies.FirstOrDefault(x => x.Id == id);
        }

        public void Add(Movie movie) 
        {
            var movies = GetAll();
            var max = movies.Max(x => x.Id);
            movie.Id = max + 1;
            Movies.Add(movie);
            var json = JsonConvert.SerializeObject(movie);
            File.WriteAllText("movies.txt", json);
        }

        public List<Movie> GetByTitle(string title)
        {
            throw new NotImplementedException();
        }
        public List<Movie> GetByLetter(string title)
        {
            throw new NotImplementedException();
        }
    }
}
