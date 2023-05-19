using AutoMapper;
using DapperServer.Common.Helper;
using DapperServer.Common.Interfaces;
using DapperServer.Common.Utils;
using DapperServer.DataAccessLayer.Interfaces;
using DapperServer.DataAccessLayer.Models;
using DapperServer.ServiceLayer.Authorization;
using DapperServer.ServiceLayer.Interfaces;
using DapperServer.ServiceLayer.Utils;
using System.Globalization;

namespace DapperServer.ServiceLayer.Implementation
{
    public class UserPostsService : IUserPostsService
    {
        private readonly IDbContext _context;
        private IJwtUtils _jwtUtils;
        private readonly IAesEncryptionService _aesEncryptionService;

        public UserPostsService(IDbContext context, IJwtUtils jwtUtils, IAesEncryptionService aesEncryptionService)
        {
            _context = context;
            _jwtUtils = jwtUtils;
            _aesEncryptionService = aesEncryptionService;
        }

        public async Task InsertUserPost(int id_utilizator, string photo, string text)
        {
            string date = DateTime.Now.ToString("yyyy/MM/dd hh:mm:ss.fffffff tt", CultureInfo.InvariantCulture);

            await _context.UserPostsRepository.InsertUserPost(id_utilizator, photo, text, date);
            _context.Commit();
        }

        public async Task<IEnumerable<UserPosts>> SelectUsersPosts()
        {
            return await _context.UserPostsRepository.SelectUsersPosts();
        }

        public async Task<IEnumerable<UserPosts>> SelectUserPosts(int user_id)
        {
            return await _context.UserPostsRepository.SelectUserPosts(user_id);
        }

        public async Task DeleteUserPosts(int user_id, int post_id)
        {
            await _context.UserPostsRepository.DeleteUserPosts(user_id, post_id);
            _context.Commit();
        }

        public async Task InsertComment(int user_id, InsertCommentRequest request)
        {
            string date = DateTime.Now.ToString("yyyy/MM/dd hh:mm:ss.fffffff tt", CultureInfo.InvariantCulture);

            await _context.UserPostsRepository.InsertComment(user_id, request, date);
            _context.Commit();
        }

        public async Task InsertLike(int user_id, InsertLikeRequest request)
        {
            await _context.UserPostsRepository.InsertLike(user_id, request);
            _context.Commit();
        }

        public async Task<IEnumerable<LikePostResponse>> SelectPostLikes()
        {
            return await _context.UserPostsRepository.SelectPostLikes();
        }

        public async Task<IEnumerable<CommentPostResponse>> SelectPostComments()
        {
            return await _context.UserPostsRepository.SelectPostComments();
        }

        public async Task DeleteLike(int id)
        {
            await _context.UserPostsRepository.DeleteLike(id);
            _context.Commit();
        }

        public async Task DeleteComment(int id)
        {
            await _context.UserPostsRepository.DeleteComment(id);
            _context.Commit();
        }
    }
}
