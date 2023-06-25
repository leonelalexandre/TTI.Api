using AutoMapper;
using TTI.Application.Dto;
using TTI.Application.Interface;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TTI.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;
        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        [HttpGet]
        [Route("SelecionarTodos")]
        public async Task<ActionResult<IEnumerable<CategoryGetDto>>> GetCategories()
        {
            var dto = await _categoryService.Filter();

            return Ok(dto);
        }

        [HttpPost]
        [Route("Add")]
        public async Task<ActionResult> Add(CategoryPostDto dto)
        {
            var save = await _categoryService.AddAsync(dto);
            if (save)
                return Ok("Categoria salvo com sucesso!");
            else
                return BadRequest("Ocorreu um erro ao salvar");
        }

        [HttpPut]
        [Route("Edit")]
        public async Task<ActionResult> Edit(CategoryPostDto dto)
        {
           var save = await _categoryService.EditAsync(dto);
            if (save)
                return Ok("Categoria salvo com sucesso!");
            else
                return BadRequest("Ocorreu um erro ao salvar");
        }

        [HttpDelete]
        [Route("Delete/{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var delete = await _categoryService.DeleteAsync(id);
            if (delete)
                return Ok("Categoria Detelatada com sucesso!");
            else
                return BadRequest("Ocorreu um erro ao deletar");
        }

        [HttpGet]
        [Route("GetById/{id:int}")]
        public async Task<ActionResult> GetById(int id)
        {
            var category = await _categoryService.GetById(id);
            if (category == null)
                return NotFound();

            return Ok(category);
        }
    }
}
