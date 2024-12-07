
using Backend.Data;
using Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace Backend.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private DataContext _context;
        private DbSet<T> _dbSet;

        public Repository(DataContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }

        /// <inheritdoc />
        public async Task<T?> Create(T entity)
        {
            var res = await _dbSet.AddAsync(entity);
            await _context.SaveChangesAsync();

            return res.Entity;
        }

        /// <inheritdoc />
        public async Task<T?> Delete(T entity)
        {
            var res = _dbSet.Remove(entity);
            await _context.SaveChangesAsync();

            return res.Entity;
        }

        /// <inheritdoc />
        public async Task<List<T>> GetAll()
        {
            return await _dbSet.ToListAsync();
        }

        /// <inheritdoc />
        public async Task<T?> GetSpecific(Guid id)
        {
            return await _dbSet.FindAsync(id);
        }

        /// <inheritdoc />
        public async Task<T?> Update(T entity)
        {
            var res = _dbSet.Update(entity);
            await _context.SaveChangesAsync();

            return res.Entity;
        }
    }
}
