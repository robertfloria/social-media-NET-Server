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
    public class UserPostsController : ControllerBase
    {
        private IUserPostsService _userPostsService;
        private IMapper _mapper;
        private readonly IDbContext _context;

        public UserPostsController(
            IUserPostsService userPostsService,
            IMapper mapper,
            IDbContext context)
        {
            _userPostsService = userPostsService;
            _mapper = mapper;
            _context = context;
        }

        [AllowAnonymous]
        [HttpPost("insertPost/{user_id}")]
        public async Task<IActionResult> InsertUserPost(int user_id, [FromBody] UserPostsRequest request)
        {
            await _userPostsService.InsertUserPost(user_id, request.Photo_post, request.Text_post);
            return Ok(new { message = "Your post have been uploaded!" });
        }

        [AllowAnonymous]
        [HttpGet("selectUsersPosts")]
        public async Task<IActionResult> SelectUsersPosts()
        {
            var response = await _userPostsService.SelectUsersPosts();
            return Ok(response);
        }

        [AllowAnonymous]
        [HttpGet("selectUserPosts/{user_id}")]
        public async Task<IActionResult> SelectUserPosts(int user_id)
        {
            var response = await _userPostsService.SelectUserPosts(user_id);
            return Ok(response);
        }

        [AllowAnonymous]
        [HttpDelete("deleteUserPosts/{user_id}/{post_id}")]
        public async Task<IActionResult> DeleteUserPosts(int user_id, int post_id)
        {
            await _userPostsService.DeleteUserPosts(user_id, post_id);
            return Ok(new { message = "Post have been deleted!" });
        }

        [AllowAnonymous]
        [HttpDelete("deleteLike/{id}")]
        public async Task<IActionResult> DeleteLike(int id)
        {
            await _userPostsService.DeleteLike(id);
            return Ok(new { message = "Like deleted!" });
        }

        [AllowAnonymous]
        [HttpDelete("deleteComment/{id}")]
        public async Task<IActionResult> DeleteComment(int id)
        {
            await _userPostsService.DeleteComment(id);
            return Ok(new { message = "Comment deleted!" });
        }

        [AllowAnonymous]
        [HttpPost("insertComment/{user_id}")]
        public async Task<IActionResult> InsertComment(int user_id, [FromBody] InsertCommentRequest request)
        {
            await _userPostsService.InsertComment(user_id, request);
            return Ok(new { message = "Comment added!" });
        }

        [AllowAnonymous]
        [HttpPost("insertLike/{user_id}")]
        public async Task<IActionResult> InsertLike (int user_id, [FromBody] InsertLikeRequest request)
        {
            await _userPostsService.InsertLike(user_id, request);
            return Ok(new { message = "You liked thid post!" });
        }

        [AllowAnonymous]
        [HttpGet("selectPostLikes")]
        public async Task<IActionResult> SelectPostLikes()
        {
            var response = await _userPostsService.SelectPostLikes();
            return Ok(response);
        }

        [AllowAnonymous]
        [HttpGet("selectPostComments")]
        public async Task<IActionResult> SelectPostComments()
        {
            var response = await _userPostsService.SelectPostComments();
            return Ok(response);
        }
    }
}
