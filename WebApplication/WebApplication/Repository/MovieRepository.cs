using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System.Web;
//using AdvancedQueryingSystem.Models.Interfaces;

namespace WebApplication.Repository
{
    public class MovieRepository<Movie> : IMovieRepository<Movie> where Movie : class
    {
        protected DbSet<Movie> dbSet;

        private readonly DbContext _dbContext;

        public MovieRepository(DbContext dbContext)
        {
            _dbContext = dbContext;
            dbSet = _dbContext.Set<Movie>();
        }

        public IQueryable<Movie> GetAll()
        {
            return dbSet;
        }

        public async Task<Movie> GetByIdAsync(int id)
        {
            return await dbSet.FindAsync(id);
        }

        public IQueryable<Movie> SearchFor(Expression<Func<Movie, bool>> predicate)
        {
            return dbSet.Where(predicate);
        }

        public async Task EditAsync(Movie movie)
        {
            _dbContext.Entry(movie).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }

        public async Task InsertAsync(Movie movie)
        {
            dbSet.Add(movie);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(Movie movie)
        {
            dbSet.Remove(movie);
            await _dbContext.SaveChangesAsync();
        }
    }
}