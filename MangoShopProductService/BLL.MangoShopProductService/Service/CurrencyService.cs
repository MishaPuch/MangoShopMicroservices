using AutoMapper;
using BLL.MangoShopProductService.BlModel;
using DAL.MangoShopProductService.Repository;

namespace BLL.MangoShopProductService.Service
{
    public class CurrencyService
    {
        private readonly CurrencyRepository _currencyRepository;
        private readonly IMapper _mapper;

        public CurrencyService(CurrencyRepository currencyRepository, IMapper mapper)
        {
            _currencyRepository = currencyRepository;
            _mapper = mapper;
        }

        public async Task<List<CurrencyBl>> GetAllCurrenciesAsync()
        {
            var currencies = await _currencyRepository.GetAllCurrenciesAsync();
            return _mapper.Map<List<CurrencyBl>>(currencies);
        }

        public async Task<CurrencyBl?> GetCurrencyByIdAsync(int id)
        {
            var currency = await _currencyRepository.GetCurrencyByIdAsync(id);
            return _mapper.Map<CurrencyBl>(currency);
        }
    }
}
