using MangoShopUserService.Service;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MangoShopUserService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PermissionController : ControllerBase
    {
        private readonly PermissionService _permissionService;
        public PermissionController(PermissionService permissionService)
        {
            _permissionService = permissionService;
        }

        // GET: api/<PermissionController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _permissionService.GetAllPermissionsAsync());
        }

        // GET api/<PermissionController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await _permissionService.GetPermissionByIdAsync(id));
        }
    }
}
