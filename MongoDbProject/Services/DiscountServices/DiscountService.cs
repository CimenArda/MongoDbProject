using AutoMapper;
using MongoDB.Driver;
using MongoDbProject.Dtos.DiscountDtos;
using MongoDbProject.Entities;
using MongoDbProject.Settings;

namespace MongoDbProject.Services.DiscountServices
{
    public class DiscountService : IDiscountService
    {
        private readonly IMongoCollection<Discount> _DiscountCollection;
        private readonly IMapper _mapper;

        public DiscountService(IMapper mapper, IDatabaseSettings _databaseSettings)
        {
            var client = new MongoClient(_databaseSettings.ConnectionString);
            var database = client.GetDatabase(_databaseSettings.DatabaseName);
            _DiscountCollection = database.GetCollection<Discount>(_databaseSettings.DiscountCollectionName);
            _mapper = mapper;
        }

        public async Task CreateDiscountAsync(CreateDiscountDto createDiscountDto)
        {
            var value = _mapper.Map<Discount>(createDiscountDto);
            await _DiscountCollection.InsertOneAsync(value);
        }

        public async Task DeleteDiscountAsync(string id)
        {
            await _DiscountCollection.DeleteOneAsync(x => x.DiscountID == id);
        }

        public async Task<List<ResultDiscountDto>> GetAllDiscountAsync()
        {
            var Discount = await _DiscountCollection.Find(x => true).ToListAsync();
            return _mapper.Map<List<ResultDiscountDto>>(Discount);
        }

        public async Task<GetByIdDiscountDto> GetByIdDiscountAsync(string id)
        {
            var Discount = await _DiscountCollection.Find(x => x.DiscountID == id).FirstOrDefaultAsync();
            return _mapper.Map<GetByIdDiscountDto>(Discount);
        }

        public async Task UpdateDiscountAsync(UpdateDiscountDto updateDiscountDto)
        {
            var value = _mapper.Map<Discount>(updateDiscountDto);
            await _DiscountCollection.FindOneAndReplaceAsync(x => x.DiscountID == updateDiscountDto.DiscountID, value);
        }
    }
}
