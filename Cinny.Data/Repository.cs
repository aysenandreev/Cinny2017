using System.Collections.Generic;
using System.Linq;
using Cinny.Data.Models;

namespace Cinny.Data
{
    public class Repository
    {       
        private Context context = new Context();

        public void DeleteShows()
        {
            foreach (Show s in context.Shows)
            {
                context.Shows.Remove(s);
            }
            context.SaveChanges();
        }

        public void DeleteShowsPlanned()
        {
            foreach (ShowPlanned s in context.ShowsPlanned)
            {
                context.ShowsPlanned.Remove(s);
            }
            context.SaveChanges();
        }

        public void DeleteMovies()
        {
            foreach (Movie m in context.Movies)
            {
                context.Movies.Remove(m);
            }
            context.SaveChanges();
        }

        public void DeleteMoviesPlanned()
        {
            foreach (MoviePlanned m in context.MoviesPlanned)
            {
                context.MoviesPlanned.Remove(m);
            }
            context.SaveChanges();
        }

        public void AddUser(User user)
        {

            context.Users.Add(user);
            context.SaveChanges();
        }

        public void AddShow(Show show)
        {

            context.Shows.Add(show);
            context.SaveChanges();
        }

        public void AddShowPlanned(ShowPlanned showplanned)
        {

            context.ShowsPlanned.Add(showplanned);
            context.SaveChanges();
        }

        public void AddMovie(Movie movie)
        {
            context.Movies.Add(movie);
            context.SaveChanges();
        }

        public void AddMoviePlanned(MoviePlanned movieplanned)
        {

            context.MoviesPlanned.Add(movieplanned);
            context.SaveChanges();
        }
    }
}

