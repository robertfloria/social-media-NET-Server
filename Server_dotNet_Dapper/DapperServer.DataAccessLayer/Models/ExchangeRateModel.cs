using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace DapperServer.DataAccessLayer.Models
{
    public class ExchangeRateModel
    {
        public int Id_utilizator { get; set; }
        public string Currency { get; set; }
        public decimal Value { get; set; }
    }
}
