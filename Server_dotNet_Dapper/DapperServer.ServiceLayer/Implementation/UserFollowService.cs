using AutoMapper;
using DapperServer.Common.Helper;
using DapperServer.Common.Interfaces;
using DapperServer.Common.Utils;
using DapperServer.DataAccessLayer.Interfaces;
using DapperServer.DataAccessLayer.Models;
using DapperServer.ServiceLayer.Authorization;
using DapperServer.ServiceLayer.Interfaces;
using DapperServer.ServiceLayer.Utils;

namespace DapperServer.ServiceLayer.Implementation
{
    public class UserFollowService : IUserFollowService
    {
        private readonly IDbContext _context;
        private IJwtUtils _jwtUtils;
        private readonly IAesEncryptionService _aesEncryptionService;

        public UserFollowService(IDbContext context, IJwtUtils jwtUtils, IAesEncryptionService aesEncryptionService)
        {
            _context = context;
            _jwtUtils = jwtUtils;
            _aesEncryptionService = aesEncryptionService;
        }

        public async Task FollowFriend(int user_id, int friend_id)
        {
            await _context.UserFollowRepository.InsertUserFollow(user_id, friend_id);
            _context.Commit();
        }

        public async Task UnfollowFriend(int user_id, int friend_id)
        {
            await _context.UserFollowRepository.DeleteUserFollow(user_id, friend_id);
            _context.Commit();
        }

        public async Task<IEnumerable<UserFollowResponse>> SelectFriends(int user_id)
        {
            return await _context.UserFollowRepository.SelectUserFriends(user_id);
        }
    }
}
