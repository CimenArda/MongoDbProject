using AutoMapper;
using MongoDbProject.Dtos.CategoryDtos;
using MongoDbProject.Dtos.DiscountDtos;
using MongoDbProject.Dtos.FeatureDtos;
using MongoDbProject.Dtos.ProductDtos;
using MongoDbProject.Dtos.SellingDtos;
using MongoDbProject.Entities;

namespace MongoDbProject.Mapping
{
    public class GeneralMapping :Profile
    {
        public GeneralMapping()
        {
            CreateMap<Category, ResultCategoryDto>().ReverseMap();
            CreateMap<Category, CreateCategoryDto>().ReverseMap();
            CreateMap<Category, UpdateCategoryDto>().ReverseMap();
            CreateMap<Category, GetByIdCategoryDto>().ReverseMap();

            CreateMap<Product, ResultProductDto>().ReverseMap();
            CreateMap<Product, CreateProductDto>().ReverseMap();
            CreateMap<Product, UpdateProductDto>().ReverseMap();
            CreateMap<Product, GetByIdProductDto>().ReverseMap();


            CreateMap<Feature, ResultFeatureDto>().ReverseMap();
            CreateMap<Feature, CreateFeatureDto>().ReverseMap();
            CreateMap<Feature, UpdateFeatureDto>().ReverseMap();
            CreateMap<Feature, GetByIdFeatureDto>().ReverseMap();


            CreateMap<Discount, ResultDiscountDto>().ReverseMap();
            CreateMap<Discount, CreateDiscountDto>().ReverseMap();
            CreateMap<Discount, UpdateDiscountDto>().ReverseMap();
            CreateMap<Discount, GetByIdDiscountDto>().ReverseMap();


            CreateMap<Selling, ResultSellingDto>().ReverseMap();
            CreateMap<Selling, CreateSellingDto>().ReverseMap();
            CreateMap<Selling, UpdateSellingDto>().ReverseMap();
            CreateMap<Selling, GetByIdSellingDto>().ReverseMap();






        }
    }
}
