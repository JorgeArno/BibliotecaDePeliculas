using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyContext;
using Entity;
using System.Data.Entity;

namespace Services
{
    public class Serivices
    {
        ContextDB context = new ContextDB();
        
        public void addMovie(string title, short time, short year)
        {
            Movie myMovie = new Movie();

            myMovie.title = title;
            myMovie.time = time;
            myMovie.year = year;
            context.Movies.Add(myMovie);

        }

        public List<Movie> getMovies()
        {
            return context.Movies.ToList();
        }

        public List<Movie> searchMovies(string mName)
        {
            if(mName.Equals(string.Empty))
            {
                return context.Movies.ToList();
            }
            else
            {
                return context.Movies.Where(myMovie => myMovie.title.Contains(mName)).ToList();
            }
        }

        public void updateMovie(int id, string title, short time, short year)
        {
            var myMovieList = from x in context.Movies
                              where x.ID == id
                              select x;

            foreach(Movie myMovie in myMovieList)
            {
                myMovie.title = title;
                myMovie.time = time;
                myMovie.year = year;
            }
            context.SaveChanges();

        }

        public void deleteMovie(int id)
        {
            var myMovieList = from x in context.Movies
                              where x.ID == id
                              select x;

            foreach(Movie myMovie in myMovieList)
            {
                context.Movies.Remove(myMovie);
            }
            context.SaveChanges();
        }


    }
}
