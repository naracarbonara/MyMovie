using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using MyMovies1.Models;
using MyMovies1.Repository.Interfaces;

namespace MyMovies1.Repository
{
    public class MovieSqlRepository : IMovieRepository
    {
        public void Add(Movie movie)
        {
            using (var cnn = new SqlConnection("Data Source=.\\SQLEXPRESS; Initial Catalog=MyMoviesSqlDemo; Integrated Security=true"))
            {
                cnn.Open();
                var query = @"Insert into movies(Title, Description, ImageUrl, Cast) values
                    (@Title, @Description, @ImageUrl, @Cast)";
                var cmd = new SqlCommand(query, cnn);
                cmd.Parameters.AddWithValue("@Title", movie.Title);
                cmd.Parameters.AddWithValue("@Description", movie.Description);
                cmd.Parameters.AddWithValue("@ImageUrl", movie.ImageUrl);
                cmd.Parameters.AddWithValue("@Cast", movie.Cast);
                cmd.ExecuteNonQuery();
            }
        }
        public List<Movie> GetAll()
        {
            var result = new List<Movie>();
            using (var cnn = new SqlConnection("Data Source=.\\SQLEXPRESS; Initial Catalog=MyMoviesSqlDemo; Integrated Security=true"))
            {
                cnn.Open();
                var cmd = new SqlCommand("select * from movies", cnn);
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    var movie = new Movie();
                    movie.Id = reader.GetInt32(0);
                    movie.Title = reader.GetString(1);
                    movie.Description = reader.GetString(2);
                    movie.ImageUrl = reader.GetString(3);
                    movie.Cast = reader.GetString(4);

                    result.Add(movie);
                }
            }
            return result;
        }

        public Movie GetById(int id)
        {
            Movie result = null;
            using (var cnn = new SqlConnection("Data Source=.\\SQLEXPRESS; Initial Catalog=MyMoviesSqlDemo; Integrated Security=true"))
            {
                cnn.Open();
                var cmd = new SqlCommand($"select * from movies where id={id}", cnn);
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    result = new Movie();
                    result.Id = reader.GetInt32(0);
                    result.Title = reader.GetString(1);
                    result.Description = reader.GetString(2);
                    result.ImageUrl = reader.GetString(3);
                    result.Cast = reader.GetString(4);


                }
            }
            return result;
        }

        public List<Movie> GetByTitle(string title)
        {
            var result = new List<Movie>();
            using (var cnn = new SqlConnection("Data Source=.\\SQLEXPRESS; Initial Catalog=MyMoviesSqlDemo; Integrated Security=true"))
            {
                cnn.Open();
                var query = "select * from movies";
                if (!String.IsNullOrEmpty(title))
                {
                    query = $"{query} where title like @title";
                }

                var cmd = new SqlCommand(query, cnn);
                if (!String.IsNullOrEmpty(title))
                {
                    cmd.Parameters.AddWithValue("@title", $"%{title}%");
                }

                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    var movie = new Movie();
                    movie.Id = reader.GetInt32(0);
                    movie.Title = reader.GetString(1);
                    movie.Description = reader.GetString(2);
                    movie.ImageUrl = reader.GetString(3);
                    movie.Cast = reader.GetString(4);
                    result.Add(movie);
                }
            }
            return result;
        }

        public List<Movie> GetByLetter(string letter)
        {
            var result = new List<Movie>();
            using (var cnn = new SqlConnection("Data Source=.\\SQLEXPRESS; Initial Catalog=MyMoviesSqlDemo; Integrated Security=true"))
            {
                cnn.Open();
                var query = "select * from movies";
                if (!String.IsNullOrEmpty(letter)) 
                {
                    query = $"{query} where lower(title) like @letter";
                }

                var cmd = new SqlCommand(query, cnn);
                if (!String.IsNullOrEmpty(letter)) 
                {
                    cmd.Parameters.AddWithValue("@letter", $"{letter}%");
                }
                var reader = cmd.ExecuteReader();
                while (reader.Read()) 
                {
                    var movie = new Movie();
                    movie.Id = reader.GetInt32(0);
                    movie.Title = reader.GetString(1);
                    movie.Description = reader.GetString(2);
                    movie.ImageUrl = reader.GetString(3);
                    movie.Cast = reader.GetString(4);
                    result.Add(movie);
                }

            }
            return result;
        }
        
    }
}
