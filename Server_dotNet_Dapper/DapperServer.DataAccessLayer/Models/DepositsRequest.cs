using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace DapperServer.DataAccessLayer.Models
{
    public class DepositsRequest
    {
        [Required]
        public string Category { get; set; }
        [Required]
        public decimal Amount { get; set; }
        [Required]
        public int Deposit_period { get; set; }
        [Required]
        public string Currency { get; set; }
        [Required]
        public decimal Percentage { get; set; }
    }
}
