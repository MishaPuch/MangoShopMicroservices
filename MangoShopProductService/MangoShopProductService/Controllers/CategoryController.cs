using AutoMapper;
using BLL.MangoShopProductService.BlModel;
using BLL.MangoShopProductService.Service;
using MangoShopProductService.ModelDto.ApiRequest;
using MangoShopProductService.ModelDto.ApiResponse;
using Microsoft.AspNetCore.Mvc;

namespace MangoShopProductService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly CategoryService _categoryService;
        private readonly IMapper _mapper;

        public CategoryController(CategoryService categoryService, IMapper mapper)
        {
            _categoryService = categoryService;
            _mapper = mapper;
        }

        [HttpGet("categories")]
        public async Task<IActionResult> GetAllCategories()
        {
            var categoriesBl = await _categoryService.GetAllCategoriesAsync();
            var categoriesDto = _mapper.Map<List<CategoryApiResponse>>(categoriesBl);

            return Ok(categoriesDto);
        }

        [HttpGet("category/{id}")]
        public async Task<IActionResult> GetCategoryById(int id)
        {
            var categoriesBl = await _categoryService.GetCategoryByIdAsync(id);
            var categoriesDto = _mapper.Map<CategoryApiResponse>(categoriesBl);

            return Ok(categoriesDto);
        }

        [HttpPost("category")]
        public async Task<IActionResult> AddCategory([FromBody] CategoryApiRequest categoryRequest)
        {
            var categoryBl = _mapper.Map<CategoryBl>(categoryRequest);
            await _categoryService.AddCategoryAsync(categoryBl);

            return Ok();
        }

        [HttpPut("category/{id}")]
        public async Task<IActionResult> UpdateCategory(int id ,[FromBody] CategoryApiRequest categoryRequest)
        {
            if (categoryRequest.Id == id)
            {
                var categoryBl = _mapper.Map<CategoryBl>(categoryRequest);
                await _categoryService.UpdateCategoryAsync(categoryBl);

                return Ok();
            }
            return BadRequest();
        }

        [HttpDelete("category/{id}")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            await _categoryService.DeleteCategoryAsync(id);

            return Ok();
        }
    }
}
