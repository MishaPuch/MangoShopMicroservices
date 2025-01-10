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
            CreateMap<ProductApiRequest, WorehouseApiRequest>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.ProductId, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.GeneralProductName, opt => opt.MapFrom(src => src.GeneralProductName))
                .ForMember(dest => dest.ProductQuantity, opt => opt.MapFrom(src => src.ProductQuantity));


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
