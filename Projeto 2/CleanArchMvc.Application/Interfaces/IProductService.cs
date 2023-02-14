﻿using CleanArchMvc.Application.DTOs;

namespace CleanArchMvc.Application.Interfaces;

public interface IProductService
{
    Task<IEnumerable<ProductDTO>> GetProductsAsync();
    Task<ProductDTO> GetByIdAsync(int? id);
    Task AddAsync(ProductDTO productDTO);
    Task UpdateAsync(ProductDTO productDTO);
    Task RemoveAsync(int? id);
}
