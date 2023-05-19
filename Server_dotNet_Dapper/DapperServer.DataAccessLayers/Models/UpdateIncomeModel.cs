using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperServer.DataAccessLayer.Models
{
    public class UpdateIncomeModel
    {
        public int Id_utilizator { get; set; }
        public decimal New_income { get; set; }
    }
}
