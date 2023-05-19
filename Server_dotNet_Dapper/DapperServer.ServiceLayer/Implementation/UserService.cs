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
    public class UserService : IUserService
    {
        private readonly IDbContext _context;
        private IJwtUtils _jwtUtils;
        private readonly IAesEncryptionService _aesEncryptionService;

        public UserService(IDbContext context, IJwtUtils jwtUtils, IAesEncryptionService aesEncryptionService)
        {
            _context = context;
            _jwtUtils = jwtUtils;
            _aesEncryptionService = aesEncryptionService;
        }

        public async Task<AuthenticateResponse> Authenticate(AuthenticateRequest model)
        {
            var user = await _context.UserRepository.GetUserByUsername(model.Username);
            _context.Commit();

            if (user == null || _aesEncryptionService.Decrypt(user.Password) != model.Password)
                throw new AppException("Username or password is incorrect");

            // authentication successful
            user.Token = _jwtUtils.GenerateToken(user.Id);
            return user;
        }

        public async Task Register(RegisterRequest model)
        {
            if (RegExpValidation.UsernameValidation(model.Username) &&
                RegExpValidation.PasswordValidation(model.Password) &&
                RegExpValidation.EmailValidation(model.Email)
                )
            {
                // validate
                var users = await _context.UserRepository.GetUsers();
                if (users.Any(x => x.Username == model.Username))
                    throw new AppException("Username '" + model.Username + "' is already taken");

                // map model to new user object
                var user = Mapping.Mapper.Map<AuthenticateResponse>(model);

                // hash password
                user.Password = _aesEncryptionService.Encrypt(model.Password);
                user.Authority = "Admin";

                // save user
                await _context.UserRepository.AddUser(user);
                _context.Commit();


                // set user pictures empty
                var userId = await _context.UserRepository.GetUserByUsername(model.Username);

                UserPhotos userPhotos = new UserPhotos();
                userPhotos.User_id = userId.Id;

                await _context.UserPhotoRepository.InsertUserProfileCoverEmptyPicture(userPhotos.User_id);
                _context.Commit();

                // insert empty user details

                UserDetails userDetails = new UserDetails();
                userDetails.Full_name = "";
                userDetails.Country = "";
                userDetails.City = "";
                userDetails.Email = "";
                userDetails.Education = "";
                userDetails.Birthday = "";

                await _context.UserDetailsRepository.InsertUserDetails(userId.Id, userDetails);
                _context.Commit();
            }

            else
                throw new AppException("One or more validation Occures!");
        }

        public async Task UpdateUsername(int id, UpdateUsernameRequest model)
        {
            if (RegExpValidation.UsernameValidation(model.Username))
            {
                var user = await _context.UserRepository.GetUserById(id);
                var users = await _context.UserRepository.GetUsers();

                if (model.Username != user.Username && users.Any(x => x.Username == model.Username))
                    throw new AppException("Username '" + model.Username + "' is already taken");

                await _context.UserRepository.UpdateUsername(id, model);

                _context.Commit();
            }
            else
                throw new AppException("One or more validation Occures!");
        }

        public async Task UpdatePassword(int id, UpdatePasswordRequest model)
        {
            if (RegExpValidation.PasswordValidation(model.Password))
            {
                if (!string.IsNullOrEmpty(model.Password))
                    model.Password = _aesEncryptionService.Encrypt(model.Password);

                await _context.UserRepository.UpdatePassword(id, model);

                _context.Commit();
            }
            else
                throw new AppException("One or more validation Occures!");
        }

        public async Task UpdateEmail(int id, UpdateEmailRequest model)
        {
            if (RegExpValidation.EmailValidation(model.Email))
            {
                var user = await _context.UserRepository.GetUserById(id);
                var users = await _context.UserRepository.GetUsers();

                if (model.Email != user.Email && users.Any(x => x.Email == model.Email))
                    throw new AppException("Email '" + model.Email + "' is already taken");

                await _context.UserRepository.UpdateEmail(id, model);

                _context.Commit();
            }
            else
                throw new AppException("One or more validation Occures!");
        }

        public async Task<AuthenticateResponse> GetUserById(int id)
        {
            return await _context.UserRepository.GetUserById(id);
        }

        public async Task Delete(int id)
        {
            await _context.UserRepository.DeleteUser(id);
            _context.Commit();
        }

        public async Task<IEnumerable<SearchUsersResponse>> SearchUsers(string username)
        {
            return await _context.UserRepository.SearchUsers(username);
        }

        public async Task<IEnumerable<SearchUsersResponse>> GetAllUsers()
        {
            return await _context.UserRepository.GetAllUsers();
        }
    }
}
