using DapperServer.DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperServer.DataAccessLayer.Interfaces
{
    public interface IIncomeRepository
    {
        Task UpdateIncome(int id, decimal newIncome);
        Task<IEnumerable<IncomeRequest>> GetIncomeById(int id_utilizator);
        Task AddIncome(IncomeRequest model);
    }
}
