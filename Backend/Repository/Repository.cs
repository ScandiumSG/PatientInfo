
using Backend.Data;
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
        public async T Create(T entity)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public async T Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public async List<T> GetAll()
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public async T GetSpecific(Guid id)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public async T Update(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
