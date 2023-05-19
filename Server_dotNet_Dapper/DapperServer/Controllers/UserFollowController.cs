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
    public class UserFollowController : ControllerBase
    {
        private IUserFollowService _userFollowService;
        private IMapper _mapper;
        private readonly IDbContext _context;

        public UserFollowController(
            IUserFollowService userFollowService,
            IMapper mapper,
            IDbContext context)
        {
            _userFollowService = userFollowService;
            _mapper = mapper;
            _context = context;
        }

        [AllowAnonymous]
        [HttpPost("followFriend/{user_id}")]
        public async Task<IActionResult> FollowFriend(int user_id, [FromBody] UserFollowRequest request)
        {
            await _userFollowService.FollowFriend(user_id, request.Friend_id);
            return Ok(new { message = "You are friends now!" });
        }

        [AllowAnonymous]
        [HttpPost("unfollowFriend/{user_id}")]
        public async Task<IActionResult> UnfollowFriend(int user_id, [FromBody] UserFollowRequest request)
        {
            await _userFollowService.UnfollowFriend(user_id, request.Friend_id);
            return Ok(new { message = "Unfollow successfully!" });
        }

        [AllowAnonymous]
        [HttpGet("selectFriends/{user_id}")]
        public async Task<IActionResult> SelectFriends(int user_id)
        {
            var friends = await _userFollowService.SelectFriends(user_id);
            return Ok(friends);
        }
    }
}
