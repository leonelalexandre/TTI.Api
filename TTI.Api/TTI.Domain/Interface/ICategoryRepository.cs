using System.Collections.Generic;
using System.Threading.Tasks;
using TTI.Domain.Entity;

namespace TTI.Domain.Interface
{
    public interface ICategoryRepository
    {
        Task AddAsync(Category category);
        Task EditAsync(Category category);
        Task DeleteAsync(Category category);
        Task<Category> GetById(int id);
        Task<IEnumerable<Category>> Filter();
        Task<bool> SaveAllAsync();
    }
}
