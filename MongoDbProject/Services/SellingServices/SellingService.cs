using AutoMapper;
using MongoDB.Driver;
using MongoDbProject.Dtos.SellingDtos;
using MongoDbProject.Entities;
using MongoDbProject.Settings;

namespace MongoDbProject.Services.SellingServices
{
    public class SellingService : ISellingService
    {
        private readonly IMongoCollection<Selling> _SellingCollection;
        private readonly IMapper _mapper;

        public SellingService(IMapper mapper, IDatabaseSettings _databaseSettings)
        {
            var client = new MongoClient(_databaseSettings.ConnectionString);
            var database = client.GetDatabase(_databaseSettings.DatabaseName);
            _SellingCollection = database.GetCollection<Selling>(_databaseSettings.SellingCollectionName);
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
            var Selling = await _SellingCollection.Find(x => true).ToListAsync();
            return _mapper.Map<List<ResultSellingDto>>(Selling);
        }

        public async Task<GetByIdSellingDto> GetByIdSellingAsync(string id)
        {
            var Selling = await _SellingCollection.Find(x => x.SellingID == id).FirstOrDefaultAsync();
            return _mapper.Map<GetByIdSellingDto>(Selling);
        }

        public async Task UpdateSellingAsync(UpdateSellingDto updateSellingDto)
        {
            var value = _mapper.Map<Selling>(updateSellingDto);
            await _SellingCollection.FindOneAndReplaceAsync(x => x.SellingID == updateSellingDto.SellingID, value);
        }
    }
}
