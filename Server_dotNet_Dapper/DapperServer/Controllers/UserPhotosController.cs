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
    public class UsersPhotosController : ControllerBase
    {
        private IUserPhotoService _userPhotoService;
        private IMapper _mapper;
        private readonly IDbContext _context;

        public UsersPhotosController(
            IUserPhotoService userPhotoService,
            IMapper mapper,
            IDbContext context)
        {
            _userPhotoService = userPhotoService;
            _mapper = mapper;
            _context = context;
        }

        [AllowAnonymous]
        [HttpPut("changeProfilePicture/{user_id}")]
        public async Task<IActionResult> ChangeUserProfilePicture(int user_id, [FromBody] ChangePhotoRequest request)
        {
            await _userPhotoService.ChangeUserProfilePicture(user_id, request.Path);
            return Ok(new { message = "Profile picture updated!" });
        }

        [AllowAnonymous]
        [HttpPut("changeCoverPicture/{user_id}")]
        public async Task<IActionResult> ChangeUserCoverPicture(int user_id, [FromBody] ChangePhotoRequest request)
        {
            await _userPhotoService.ChangeUserCoverPicture(user_id, request.Path);
            return Ok(new { message = "Cover picture updated!" });
        }

        [AllowAnonymous]
        [HttpGet("getUserPhotos/{user_id}")]
        public async Task<IActionResult> GetUserPhotos(int user_id)
        {
            var photos = await _userPhotoService.GetUserPhotos(user_id);
            return Ok(photos);
        }

        [AllowAnonymous]
        [HttpGet("getUsersPhotos")]
        public async Task<IActionResult> GetUsersPhotos()
        {
            var photos = await _userPhotoService.GetUsersPhotos();
            return Ok(photos);
        }
    }
}
