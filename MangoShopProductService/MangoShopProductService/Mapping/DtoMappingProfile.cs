using AutoMapper;
using BLL.MangoShopProductService.BlModel;
using MangoShopProductService.ModelDto.ApiRequest;
using MangoShopProductService.ModelDto.ApiResponse;

namespace MangoShopProductService.Mapping
{
    public class DtoMappingProfile : Profile
    {
        public DtoMappingProfile()
        {
            CreateMap<ProductBl, ProductApiRequest>();
            CreateMap<ProductBl, ProductApiResponse>();
            CreateMap<ProductApiRequest, ProductBl>();


            CreateMap<CurrencyBl, CurrencyApiRequest>();
            CreateMap<CurrencyApiResponse, CurrencyBl>();
            CreateMap<CurrencyBl, CurrencyApiResponse>();

            CreateMap<CategoryBl, CategoryApiRequest>();
            CreateMap<CategoryApiRequest, CategoryBl>();

            CreateMap<CategoryApiResponse, CategoryBl>();
            CreateMap<CategoryBl, CategoryApiResponse>();
        }
    }
}
