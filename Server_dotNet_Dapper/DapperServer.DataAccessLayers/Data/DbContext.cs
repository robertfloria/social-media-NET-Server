using DapperServer.Common.Interfaces;
using DapperServer.Common.Settings;
using DapperServer.DataAccessLayer.Implementation;
using DapperServer.DataAccessLayer.Interfaces;
using Microsoft.Extensions.Options;
using MySqlConnector;
using System.Data;

namespace DapperServer.DataAccessLayer.Data
{
    public class DbContext : IDbContext
    {
        private IUserRepository _userRepository;
        private IUserPhotoRepository _userPhotoRepository;
        private IUserDetailsRepository _userDetailsRepository;
        private IUserFollowRepository _userFollowRepository;
        private IChatConversationsRepository _chatConversationsRepository;
        private IUserPostsRepository _userPostsRepository;
        private IDbConnection _connection;
        private IDbTransaction _transaction;
        private IAesEncryptionService _aesEncryptionService;

        private bool _disposed;

        public DbContext(IOptions<AppSettings> appSettings, IAesEncryptionService aesEncryptionService)
        {
            try
            {
                _aesEncryptionService = aesEncryptionService;
                var decryptedConnection = _aesEncryptionService.Decrypt(appSettings.Value.DatabaseConnectionString);
                _connection = new MySqlConnection (decryptedConnection);
                _connection.Open();
                _transaction = _connection.BeginTransaction();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public IUserRepository UserRepository => _userRepository ?? (_userRepository = new UserRepository(_transaction, _connection));
        public IUserPhotoRepository UserPhotoRepository => _userPhotoRepository ?? (_userPhotoRepository = new UserPhotoRepository(_transaction, _connection));
        public IUserDetailsRepository UserDetailsRepository => _userDetailsRepository ?? (_userDetailsRepository = new UserDetailsRepository(_transaction, _connection));
        public IUserFollowRepository UserFollowRepository => _userFollowRepository ?? (_userFollowRepository = new UserFollowRepository(_transaction, _connection));
        public IChatConversationsRepository ChatConversationsRepository => _chatConversationsRepository ?? (_chatConversationsRepository = new ChatConversationsRepository(_transaction, _connection));
        public IUserPostsRepository UserPostsRepository => _userPostsRepository ?? (_userPostsRepository = new UserPostsRepository(_transaction, _connection));

        public void Commit()
        {
            try
            {
                _transaction.Commit();
            }
            catch
            {
                _transaction.Rollback();
                throw;
            }
            finally
            {
                _transaction = _connection.BeginTransaction();
                ResetRepositories();
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    if (_transaction != null)
                    {
                        _transaction.Dispose();
                        _transaction = null;
                    }
                    if (_connection != null)
                    {
                        _connection.Dispose();
                        _connection = null;
                    }
                }

                _disposed = true;
            }
        }

        private void ResetRepositories()
        {
            _userRepository = null;
        }

        ~DbContext()
        {
            Dispose(false);
        }
    }
}
