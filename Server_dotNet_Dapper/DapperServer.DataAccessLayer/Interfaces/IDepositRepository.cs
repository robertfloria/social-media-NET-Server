using DapperServer.DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperServer.DataAccessLayer.Interfaces
{
    public interface IDepositRepository
    {
        Task AddDeposit(int id_utilizator, int id_category, DepositsRequest addDepositModel);
        Task<IEnumerable<Deposits>> GetDeposit(int id_utilizator, int id_category);
        Task<IEnumerable<Deposits>> GetAllDeposits(int id_utilizator);
        Task DeleteDeposit(int id_utilizator, DeleteDepositRequest request);
    }
}
