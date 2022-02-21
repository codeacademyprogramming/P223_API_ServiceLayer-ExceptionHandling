using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.Service.DTOs.CategoryDtos
{
    public class CategoryPostDto
    {
        public string Name { get; set; }
    }

    public class CategoryPostDtoValidator : AbstractValidator<CategoryPostDto>
    {
        public CategoryPostDtoValidator()
        {
            RuleFor(x => x.Name).NotEmpty().MaximumLength(20);
        }
    }
}
