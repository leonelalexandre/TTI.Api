using System.Collections.Generic;
using System.Threading.Tasks;
using TTI.Domain.Entity;

namespace TTI.Domain.Interface
{
    public interface ISubCategoryRepository
    {
        Task AddAsync(SubCategory subCategory);
        Task EditAsync(SubCategory subCategory);
        Task DeleteAsync(SubCategory subCategory);
        Task<SubCategory> GetById(int id);
        Task<IEnumerable<SubCategory>> Filter();
        Task<bool> SaveAllAsync();
    }
}
