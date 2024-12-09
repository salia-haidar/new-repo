using Microsoft.EntityFrameworkCore;
using SuperHeroAPI.Data;

namespace SuperHeroAPI.Repositories
{
    public class HeroRepository
    {
        private readonly DataContext _context;
        public HeroRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Hero>> GetAllAsync()
        {
            return await _context.Heroes.ToListAsync();               
        }

        public async Task<Hero> GetByIdAsync(int id)
        {
            return await _context.Heroes.FindAsync(id);
        }
        public async Task CreateAsync(Hero hero)
        {
            await _context.Heroes.AddAsync(hero);   
            await _context.SaveChangesAsync();
        }
        public async Task UpdateAsync(Hero hero)
        {
            _context.Heroes.Update(hero);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteAsync(int id)
        {
            var hero = await _context.Heroes.FindAsync(id);
            _context.Heroes.Remove(hero);
            await _context.SaveChangesAsync();
        }
    }
}
