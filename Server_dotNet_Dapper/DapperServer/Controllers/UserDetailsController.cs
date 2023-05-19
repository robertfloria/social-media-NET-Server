using AutoMapper;
using DapperServer.DataAccessLayer.Interfaces;
using DapperServer.DataAccessLayer.Models;
using DapperServer.ServiceLayer.Authorization;
using DapperServer.ServiceLayer.Interfaces;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace DapperServer.Controllers
{

    [EnableCors("MyAllowSpecificOrigins")]
    [Authorize]
    [ApiController]
    [Route("TableX/[controller]")]
    public class UserDetailsController : ControllerBase
    {
        private IUserDetailsService _userDetailsService;
        private IMapper _mapper;
        private readonly IDbContext _context;

        public UserDetailsController(
            IUserDetailsService userDetailsService,
            IMapper mapper,
            IDbContext context)
        {
            _userDetailsService = userDetailsService;
            _mapper = mapper;
            _context = context;
        }

        [AllowAnonymous]
        [HttpPut("updateUserDetails/{user_id}")]
        public async Task<IActionResult> UpdateUserDetails(int user_id, [FromBody] UserDetails request)
        {
            await _userDetailsService.UpdateUserDetails(user_id, request);
            return Ok(new { message = "Details updated!" });
        }

        [AllowAnonymous]
        [HttpGet("getUserDetails/{user_id}")]
        public async Task<IActionResult> GetUserDetails(int user_id)
        {
            var result = await _userDetailsService.GetUserDetails(user_id);
            return Ok(result);
        }
    }
}
