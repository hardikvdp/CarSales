using System.Collections.Generic;
using System.Threading.Tasks;

namespace CarSales.Data.Repository.v1
{
    public interface IDataRepository<T>
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetAsync(int Id);
        Task<T> GetByNameAsync(string name);
        Task<T> AddAsync(T entity);
        Task<T> UpdateAsync(T entity);
        Task<T> DeleteAsync(int Id);
    }
}
