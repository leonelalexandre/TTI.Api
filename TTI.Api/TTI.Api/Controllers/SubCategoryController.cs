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
    public class SubCategoryController : Controller
    {
        private readonly ISubCategoryService _subCategoryService;
        private readonly IMapper _mapper;
        public SubCategoryController(ISubCategoryService subCategoryService)
        {
            _subCategoryService = subCategoryService;
        }
        [HttpGet]
        [Route("GetByAll")]
        public async Task<ActionResult<IEnumerable<SubCategoryGetDto>>> GetSubCategories()
        {
            var dto = await _subCategoryService.Filter();

            return Ok(dto);
        }

        [HttpPost]
        [Route("Add")]
        public async Task<ActionResult> Add(SubCategoryPostDto dto)
        {
            var save = await _subCategoryService.AddAsync(dto);
            if (save)
                return Ok(dto);
            else
                return BadRequest("Ocorreu um erro ao salvar");
        }

        [HttpPut]
        [Route("Edit")]
        public async Task<ActionResult> Edit(SubCategoryPostDto dto)
        {
           var save = await _subCategoryService.EditAsync(dto);
            if (save)
                return Ok(dto);
            else
                return BadRequest("Ocorreu um erro ao salvar");
        }

        [HttpDelete]
        [Route("Delete/{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var delete = await _subCategoryService.DeleteAsync(id);
            if (delete)
                return Ok(id);
            else
                return BadRequest("Ocorreu um erro ao deletar");
        }

        [HttpGet]
        [Route("GetById/{id:int}")]
        public async Task<ActionResult> GetById(int id)
        {
            var category = await _subCategoryService.GetById(id);
            if (category == null)
                return NotFound();

            return Ok(category);
        }
    }
}
