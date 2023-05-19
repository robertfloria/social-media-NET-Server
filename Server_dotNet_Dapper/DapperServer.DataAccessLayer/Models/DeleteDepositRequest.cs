using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace DapperServer.DataAccessLayer.Models
{
    public class DeleteDepositRequest
    {
        [Required]
        public int DepositId { get; set; }
        [Required]
        public int CategoryId { get; set; }
        [Required]
        public decimal Amount { get; set; }
    }
}
