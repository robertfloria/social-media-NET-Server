using AutoMapper;
using DapperServer.DataAccessLayer.Interfaces;
using DapperServer.DataAccessLayer.Models;
using DapperServer.ServiceLayer.Authorization;
using DapperServer.ServiceLayer.Interfaces;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace DapperServer.Controllers
{

    [EnableCors("MyAllowSpecificOrigins")]
    [Authorize]
    [ApiController]
    [Route("TableX/[controller]")]
    public class UsersController : ControllerBase
    {
        private IUserService _userService;
        private IMapper _mapper;
        private readonly IDbContext _context;

        public UsersController(
            IUserService userService,
            IMapper mapper,
            IDbContext context)
        {
            _userService = userService;
            _mapper = mapper;
            _context = context;
        }

        [AllowAnonymous]
        [HttpPost("authenticate")]
        public async Task<IActionResult> Authenticate(AuthenticateRequest model)
        {
            var response = await _userService.Authenticate(model);
            return Ok(response);
        }

        [AllowAnonymous]
        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterRequest model)
        {
            await _userService.Register(model);
            return Ok(new { message = "Registration successful" });
        }

        [AllowAnonymous]
        [HttpGet("getUserById/{id}")]
        public async Task<IActionResult> GetUserById(int id)
        {
            var user = await _context.UserRepository.GetUserById(id);
            return Ok(user);
        }

        [AllowAnonymous]
        [HttpGet("getUserByUsername/{username}")]
        public async Task<IActionResult> GetByUsername(string username)
        {
            var user = await _context.UserRepository.GetUserByUsername(username);
            return Ok(user);
        }

        [AllowAnonymous]
        [HttpGet("getSearchUsers/{username}")]
        public async Task<IActionResult> GetSearchUsers(string username)
        {
            var user = await _userService.SearchUsers(username);
           return Ok(user);
        }

        [AllowAnonymous]
        [HttpGet("getAllUsers")]
        public async Task<IActionResult> GetAllUsers()
        {
            var user = await _userService.GetAllUsers();
            return Ok(user);
        }

        [AllowAnonymous]
        [HttpPut("updateUsername/{id}")]
        public async Task<IActionResult> UpdateUsername(int id, [FromBody] UpdateUsernameRequest model)
        {
            await _userService.UpdateUsername(id, model);
            return Ok("Username updated successfully");
        }

        [AllowAnonymous]
        [HttpPut("updatePassword/{id}")]
        public async Task<IActionResult> UpdatePassword(int id, [FromBody] UpdatePasswordRequest model)
        {
            await _userService.UpdatePassword(id, model);
            return Ok("Password updated successfully");
        }

        [AllowAnonymous]
        [HttpPut("updateEmail/{id}")]
        public async Task<IActionResult> UpdateEmail(int id, [FromBody] UpdateEmailRequest model)
        {
            await _userService.UpdateEmail(id, model);
            return Ok("Email updated successfully");
        }

        [AllowAnonymous]
        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _userService.Delete(id);
            return Ok(new { message = "User deleted successfully" });
        }
    }
}
