using AutoMapper;
using MongoDB.Driver;
using MongoDbProject.Dtos.ProductDtos;
using MongoDbProject.Dtos.SellingDtos;
using MongoDbProject.Entities;
using MongoDbProject.Settings;

namespace MongoDbProject.Services.SellingServices
{
    public class SellingService : ISellingService
    {
        private readonly IMongoCollection<Selling> _SellingCollection;
        private readonly IMongoCollection<Product> _ProductCollection;
        private readonly IMapper _mapper;

		public SellingService(IMapper mapper, IDatabaseSettings _databaseSettings)
		{
			var client = new MongoClient(_databaseSettings.ConnectionString);
			var database = client.GetDatabase(_databaseSettings.DatabaseName);
			_SellingCollection = database.GetCollection<Selling>(_databaseSettings.SellingCollectionName);
			_ProductCollection = database.GetCollection<Product>(_databaseSettings.ProductCollectionName);
			_mapper = mapper;
		}

		public async Task CreateSellingAsync(CreateSellingDto createSellingDto)
        {
            var value = _mapper.Map<Selling>(createSellingDto);
            await _SellingCollection.InsertOneAsync(value);
        }

        public async Task DeleteSellingAsync(string id)
        {
            await _SellingCollection.DeleteOneAsync(x => x.SellingID == id);
        }

        public async Task<List<ResultSellingDto>> GetAllSellingAsync()
        {
			var values = await _SellingCollection.Find(x => true).ToListAsync();

			foreach (var item in values)
			{
				item.Product = await _ProductCollection.Find<Product>(x => x.ProductID == item.ProductID).FirstAsync();
			}

			return _mapper.Map<List<ResultSellingDto>>(values);
		}

        public async Task<GetByIdSellingDto> GetByIdSellingAsync(string id)
        {
            var Selling = await _SellingCollection.Find(x => x.SellingID == id).FirstOrDefaultAsync();
            return _mapper.Map<GetByIdSellingDto>(Selling);
        }

        public async Task<List<ResultSellingDto>> GetTop8SellingProductsAsync()
        {
            // Satışları Count değerine göre azalan sırayla alıyoruz
            var values = await _SellingCollection.Find(x => true)
                                                  .SortByDescending(x => x.Count)
                                                  .Limit(8)
                                                  .ToListAsync();

            // Ürün bilgilerini ilişkilendiriyoruz
            foreach (var item in values)
            {
                item.Product = await _ProductCollection.Find<Product>(x => x.ProductID == item.ProductID).FirstOrDefaultAsync();
            }

            // Dönüşü DTO'ya dönüştürüp geri gönderiyoruz
            return _mapper.Map<List<ResultSellingDto>>(values);
        }

        public async Task UpdateSellingAsync(UpdateSellingDto updateSellingDto)
        {
            var value = _mapper.Map<Selling>(updateSellingDto);
            await _SellingCollection.FindOneAndReplaceAsync(x => x.SellingID == updateSellingDto.SellingID, value);
        }
    }
}
