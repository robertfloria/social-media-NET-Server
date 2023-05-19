using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace DapperServer.DataAccessLayer.Models
{
    public class AuthenticateRequest
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
