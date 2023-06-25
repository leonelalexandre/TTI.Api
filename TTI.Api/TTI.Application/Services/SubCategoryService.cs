using AutoMapper;
using TTI.Application.Dto;
using TTI.Application.Interface;
using TTI.Domain.Entity;
using TTI.Domain.Interface;
using System.Collections.Generic;
using System.Threading.Tasks;
using TTI.Application.Interface;

namespace TTI.Application.Services
{
    public class SubCategoryService : ISubCategoryService
    {
        private readonly ISubCategoryRepository _subCategoryRepository;
        private readonly IMapper _mapper;
        
        public SubCategoryService(ISubCategoryRepository subCategoryRepository, IMapper mapper)
        {
            _subCategoryRepository = subCategoryRepository;
            _mapper = mapper;
        }
        public async Task<bool> AddAsync(SubCategoryPostDto subCategoryDto)
        {
            var subCategory = _mapper.Map<SubCategoryPostDto, SubCategory>(subCategoryDto);
            await _subCategoryRepository.AddAsync(subCategory);

            return await _subCategoryRepository.SaveAllAsync();
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var subCategory = await _subCategoryRepository.GetById(id);
            if (subCategory == null)
                return false;

            await _subCategoryRepository.DeleteAsync(subCategory);
            return await _subCategoryRepository.SaveAllAsync(); ;
        }

        public async Task<bool> EditAsync(SubCategoryPostDto categoryDto)
        {
            var subCategory = _mapper.Map<SubCategoryPostDto, SubCategory>(categoryDto);
            await _subCategoryRepository.EditAsync(subCategory);

            return await _subCategoryRepository.SaveAllAsync();
        }

        public async Task<IEnumerable<SubCategoryGetDto>> Filter()
        {   
            var subCategory = await _subCategoryRepository.Filter();
            var dto = _mapper.Map< IEnumerable<SubCategory>, IEnumerable<SubCategoryGetDto> >(subCategory);

            return dto;
        }

        public async Task<SubCategoryGetDto> GetById(int id)
        {
            var subCategory = await _subCategoryRepository.GetById(id);
            var dto = _mapper.Map<SubCategory, SubCategoryGetDto>(subCategory);

            return dto;
        }
    }
}
