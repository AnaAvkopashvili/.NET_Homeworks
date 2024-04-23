using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace To_Do.Infrastructure
{
    public class BaseRepository<T> where T : class
    {
        protected readonly DbContext _context;
        protected readonly DbSet<T> _dbSet;

        public BaseRepository(DbContext context)
        {
            _dbSet = context.Set<T>();
            _context = context;
        }

        public async Task<List<T>?> GetAllAsync(CancellationToken cancellationToken)
        {
            var result = await _dbSet.ToListAsync(cancellationToken);
            return result;
        }

        public async Task<T> GetAsync(CancellationToken cancellationToken, params object[] key)
        {
            return await _dbSet.FindAsync(key, cancellationToken);
        }

        public async Task CreateAsync(CancellationToken cancellationToken, T entity)
        {
            await _dbSet.AddAsync(entity, cancellationToken); 
            await _context.SaveChangesAsync(cancellationToken); 
        }

        public async Task UpdateAsync(CancellationToken cancellationToken, T entity)
        {
            if(entity == null)
            {
                return;
            }
            _dbSet.Update(entity);
            await _context.SaveChangesAsync(cancellationToken);
        }
        public async Task PatchAsync(CancellationToken cancellationToken, int id,  T entity)
        {
            var existingEntity = await GetAsync(cancellationToken, id);
            if (existingEntity == null)
            {
                return;
            }

            var entityType = typeof(T);
            var properties = entityType.GetProperties();

            foreach (var property in properties)
            {
                var newValue = property.GetValue(entity);
                if (newValue != null && !newValue.Equals(0) && !newValue.Equals(default(DateTime)))
                {
                    property.SetValue(existingEntity, newValue);
                }
            }

            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task DeleteAsync(CancellationToken cancellationToken, T entity)
        {
            if (entity == null)
            {
                return;
            }
            _dbSet.Remove(entity);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task DeleteAsync(CancellationToken cancellationToken, params object[] key)
        {
            var entity = await GetAsync(cancellationToken, key);
            _dbSet.Remove(entity);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public Task<bool> AnyAsync(CancellationToken cancellationToken, Expression<Func<T, bool>> predicate)
        {
            return _dbSet.AnyAsync(predicate, cancellationToken);
        }
    }
}
