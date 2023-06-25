using TTI.Application.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TTI.Application.Interface
{
    public interface ICategoryService
    {
        Task<bool> AddAsync(CategoryPostDto categoryDto);
        Task<bool> EditAsync(CategoryPostDto categoryDto);
        Task<bool> DeleteAsync(int id);
        Task<CategoryGetDto> GetById(int id);
        Task<IEnumerable<CategoryGetDto>> Filter();
    }
}
