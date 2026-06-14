using System.Collections.Generic;
using System.Threading.Tasks;
using LibraryManagementSystemAPI.Data;
using Microsoft.EntityFrameworkCore;


namespace LibraryManagementSystemAPI.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        //This _context gives us access to the database.
        protected readonly AppDbContext _context;

        //_dbset representsthe specific table for T
        //if T is book then _dbset= _context.Books

        protected readonly DbSet<T> _dbSet;

        public GenericRepository(AppDbContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
        }

        public void Update(T entity)
        {
            _dbSet.Update(entity);
        }

        public void Delete(T entity)
        {
            _dbSet.Remove(entity);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync()) > 0;
        }
    }
}
