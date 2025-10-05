
namespace SeverN.SharedKernel.Application;

public interface IRepository<T, TKey> where T : class
{
    Task<T> GetByIdAsync(TKey key);

    Task<TKey> CreateAsync(T entity);

    Task<bool> DeleteAsync(TKey key); 

    Task<bool> UpdateAsync(T key); 
}
