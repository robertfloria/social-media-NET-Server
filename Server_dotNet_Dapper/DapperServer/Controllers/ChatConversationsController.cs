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
    public class ChatConversationsController : ControllerBase
    {
        private IChatConversationsService _chatConversationsService;
        private IMapper _mapper;
        private readonly IDbContext _context;

        public ChatConversationsController(
            IChatConversationsService chatConversationsService,
            IMapper mapper,
            IDbContext context)
        {
            _chatConversationsService = chatConversationsService;
            _mapper = mapper;
            _context = context;
        }

        [AllowAnonymous]
        [HttpPost("insertMessage/{user_id}")]
        public async Task<IActionResult> InsertMessage(int user_id, [FromBody] ChatConversationsRequest request)
        {
            await _chatConversationsService.InserMessage(user_id, request.Friend_id, request.Conversation);
            return Ok(new { message = "Message have been sent!" });
        }

        [AllowAnonymous]
        [HttpGet("selectUsersConversation/{user_id}/{friend_id}")]
        public async Task<IActionResult> SelectUsersConversation(int user_id, int friend_id)
        {
            var result = await _chatConversationsService.SelectUsersConversation(user_id, friend_id);
            return Ok(result);
        }

        [AllowAnonymous]
        [HttpGet("selectUsersMessageList/{user_id}")]
        public async Task<IActionResult> SelectUsersConversation(int user_id)
        {
            var result = await _chatConversationsService.SelectUsersMessageList(user_id);
            return Ok(result);
        }


        [AllowAnonymous]
        [HttpDelete("deleteUserConversation/{user_id}/{friend_id}")]
        public async Task<IActionResult> DeleteUserConversation(int user_id, int friend_id)
        {
            await _chatConversationsService.DeleteUserConversation(user_id, friend_id);
            return Ok(new { message = "Conversation have been deleted!" });
        }
    }
}
