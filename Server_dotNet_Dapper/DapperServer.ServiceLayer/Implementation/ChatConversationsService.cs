using AutoMapper;
using DapperServer.Common.Helper;
using DapperServer.Common.Interfaces;
using DapperServer.Common.Utils;
using DapperServer.DataAccessLayer.Interfaces;
using DapperServer.DataAccessLayer.Models;
using DapperServer.ServiceLayer.Authorization;
using DapperServer.ServiceLayer.Interfaces;
using System.Globalization;

namespace DapperServer.ServiceLayer.Implementation
{
    public class ChatConversationsService : IChatConversationsService
    {
        private readonly IDbContext _context;
        private IJwtUtils _jwtUtils;
        private readonly IAesEncryptionService _aesEncryptionService;

        public ChatConversationsService(IDbContext context, IJwtUtils jwtUtils, IAesEncryptionService aesEncryptionService)
        {
            _context = context;
            _jwtUtils = jwtUtils;
            _aesEncryptionService = aesEncryptionService;
        }

        public async Task InserMessage(int id_utilizator, int friend_id, string message)
        {
            string date = DateTime.Now.ToString("yyyy/MM/dd hh:mm:ss.fffffff tt", CultureInfo.InvariantCulture);

            await _context.ChatConversationsRepository.InsertMessage(id_utilizator, friend_id, message, date);
            _context.Commit();
        }

        public async Task<IEnumerable<ChatConversationsResponse>> SelectUsersConversation(int user_id, int friend_id)
        {
            return await _context.ChatConversationsRepository.SelectUsersConversation(user_id, friend_id);
        }

        public async Task<IEnumerable<UsersMessageListResponse>> SelectUsersMessageList(int user_id)
        {
            return await _context.ChatConversationsRepository.SelectUsersMessageList(user_id);
        }

        public async Task DeleteUserConversation(int user_id, int friend_id)
        {
            await _context.ChatConversationsRepository.DeleteUserConversation(user_id, friend_id);
            _context.Commit();
        }
    }
}
