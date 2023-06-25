using AutoMapper;
using TTI.Application.Dto;
using TTI.Application.Interface;
using TTI.Domain.Entity;
using TTI.Domain.Interface;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TTI.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;
        public ProductService(IProductRepository productRepository, ICategoryService categoryService , IMapper mapper)
        {
            _productRepository = productRepository;
            _categoryService = categoryService;            
            _mapper = mapper;
        }
        public async Task<bool> AddAsync(ProductPostDto dto)
        {
            var product = _mapper.Map<ProductPostDto, Product>(dto);
            await _productRepository.AddAsync(product);

            return await _productRepository.SaveAllAsync();
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var product = await _productRepository.GetById(id);
            if (product == null)
                return false;

            await _productRepository.DeleteAsync(product);

            return await _productRepository.SaveAllAsync();
        }

        public async Task<bool> EditAsync(ProductPostDto dto)
        {
            var product = _mapper.Map<ProductPostDto, Product>(dto);
            await _productRepository.EditAsync(product);

            return await _productRepository.SaveAllAsync();
        }

        public async Task<IEnumerable<ProductGetDto>> Filter()
        {
            var entity = await _productRepository.Filter();
            var dto = _mapper.Map<IEnumerable<Product>, IEnumerable<ProductGetDto>>(entity);

            return dto;
        }

        public async Task<ProductGetDto> GetById(int id)
        {
            var entity = await _productRepository.GetById(id);
            var dto = _mapper.Map<Product, ProductGetDto>(entity);

            return dto;
        }

        public async Task<IEnumerable<ProductGetDto>> GetByKeyword(string keyword)
        {
            var lstEntity = await _productRepository.GetByKeyword(keyword);

            foreach (var entity in lstEntity)
            {
                var dtoCategory = await _categoryService.GetById(entity.IdCategory);
                entity.IdCategoriesNavigation = _mapper.Map<CategoryGetDto, Category>(dtoCategory);
            }


            var lstDto = _mapper.Map<IEnumerable<Product>, IEnumerable<ProductGetDto>>(lstEntity);

            return lstDto;
        }
    }
}
