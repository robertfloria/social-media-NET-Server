using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperServer.DataAccessLayer.Models
{
    public class UpdateCategoryAmountModel
    {
        public int Id_utilizator { get; set; }
        public int Id_category { get; set; }
        public decimal Amount { get; set; }
    }
}
