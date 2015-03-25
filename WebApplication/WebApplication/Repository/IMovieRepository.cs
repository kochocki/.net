using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System.Web;

namespace WebApplication.Repository
{
        public interface IMovieRepository<Movie>
        {
            Task<Movie> GetByIdAsync(int id);

            IQueryable<Movie> SearchFor(Expression<Func<Movie, bool>> predicate);

            IQueryable<Movie> GetAll();

            Task EditAsync(Movie movie);

            Task InsertAsync(Movie movie);
            
            Task DeleteAsync(Movie movie);

        }
}