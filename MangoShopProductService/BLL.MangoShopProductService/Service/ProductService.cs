using AutoMapper;
using BLL.MangoShopProductService.BlModel;
using DAL.MangoShopProductService.Model;
using DAL.MangoShopProductService.Repository;

namespace BLL.MangoShopProductService.Service
{
    public class ProductService
    {
        private readonly ProductRepository _productRepository;
        private readonly CategoryService _categoryService;
        private readonly CurrencyService _currencyService;
        private readonly IMapper _mapper;

        public ProductService(ProductRepository productRepository, CategoryService categoryService, CurrencyService currencyService, IMapper mapper)
        {
            _productRepository = productRepository;
            _categoryService = categoryService;
            _currencyService = currencyService;
            _mapper = mapper;
        }

        public async Task<List<ProductBl>> GetAllProductsAsync()
        {
            var products = await _productRepository.GetAllProductsAsync();
            return _mapper.Map<List<ProductBl>>(products);
        }

        public async Task<ProductBl?> GetProductByIdAsync(int id)
        {
            var product = await _productRepository.GetProductByIdAsync(id);
            return _mapper.Map<ProductBl>(product);
        }

        public async Task AddProductAsync(ProductBl productBl)
        {
            var product = _mapper.Map<Product>(productBl);
            await _productRepository.AddProductAsync(product);
        }

        public async Task UpdateProductAsync(ProductBl productBl)
        {
            var product = _mapper.Map<Product>(productBl);
            await _productRepository.UpdateProductAsync(product);
        }

        public async Task DeleteProductAsync(int id)
        {
            await _productRepository.DeleteProductAsync(id);
        }
    }
}
