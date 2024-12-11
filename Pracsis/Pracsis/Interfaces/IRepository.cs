namespace Pracsis.Interfaces
{
    public interface IRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(int Id);
        Task AddAsync(T item);
        Task UpdateAsync(T item);
        Task DeleteAsync(int Id);
    }
}
