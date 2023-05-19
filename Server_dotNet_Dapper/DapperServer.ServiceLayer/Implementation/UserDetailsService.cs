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
    public class UserDetailsService : IUserDetailsService
    {
        private readonly IDbContext _context;
        private IJwtUtils _jwtUtils;
        private readonly IAesEncryptionService _aesEncryptionService;

        public UserDetailsService(IDbContext context, IJwtUtils jwtUtils, IAesEncryptionService aesEncryptionService)
        {
            _context = context;
            _jwtUtils = jwtUtils;
            _aesEncryptionService = aesEncryptionService;
        }

        public async Task UpdateUserDetails(int user_id, UserDetails request)
        {
            await _context.UserDetailsRepository.UpdateUserDetails(user_id, request);
            _context.Commit();
        }

        public async Task<UserDetails> GetUserDetails(int user_id)
        {
            return await _context.UserDetailsRepository.GetUserDetails(user_id);
        }
    }
}
