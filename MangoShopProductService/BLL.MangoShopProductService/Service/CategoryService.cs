using AutoMapper;
using BLL.MangoShopProductService.BlModel;
using DAL.MangoShopProductService.Repository;
using DAL.MangoShopProductService.Model;

namespace BLL.MangoShopProductService.Service
{
    public class CategoryService
    {
        private readonly CategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public CategoryService(CategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<List<CategoryBl>> GetAllCategoriesAsync()
        {
            var categories = await _categoryRepository.GetAllCategoriesAsync();
            return _mapper.Map<List<CategoryBl>>(categories);
        }

        public async Task<CategoryBl?> GetCategoryByIdAsync(int id)
        {
            var category = await _categoryRepository.GetCategoryByIdAsync(id);
            return _mapper.Map<CategoryBl>(category);
        }

        public async Task AddCategoryAsync(CategoryBl categoryBl)
        {
            // Map BLL model to DAL model
            var category = _mapper.Map<Category>(categoryBl);
            await _categoryRepository.AddCategoryAsync(category);
        }

        public async Task UpdateCategoryAsync(CategoryBl categoryBl)
        {
            // Map BLL model to DAL model
            var category = _mapper.Map<Category>(categoryBl);
            await _categoryRepository.UpdateCategoryAsync(category);
        }

        public async Task DeleteCategoryAsync(int id)
        {
            // Optionally check if category exists
            var categoryExists = await _categoryRepository.GetCategoryByIdAsync(id);
            if (categoryExists != null)
            {
                await _categoryRepository.DeleteCategoryAsync(id);
            }
            else
            {
                throw new Exception("Category not found.");
            }
        }
    }
}
