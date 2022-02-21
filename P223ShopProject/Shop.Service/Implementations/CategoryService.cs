using AutoMapper;
using Shop.Core;
using Shop.Core.Entities;
using Shop.Core.Repositories;
using Shop.Service.DTOs;
using Shop.Service.DTOs.CategoryDtos;
using Shop.Service.Exceptions;
using Shop.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Service.Implementations
{
    public class CategoryService : ICategoryService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CategoryService(IUnitOfWork unitOfWork,IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<CategoryGetDto> CreateAsync(CategoryPostDto postDto)
        {

            if (await _unitOfWork.CategoryRepository.IsExistAsync(x => x.Name.ToUpper() == postDto.Name.ToUpper()))
                throw new RecordDuplicateException("Category already exists with name " + postDto.Name);

            Category category = _mapper.Map<Category>(postDto);

            await _unitOfWork.CategoryRepository.AddAsync(category);
            await _unitOfWork.CategoryRepository.CommitAsync();

            CategoryGetDto categoryGetDto = _mapper.Map<CategoryGetDto>(category);

            return categoryGetDto;
        }

        public async Task DeleteAsync(int id)
        {
            Category category = await _unitOfWork.CategoryRepository.GetAsync(x => x.Id == id && !x.IsDeleted);

            if (category == null)
                throw new ItemNotFoundException("Item not found by id (" + id + ")");

            category.IsDeleted = true;
            await _unitOfWork.CategoryRepository.CommitAsync();
        }

        public async Task<PaginatedListDto<CategoryListItemDto>> GetAll(int pageIndex)
        {
            if (pageIndex < 1)
                throw new PageIndexIncorrectException("PageIndex must be larger than 0");

            string pageSizeStr = await _unitOfWork.SettingRepository.GetValue("PageSize");

            int pageSize = int.Parse(pageSizeStr);

            var query =  _unitOfWork.CategoryRepository.GetAll(x => !x.IsDeleted);
            var items = query.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();


            var listDto = new PaginatedListDto<CategoryListItemDto>(_mapper.Map<List<CategoryListItemDto>>(items), query.Count(), pageSize, pageIndex);

            return listDto;
        }

        public async Task<CategoryGetDto> GetByIdAsync(int id)
        {
            Category category = await _unitOfWork.CategoryRepository.GetAsync(x => x.Id == id && !x.IsDeleted);

            if (category == null)
                throw new ItemNotFoundException("Item not found by id ("+id+")");

            CategoryGetDto categoryGetDto = _mapper.Map<CategoryGetDto>(category);

            return categoryGetDto;
        }

        public async Task UpdateAsync(int id, CategoryPostDto postDto)
        {
            Category category = await _unitOfWork.CategoryRepository.GetAsync(x => x.Id == id && !x.IsDeleted);

            if (category == null)
                throw new ItemNotFoundException("Item not found by id (" + id + ")");

            if (await _unitOfWork.CategoryRepository.IsExistAsync(x => x.Id != id && x.Name.ToUpper() == postDto.Name.ToUpper()))
                throw new RecordDuplicateException("Category already exists with name " + postDto.Name);

            category.Name = postDto.Name;
            await _unitOfWork.CategoryRepository.CommitAsync();
        }
    }
}
