using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace DapperServer.DataAccessLayer.Models
{
    public class AddCategoryModel 
    { 
        public int Id_utilizator { get; set; }
        public DateTime Date_time { get; set; }
        public string Category { get; set; }
        public decimal Amount { get; set; }
        public decimal Percentage { get; set; }
    }
}
