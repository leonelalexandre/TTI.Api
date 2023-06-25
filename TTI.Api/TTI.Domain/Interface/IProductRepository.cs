using System.Collections.Generic;
using System.Threading.Tasks;
using TTI.Domain.Entity;

namespace TTI.Domain.Interface
{
    public interface IProductRepository
    {
        Task AddAsync(Product product);
        Task EditAsync(Product product);
        Task DeleteAsync(Product product);
        Task<Product> GetById(int id);
        Task<IEnumerable<Product>> Filter();
        Task<bool> SaveAllAsync();
        Task<IEnumerable<Product>> GetByKeyword(string keyword);
    }
}
