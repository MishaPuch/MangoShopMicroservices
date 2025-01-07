using AutoMapper;
using MangoShopUserService.Model;
using MangoShopUserService.Model.ApiRequest;
using MangoShopUserService.Service;
using Microsoft.AspNetCore.Mvc;

namespace MangoShopUserService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly UserService _userService;
        private readonly IMapper _mapper;

        public UserController(UserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

        [HttpGet("users")]
        public async Task<IActionResult> GetAllUsers()
        {
            return Ok(await _userService.GetAllUsersAsync());
        }

        [HttpGet("user/{id}")]
        public async Task<IActionResult> GetUserById(int id)
        {
            return Ok(await _userService.GetUsersByIdAsync(id));
        }

        [HttpGet("user/{email}/{password}")]
        public async Task<IActionResult> GetLoginUser(string email, string password)
        {
            return Ok(await _userService.GetLoginUser(email, password));
        }

        [HttpPost("user")]
        public async Task<IActionResult> PostUsers([FromBody] UserApiRequest user)
        {
            var mappedUser = _mapper.Map<User>(user);
            var userCreated = await _userService.CreateUser(mappedUser);
            if (userCreated)
                return Ok();
            else
                return BadRequest();
        }

        [HttpPut("user")]
        public async Task<IActionResult> PutUsers(User user)
        {
            var userUpdated = await _userService.UpdateUser(user);
            if (userUpdated)
                return Ok();
            else
                return BadRequest();
        }

        [HttpDelete("user/{id}")]
        public async Task<IActionResult> DeleteUserById(int id)
        {
            var user = await _userService.GetUsersByIdAsync(id);
            var userDeleted = await _userService.DeleteUser(user);
            if (userDeleted)
                return Ok();
            else
                return BadRequest();
        }


    }
}
