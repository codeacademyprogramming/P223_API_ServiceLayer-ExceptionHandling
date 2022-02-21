using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shop.Core.Entities;
using Shop.Core.Repositories;
using Shop.Service.DTOs.CategoryDtos;
using Shop.Service.Exceptions;
using Shop.Service.Implementations;
using Shop.Service.Interfaces;
using System.Net.Http;
using System.Threading.Tasks;

namespace Shop.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            MultipartContent content = new MultipartContent();
            content.Add("fd", "fd");
            _categoryService = categoryService;
        }

        [HttpPost("")]
        public async Task<IActionResult> Create(CategoryPostDto postDto)
        {
            var response = await _categoryService.CreateAsync(postDto);
            return StatusCode(201, response);
        }    

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await _categoryService.GetByIdAsync(id));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, CategoryPostDto postDto)
        {
            await _categoryService.UpdateAsync(id, postDto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _categoryService.DeleteAsync(id);
            return NoContent();
        }

        [HttpGet("")]
        public async Task<IActionResult> GetAll(int pageIndex=1)
        {
            return Ok(await _categoryService.GetAll(pageIndex));
        }
    }
}
