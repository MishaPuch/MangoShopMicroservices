using AutoMapper;
using MangoShopUserService.Model;
using MangoShopUserService.Model.ApiRequest;

namespace MangoShopUserService
{
    public class ProfileMap : Profile
    {
        public ProfileMap() 
        {
            CreateMap<UserApiRequest, User>();
        }
    }
}
