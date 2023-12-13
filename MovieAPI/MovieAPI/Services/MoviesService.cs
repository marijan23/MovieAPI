using MovieAPI.Data;
using System;

namespace MovieAPI.Services
{
    public class MoviesService
    {
        private MovieAPIContext _context;
        public MoviesService(MovieAPIContext context)
        {
            _context = context;
        }
        public void AddMovie(MovieVM Movie)
        {
            var newMovie = new Movie()
            {
                Name=Movie.Name,
                Year=Movie.Year,
                Genre= Movie.Genre
            };
            _context.Movie.Add(newMovie);
            _context.SaveChanges();
        }

        public List<Movie> GetAllMovies()
        {
            return _context.Movie.ToList();
        }
        public Movie GetMovieById(int id)
        {
            return _context.Movie.FirstOrDefault(x => x.ID == id);
        }

        public void DeleteMovie(int id)
        {
            var movie = _context.Movie.FirstOrDefault(x => x.ID == id);
            _context.Movie.Remove(movie);
            _context.SaveChanges();
        }

        public Movie UpdateMovieById(int id, MovieVM movieVM)
        {
            var movie = _context.Movie.FirstOrDefault(x => x.ID == id);
            if (movie != null)
            {
                movie.Name= movieVM.Name; 
                movie.Year= movieVM.Year; 
                movie.Genre= movieVM.Genre;
                _context.SaveChanges();
            }
            return movie;
        }
    }
}
