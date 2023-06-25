using TTI.Application.Dto;
using TTI.Application.Interface;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TTI.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }
        [HttpGet]
        [Route("GetByAll")]
        public async Task<ActionResult<IEnumerable<ProductGetDto>>> GetCategories()
        {
            var dto = await _productService.Filter();

            return Ok(dto);
        }

        [HttpPost]
        [Route("Add")]
        public async Task<ActionResult> Add(ProductPostDto dto)
        {
            var save = await _productService.AddAsync(dto);
            if (save)
                return Ok("Produto salvo com sucesso!");
            else
                return BadRequest("Ocorreu um erro ao salvar");
        }

        [HttpPut]
        [Route("Edit")]
        public async Task<ActionResult> Edit(ProductPostDto dto)
        {
            var save = await _productService.EditAsync(dto);
            if (save)
                return Ok("Produto salvo com sucesso!");
            else
                return BadRequest("Ocorreu um erro ao salvar");
        }

        [HttpDelete]
        [Route("Delete/{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var save = await _productService.DeleteAsync(id);
            if (save)
                return Ok("Produto deletado com sucesso!");
            else
                return BadRequest("Ocorreu um erro ao salvar");
        }

        [HttpGet]
        [Route("GetById/{id:int}")]
        public async Task<ActionResult> GetById(int id)
        {
            var dto = await _productService.GetById(id);
            if (dto == null)
                return NotFound();

            return Ok(dto);
        }

        [HttpGet]
        [Route("GetByKeyword")]
        public async Task<ActionResult<IEnumerable<ProductGetDto>>> GetByKeyword(string keyword)
        {
            var dto = await _productService.GetByKeyword(keyword);

            return Ok(dto);
        }
    }
}
