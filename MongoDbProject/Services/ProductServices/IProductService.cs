﻿using MongoDbProject.Dtos.ProductDtos;
using MongoDbProject.Entities;

namespace MongoDbProject.Services.ProductServices
{
    public interface IProductService
    {
        Task<List<ResultProductDto>> GetAllProductAsync();
        Task<List<ResultProductDto>> SearchProductsAsync(string query);
        Task CreateProductAsync(CreateProductDto createProductDto);
        Task UpdateProductAsync(UpdateProductDto updateProductDto);
        Task DeleteProductAsync(string id);
        Task<GetByIdProductDto> GetByIdProductAsync(string id);
		Task<List<ResultProductWithCategoryDto>> GetAllProductWithCategoryAsync();
		Task<List<ResultProductWithCategoryDto>> GetLast10ProductWithCategoryAsync();
		Task<List<ResultProductWithCategoryDto>> GetAllProductWithCategoryByCategoryIdAsync(string id);

	}
}
