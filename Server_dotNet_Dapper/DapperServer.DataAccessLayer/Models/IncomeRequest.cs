using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace DapperServer.DataAccessLayer.Models
{
    public class IncomeRequest
    {
        [Required]
        public int id_utilizator { get; set; }
        [Required]
        public decimal income { get; set; }
        [Required]
        public decimal eur { get; set; }
        [Required]
        public decimal usd { get; set; }
    }
}
