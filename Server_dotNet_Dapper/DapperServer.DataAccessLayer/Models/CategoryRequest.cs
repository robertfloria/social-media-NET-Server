using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace DapperServer.DataAccessLayer.Models
{
    public class CategoryRequest
    {
        [Required]
        public int Id_utilizator { get; set; }
        [Required]
        public string Category { get; set; }
        [Required]
        public decimal Amount { get; set; }
        [Required]
        public decimal Percentage { get; set; }
    }
}
