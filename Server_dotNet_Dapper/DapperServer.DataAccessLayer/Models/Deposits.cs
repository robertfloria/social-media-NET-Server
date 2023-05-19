using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace DapperServer.DataAccessLayer.Models
{
    public class Deposits
    {
        public int id { get; set; }
        public int id_utilizator { get; set; }
        public int id_category { get; set; }
        public DateTime date_time { get; set; }
        public string category { get; set; }
        public decimal amount { get; set; }
        public int deposit_period { get; set; }
        public string currency { get; set; }
        public decimal percentage { get; set; }
        public decimal final_amount { get; set; }
    }
}
