using Microsoft.EntityFrameworkCore;
using Pracsis.DB;
using Pracsis.Interfaces;

namespace Pracsis.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly TestingdbContext _context;
        private readonly DbSet<T> _dbSet;
        public Repository(TestingdbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }
        public async Task<T> GetByIdAsync(int Id)
        {
            return await _dbSet.FindAsync();
        }
        public async Task AddAsync(T item)
        {
            await _dbSet.AddAsync(item);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateAsync(T item)
        {
            _dbSet.Update(item);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteAsync(int Id)
        {
            var item = await GetByIdAsync(Id);
            if(item != null)
            {
                _dbSet.Remove(item);
                await _context.SaveChangesAsync();
            }
        }
    }   
}
