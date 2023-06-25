using AutoMapper;
using TTI.Application.Dto;
using TTI.Application.Interface;
using TTI.Domain.Entity;
using TTI.Domain.Interface;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TTI.Application.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;
        
        public CategoryService(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }
        public async Task<bool> AddAsync(CategoryPostDto categoryDto)
        {
            var category = _mapper.Map<CategoryPostDto, Category>(categoryDto);
            await _categoryRepository.AddAsync(category);

            return await _categoryRepository.SaveAllAsync();
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var category = await _categoryRepository.GetById(id);
            if (category == null)
                return false;

            await _categoryRepository.DeleteAsync(category);
            return await _categoryRepository.SaveAllAsync(); ;
        }

        public async Task<bool> EditAsync(CategoryPostDto categoryDto)
        {
            var category = _mapper.Map<CategoryPostDto, Category>(categoryDto);
            await _categoryRepository.EditAsync(category);

            return await _categoryRepository.SaveAllAsync();
        }

        public async Task<IEnumerable<CategoryGetDto>> Filter()
        {   
            var category = await _categoryRepository.Filter();
            var dto = _mapper.Map< IEnumerable<Category>, IEnumerable<CategoryGetDto> >(category);

            return dto;
        }

        public async Task<CategoryGetDto> GetById(int id)
        {
            var category = await _categoryRepository.GetById(id);
            var dto = _mapper.Map<Category, CategoryGetDto>(category);

            return dto;
        }

    }
}
