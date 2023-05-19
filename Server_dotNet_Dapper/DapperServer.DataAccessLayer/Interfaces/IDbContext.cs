using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperServer.DataAccessLayer.Interfaces
{
    public interface IDbContext : IDisposable
    {
        ICategoryRepository CategoryRepository { get; }
        IDepositRepository DepositRepository { get; }
        IIncomeRepository IncomeRepository  { get; }
        ICurrencyRepository CurrencyRepository { get; }
        IUserRepository UserRepository { get; }
        void Commit();
    }
}
