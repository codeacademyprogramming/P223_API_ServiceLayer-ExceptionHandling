using Shop.Service.DTOs;
using Shop.Service.DTOs.CategoryDtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Service.Interfaces
{
    public interface ICategoryService
    {
        Task<CategoryGetDto> CreateAsync(CategoryPostDto postDto);
        Task UpdateAsync(int id,CategoryPostDto postDto);
        Task<CategoryGetDto> GetByIdAsync(int id);
        Task<PaginatedListDto<CategoryListItemDto>> GetAll(int pageIndex);
        Task DeleteAsync(int id);
    }
}
