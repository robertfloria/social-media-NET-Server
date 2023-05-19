using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperServer.DataAccessLayer.Models
{
    public class AddDepositModel
    {
        public int Id_utilizator { get; set; }
        public int Id_category { get; set; }
        public DateTime Date_time { get; set; }
        public string Category { get; set; }
        public decimal Amount { get; set; }
        public int Deposit_period { get; set; }
        public string Currency { get; set; }
        public decimal Percentage { get; set; }
    }
}
