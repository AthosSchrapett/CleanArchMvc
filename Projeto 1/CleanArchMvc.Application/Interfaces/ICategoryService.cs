﻿using CleanArchMvc.Application.DTOs;
using CleanArchMvc.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CleanArchMvc.Application.Interfaces
{
    public interface ICategoryService
    {
        Task<IEnumerable<CategoryDTO>> GetCategoriesAsync();
        Task<CategoryDTO> GetByIdAsync(int? id);
        Task AddAsync(CategoryDTO categoryDTO);
        Task UpdateAsync(CategoryDTO categoryDTO);
        Task DeleteAsync(int? id);
    }
}
