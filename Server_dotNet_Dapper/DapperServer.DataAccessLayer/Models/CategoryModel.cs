using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace DapperServer.DataAccessLayer.Models
{
    public class CategoryModel 
    {
        public int id { get; set; }
        public int id_utilizator { get; set; }
        public DateTime date_time { get; set; }
        public string category { get; set; }
        public decimal amount { get; set; }
        public decimal percentage { get; set; }
    }
}
