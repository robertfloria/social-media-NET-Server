using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace DapperServer.DataAccessLayer.Models
{
    public class UpdateCurrencyModel
    {
        public string CurrencyName { get; set; }
        public decimal Value { get; set; }
    }
}
