using AutoMapper;
using Zamazon.Catalog.Dtos.CategoryDtos;
using Zamazon.Catalog.Dtos.ProductDetailDtos;
using Zamazon.Catalog.Dtos.ProductDtos;
using Zamazon.Catalog.Dtos.ProductImageDtos;
using Zamazon.Catalog.Dtos.SpecialOfferDtos;
using Zamazon.Catalog.Entities;

namespace Zamazon.Catalog.Mapping
{
    public class GeneralMapping : Profile
    {
        public GeneralMapping()
        {
            CreateMap<Category, ResultCategoryDto>().ReverseMap();
            CreateMap<Category, CreateCategoryDto>().ReverseMap();
            CreateMap<Category, GetByIdCategoryDto>().ReverseMap();
            CreateMap<Category, UpdateCategoryDto>().ReverseMap();

            CreateMap<Product, ResultProductDto>().ReverseMap();
            CreateMap<Product, CreateProductDto>().ReverseMap();
            CreateMap<Product, GetByIdProductDto>().ReverseMap();
            CreateMap<Product, UpdateProductDto>().ReverseMap();

            CreateMap<ProductImage, ResultProductImageDto>().ReverseMap();
            CreateMap<ProductImage, CreateProductImageDto>().ReverseMap();
            CreateMap<ProductImage, GetByIdProductImageDto>().ReverseMap();
            CreateMap<ProductImage, UpdateProductImageDto>().ReverseMap();

            CreateMap<ProductDetail, ResultProductDetailDto>().ReverseMap();
            CreateMap<ProductDetail, CreateProductDetailDto>().ReverseMap();
            CreateMap<ProductDetail, GetByIdProductDetailDto>().ReverseMap();
            CreateMap<ProductDetail, UpdateProductDetailDto>().ReverseMap();

			CreateMap<SpecialOffer, ResultSpecialOfferDto>().ReverseMap();
			CreateMap<SpecialOffer, CreateSpecialOfferDto>().ReverseMap();
			CreateMap<SpecialOffer, GetByIdSpecialOfferDto>().ReverseMap();
			CreateMap<SpecialOffer, UpdateSpecialOfferDto>().ReverseMap();

			CreateMap<Product,ResultProductWithCategoryDto>().ReverseMap();

        }
    }
}
