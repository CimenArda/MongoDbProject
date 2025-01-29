﻿using AutoMapper;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using MongoDbProject.Dtos.ProductDtos;
using MongoDbProject.Entities;
using MongoDbProject.Settings;

namespace MongoDbProject.Services.ProductServices
{
    public class ProductService : IProductService
    {
        private readonly IMongoCollection<Product> _ProductCollection;
        private readonly IMongoCollection<Category> _CategoryCollection;
        private readonly IMapper _mapper;

        public ProductService(IMapper mapper, IDatabaseSettings _databaseSettings)
        {
            var client = new MongoClient(_databaseSettings.ConnectionString);
            var database = client.GetDatabase(_databaseSettings.DatabaseName);
            _ProductCollection = database.GetCollection<Product>(_databaseSettings.ProductCollectionName);
			_CategoryCollection = database.GetCollection<Category>(_databaseSettings.CategoryCollectionName);
            _mapper = mapper;
        }

        public async Task CreateProductAsync(CreateProductDto createProductDto)
        {
            var value = _mapper.Map<Product>(createProductDto);
            await _ProductCollection.InsertOneAsync(value);
        }

        public async Task DeleteProductAsync(string id)
        {
            await _ProductCollection.DeleteOneAsync(x => x.ProductID == id);
        }

        public async Task<List<ResultProductDto>> GetAllProductAsync()
        {
            var Product = await _ProductCollection.Find(x => true).ToListAsync();
            return _mapper.Map<List<ResultProductDto>>(Product);
        }

		public async Task<List<ResultProductWithCategoryDto>> GetAllProductWithCategoryAsync()
		{
			var values = await _ProductCollection.Find(x => true).ToListAsync();

			foreach (var item in values)
			{
				item.Category = await _CategoryCollection.Find<Category>(x => x.CategoryID == item.CategoryID).FirstAsync();
			}

			return _mapper.Map<List<ResultProductWithCategoryDto>>(values);
		}

		public async Task<List<ResultProductWithCategoryDto>> GetAllProductWithCategoryByCategoryIdAsync(string id)
		{
			
			var products = await _ProductCollection.Find(product => product.CategoryID == id).ToListAsync();

			foreach (var product in products)
			{
				product.Category = await _CategoryCollection
					.Find<Category>(category => category.CategoryID == product.CategoryID)
					.FirstAsync();
			}

			return _mapper.Map<List<ResultProductWithCategoryDto>>(products);
		}

		public async Task<GetByIdProductDto> GetByIdProductAsync(string id)
        {
            var Product = await _ProductCollection.Find(x => x.ProductID == id).FirstOrDefaultAsync();
            return _mapper.Map<GetByIdProductDto>(Product);
        }

        public async Task<List<ResultProductWithCategoryDto>> GetLast10ProductWithCategoryAsync()
        {
          
            var values = await _ProductCollection
                .Find(x => true)
                .SortByDescending(x => x.ProductID) 
                .Limit(10) 
                .ToListAsync();

         
            foreach (var item in values)
            {
                item.Category = await _CategoryCollection
                    .Find<Category>(x => x.CategoryID == item.CategoryID)
                    .FirstOrDefaultAsync(); 
            }

           
            return _mapper.Map<List<ResultProductWithCategoryDto>>(values);

        }

        public async Task<List<ResultProductDto>> SearchProductsAsync(string query)
        {
            if (string.IsNullOrWhiteSpace(query))
                return new List<ResultProductDto>();
            var products = await _ProductCollection.AsQueryable()
                .Where(product => product.ProductName.ToLower().Contains(query.ToLower()))
                .ToListAsync();
            var result = products.Select(product => new ResultProductDto
            {
                ProductID = product.ProductID,
                ProductName = product.ProductName,
                ProductPrice = product.ProductPrice,
                ProductImageUrl = product.ProductImageUrl,
                CategoryID = product.CategoryID,
            }).ToList();
            return result;
        }

        public async Task UpdateProductAsync(UpdateProductDto updateProductDto)
        {
            var value = _mapper.Map<Product>(updateProductDto);
            await _ProductCollection.FindOneAndReplaceAsync(x => x.ProductID == updateProductDto.ProductID, value);
        }
    }
}
