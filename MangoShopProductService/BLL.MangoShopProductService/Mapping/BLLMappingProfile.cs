using AutoMapper;
using BLL.MangoShopProductService.BlModel;
using DAL.MangoShopProductService.Model;

namespace BLL.MangoShopProductService.Mapping
{
    public class BLLMappingProfile : Profile
    {
        public BLLMappingProfile()
        {
            CreateMap<ProductBl, Product>().ReverseMap();
            CreateMap<CurrencyBl, Currency>().ReverseMap();
            CreateMap<CategoryBl, Category>().ReverseMap();
        }
    }
}
