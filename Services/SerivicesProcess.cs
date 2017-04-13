using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyContext;
using Entity;
using System.Data.Entity;
using System.Windows.Forms;

namespace Services
{
    public class SerivicesProcess
    {
        ContextDB context = new ContextDB();
        
        public void addMovie(string title, int time, int year)
        {
            if (title.Equals(string.Empty))
            {
                MessageBox.Show("El campo titulo no puede estar vacio", "Campo Titulo Es Obligatorio", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                try
                {
                    Movie myMovie = new Movie();

                    myMovie.title = title;
                    myMovie.time = time;
                    myMovie.year = year;
                    context.Movies.Add(myMovie);
                    context.SaveChanges();
                    MessageBox.Show("Pelicula agregada correctamente", "Pelicula Agregada", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch(Exception error)
                {
                    MessageBox.Show(error.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            

        }

        public void loadMovie(int id, TextBox title, TextBox duration, TextBox year)
        {
            try
            {
                var myMovieList = from x in context.Movies
                                  where x.ID == id
                                  select x;

                foreach (Movie myMovie in myMovieList)
                {
                    title.Text = myMovie.title;
                    duration.Text = myMovie.title;
                    year.Text = Convert.ToString(myMovie.year);
                }
            }
            catch(Exception error)
            {
                MessageBox.Show(error.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public List<Movie> getMovies()
        {
            try
            {
                return context.Movies.ToList();
            }
            catch(Exception error)
            {
                MessageBox.Show(error.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public List<Movie> searchMovies(string mName)
        {
            try
            {
                if (mName.Equals(string.Empty))
                {
                    return context.Movies.ToList();
                }
                else
                {
                    return context.Movies.Where(myMovie => myMovie.title.Contains(mName)).ToList();
                }
            }
            catch(Exception error)
            {
                MessageBox.Show(error.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public void updateMovie(int id, string title, int time, int year)
        {
            try
            {
                var myMovieList = from x in context.Movies
                                  where x.ID == id
                                  select x;

                foreach (Movie myMovie in myMovieList)
                {
                    myMovie.title = title;
                    myMovie.time = time;
                    myMovie.year = year;
                }
                context.SaveChanges();
            }
            catch(Exception error)
            {
                MessageBox.Show(error.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        public void deleteMovie(int id)
        {
            try
            {
                DialogResult delete;

                delete = MessageBox.Show("Realmente desea eliminar esta pelicula?", "Eliminar Pelicula", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if(delete == DialogResult.Yes)
                {
                    var myMovieList = from x in context.Movies
                                      where x.ID == id
                                      select x;

                    foreach (Movie myMovie in myMovieList)
                    {
                        context.Movies.Remove(myMovie);
                    }
                    context.SaveChanges();
                }
                
            }
            catch(Exception error)
            {
                MessageBox.Show(error.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
           
        }


    }
}
