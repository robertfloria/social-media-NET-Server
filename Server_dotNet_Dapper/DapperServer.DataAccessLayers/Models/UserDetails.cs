using System.ComponentModel.DataAnnotations;

namespace DapperServer.DataAccessLayer.Models
{
    public class UserDetails
    {
        [Required]
        public string Full_name { get; set; }
        [Required]
        public string Country { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Education { get; set; }
        [Required]
        public string Birthday { get; set; }
    }
}
