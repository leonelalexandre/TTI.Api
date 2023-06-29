using TTI.Application.Dto;
using TTI.Application.Interface;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.IO;
using Microsoft.AspNetCore.Http;
using System;
using System.Net.Http.Headers;

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
                return Ok(dto);
            else
                return BadRequest("Ocorreu um erro ao salvar");
        }

        [HttpPost]
        [Route("UploadImage")]
        public async Task<ActionResult> UploadImage()
        {
            byte[] image = null;
            var httpRequest = HttpContext.Request;

            var file = httpRequest.Form.Files[0];


                MemoryStream ms = new MemoryStream();
                file.CopyTo(ms);

                image = ms.ToArray();

            string imageBase64Data = Convert.ToBase64String(image);
            string urlImage = string.Format("data:image/jpg;base64,{0}", imageBase64Data);

            if (image != null)
                return Ok(urlImage);
            else
                return BadRequest("Ocorreu um erro ao carregar a imagem");
        }


        [HttpGet]
        [Route("RestoreImage/{id:int}")]
        public async Task<ActionResult> RestoreImage(int id)
        {
            var dto = await _productService.GetById(id);

            string imageBase64Data = Convert.ToBase64String(dto.Photo);

            string imageDataURL =
                    string.Format("data:image/jpg;base64,{0}", imageBase64Data);

            if (imageDataURL != null)
                return Ok(imageDataURL);
            else
                return BadRequest("Ocorreu um erro ao carregar a imagem");
        }

        [HttpPut]
        [Route("Edit")]
        public async Task<ActionResult> Edit(ProductPostDto dto)
        {
            var save = await _productService.EditAsync(dto);
            if (save)
                return Ok(dto);
            else
                return BadRequest("Ocorreu um erro ao salvar");
        }

        [HttpDelete]
        [Route("Delete/{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var save = await _productService.DeleteAsync(id);
            if (save)
                return Ok(id);
            else
                return BadRequest("Ocorreu um erro ao salvar");
        }

        [HttpGet]
        [Route("GetById/{id:int}")]
        public async Task<ActionResult> GetById(int id)
        {
            var dto = await _productService.GetById(id);

            string imageBase64Data = Convert.ToBase64String(dto.Photo);

            dto.ImageSelected =
                    string.Format("data:image/jpg;base64,{0}", imageBase64Data);

            if (dto == null)
                return NotFound();

            return Ok(dto);
        }

        [HttpGet]
        [Route("GetByKeyword/{keyword}")]
        public async Task<ActionResult<IEnumerable<ProductGetDto>>> GetByKeyword(string keyword)
        {
            if (string.IsNullOrEmpty(keyword))
                keyword = null;

            var dto = await _productService.GetByKeyword(keyword);

            return Ok(dto);
        }
    }
}
