namespace SuperHeroAPI.Repositories
{
    public interface IRepository<Hero>
    {
        Task<IEnumerable<Hero>> GetAllAsync();
        Task<Hero> GetByIdAsync(int id);
        Task CreateAsync(Hero entity);
        Task UpdateAsync(Hero entity);
        Task DeleteAsync(int id);
    } 
}
