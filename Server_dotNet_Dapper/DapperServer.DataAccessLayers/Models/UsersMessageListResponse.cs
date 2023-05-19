using System.ComponentModel.DataAnnotations;

namespace DapperServer.DataAccessLayer.Models
{
    public class UsersMessageListResponse
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Username { get; set; }
    }
}
