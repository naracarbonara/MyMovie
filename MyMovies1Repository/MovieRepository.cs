using System;
using System.Collections.Generic;
using System.Linq;
using MyMovies1.Models;
using MyMovies1.Repository.Interfaces;
using Newtonsoft.Json;

namespace MyMovies1.Repository
{
    public class MovieRepository:IMovieRepository
    {
        public List<Movie> Movies { get; set; }

        public MovieRepository()
        {
            Movies = new List<Movie>();
            var movie1 = new Movie()
            {
                Id = 1,
                ImageUrl = "https://m.media-amazon.com/images/M/MV5BNzY2NzI4OTE5MF5BMl5BanBnXkFtZTcwMjMyNDY4Mw@@._V1_UY209_CR0,0,140,209_AL_.jpg",
                Title = "Black Swan",
                Description = "A committed dancer struggles to maintain her sanity after winning the lead role in a production of Tchaikovsky's 'Swan Lake'.",
                //Cast = new List<string> {"Natalie Portman", "Mila Kunis", "Vincent Cassel" }
                Cast = "Natalie Portman"

            };
            var movie2 = new Movie()
            {
                Id=2,
                ImageUrl = "https://m.media-amazon.com/images/M/MV5BNzkxODk0NjEtYjc4Mi00ZDI0LTgyYjEtYzc1NDkxY2YzYTgyXkEyXkFqcGdeQXVyNzkwMjQ5NzM@._V1_UX140_CR0,0,140,209_AL_.jpg",
                Title = "Full Metal Jacket",
                Description = "A pragmatic U.S. Marine observes the dehumanizing effects the Vietnam War has on his fellow recruits from their brutal boot camp training to the bloody street fighting in Hue.",
                //Cast = new List<string> { "Matthew Modine", "Adam Baldwin", "Vincent D'Onofrio" }
                Cast = "Matthew Modine"
            };


            Movies.Add(movie1);
            Movies.Add(movie2);
        }

        public List<Movie> GetAll()
        {
            var tmp = JsonConvert.SerializeObject(Movies);

            return Movies;
        }

        public Movie GetById(int id) 
        {
            return Movies.FirstOrDefault(x => x.Id == id);
        }

        public void Add(Movie movie) 
        {
            var movies = GetAll();
            var maxId = movies.Max(x => x.Id);
            movie.Id = maxId + 1;
            Movies.Add(movie);
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
