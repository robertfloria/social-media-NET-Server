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
    public class UserPhotoService : IUserPhotoService
    {
        private readonly IDbContext _context;
        private IJwtUtils _jwtUtils;
        private readonly IAesEncryptionService _aesEncryptionService;

        public UserPhotoService(IDbContext context, IJwtUtils jwtUtils, IAesEncryptionService aesEncryptionService)
        {
            _context = context;
            _jwtUtils = jwtUtils;
            _aesEncryptionService = aesEncryptionService;
        }

        public async Task ChangeUserProfilePicture(int user_id, string path)
        {
            await _context.UserPhotoRepository.UpdateUserProfilePhoto(user_id, path);
            _context.Commit();
        }

        public async Task ChangeUserCoverPicture(int user_id, string path)
        {
            await _context.UserPhotoRepository.UpdateUserCoverPhoto(user_id, path);
            _context.Commit();
        }

        public async Task<UserPhotoResponse> GetUserPhotos(int user_id)
        {
            return await _context.UserPhotoRepository.SelectUserPhotos(user_id);
        }

        public async Task<IEnumerable<UsersPhotoResponse>> GetUsersPhotos()
        {
            return await _context.UserPhotoRepository.SelectUsersPhotos();
        }
    }
}
