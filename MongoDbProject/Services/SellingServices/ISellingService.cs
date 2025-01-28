using MongoDbProject.Dtos.SellingDtos;

namespace MongoDbProject.Services.SellingServices
{
    public interface ISellingService
    {
        Task<List<ResultSellingDto>> GetAllSellingAsync();
        Task<List<ResultSellingDto>> GetTop8SellingProductsAsync();
        Task CreateSellingAsync(CreateSellingDto createSellingDto);
        Task UpdateSellingAsync(UpdateSellingDto updateSellingDto);
        Task DeleteSellingAsync(string id);
        Task<GetByIdSellingDto> GetByIdSellingAsync(string id);
    }
}
