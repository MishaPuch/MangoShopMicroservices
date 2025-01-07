using AutoMapper;
using BLL.MangoShopProductService.Service;
using MangoShopProductService.ModelDto.ApiRequest;
using MangoShopProductService.ModelDto.ApiResponse;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text.Json;


namespace MangoShopProductService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CurrencyController : ControllerBase
    {
        private readonly CurrencyService _currencyService;
        private readonly IMapper _mapper;

        public CurrencyController(CurrencyService currencyService, IMapper mapper)
        {
            _currencyService = currencyService;
            _mapper = mapper;
        }

        [HttpGet("currencies")]
        public async Task<IActionResult> GetAllCurrencies()
        {
            var currenciesBl = await _currencyService.GetAllCurrenciesAsync();
            var currenciesDto = _mapper.Map<List<CurrencyApiResponse>>(currenciesBl);
            var currencyValueDict = await GetCurrencyCoefficent();
            foreach (var currency in currenciesDto)
            {
                if (currency.Name != "USD")
                {
                    currencyValueDict.TryGetValue(currency.Name, out var currencyValue);
                    currency.CoefficentForCurrency = Convert.ToDecimal(currencyValue);
                }
                else
                    currency.CoefficentForCurrency = 1;
            }
            return Ok(currenciesDto);
        }

        [HttpGet("currency/{id}")]
        public async Task<IActionResult> GetCurrencyById(int id)
        {
            var currenciesBl = await _currencyService.GetCurrencyByIdAsync(id);
            var currenciesDto = _mapper.Map<CurrencyApiResponse>(currenciesBl);

            var currencyValueDict = await GetCurrencyCoefficent();

            if (currenciesDto.Name != "USD")
            {
                currencyValueDict.TryGetValue(currenciesDto.Name, out var currencyValue);
                currenciesDto.CoefficentForCurrency = Convert.ToDecimal(currencyValue);
            }
            else
                currenciesDto.CoefficentForCurrency = 1;
            
            return Ok(currenciesDto);
        }

        private async Task<Dictionary<string, decimal>> GetCurrencyCoefficent()
        {
            var reqUrl = "https://api.freecurrencyapi.com/v1/latest?apikey=fca_live_C7rvLT5ttIZmWCesPhgwaegCcqGVMj1TJd1DlVlE&currencies=EUR%2CPLN";
            var client = new HttpClient();

            var prodResp = await client.GetAsync(reqUrl);
            if (!prodResp.IsSuccessStatusCode)
            {
                throw new Exception("request error.");
            }

            var responseContent = await prodResp.Content.ReadAsStringAsync();

            var jsonResponse = JsonConvert.DeserializeObject<CurrencyValueApiResponse>(responseContent);
            if (jsonResponse?.Data != null)
            {
                return jsonResponse.Data;
            }
            else
            {
                throw new Exception("Ошибка десериализации JSON.");
            }
        }
    }
}
