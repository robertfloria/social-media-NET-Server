using DapperServer.Common.Settings;
using DapperServer.Common.Utils;
using DapperServer.DataAccessLayer.Implementation;
using DapperServer.DataAccessLayer.Interfaces;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperServer.DataAccessLayer.Data
{
    public class DbContext : IDbContext
    {
        private ICategoryRepository _categoryRepository;
        private IDepositRepository _depositRepository;
        private IIncomeRepository _incomeRepository;
        private ICurrencyRepository _currencyRepository;
        private IUserRepository _userRepository;
        private IDbConnection _connection;
        private IDbTransaction _transaction;

        private bool _disposed;

        public DbContext(IOptions<AppSettings> appSettings, AesEncryptionService encryptionService)
        {
            var decryptedConnection = encryptionService.Decrypt(appSettings.Value.DatabaseConnectionString);
            _connection = new SqlConnection(decryptedConnection);
            _connection.Open();
            _transaction = _connection.BeginTransaction();
        }

        public ICategoryRepository CategoryRepository => _categoryRepository ?? (_categoryRepository = new CategoryRepository(_transaction, _connection));
        public IDepositRepository DepositRepository => _depositRepository ?? (_depositRepository = new DepositRepository(_transaction, _connection));
        public IIncomeRepository IncomeRepository => _incomeRepository ?? (_incomeRepository = new IncomeRepository(_transaction, _connection));
        public ICurrencyRepository CurrencyRepository => _currencyRepository ?? (_currencyRepository = new CurrencyRepository(_transaction, _connection));
        public IUserRepository UserRepository => _userRepository ?? (_userRepository = new UserRepository(_transaction, _connection));

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
            _categoryRepository = null;
            _depositRepository = null;
            _incomeRepository = null;
            _currencyRepository = null;
            _userRepository = null;
        }

        ~DbContext()
        {
            Dispose(false);
        }
    }
}
