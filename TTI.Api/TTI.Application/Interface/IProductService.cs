using TTI.Application.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TTI.Application.Interface
{
    public interface IProductService
    {
        Task<bool> AddAsync(ProductPostDto product);
        Task <bool> EditAsync(ProductPostDto product);
        Task<bool> DeleteAsync(int id);
        Task<ProductGetDto> GetById(int id);
        Task<IEnumerable<ProductGetDto>> Filter();
        Task<IEnumerable<ProductGetDto>> GetByKeyword(string keyword);
    }
}
