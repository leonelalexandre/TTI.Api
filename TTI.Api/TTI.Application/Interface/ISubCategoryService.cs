using TTI.Application.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TTI.Application.Interface
{
    public interface ISubCategoryService
    {
        Task<bool> AddAsync(SubCategoryPostDto subCategoryDto);
        Task<bool> EditAsync(SubCategoryPostDto subCategoryDto);
        Task<bool> DeleteAsync(int id);
        Task<SubCategoryGetDto> GetById(int id);
        Task<IEnumerable<SubCategoryGetDto>> Filter();
    }
}
