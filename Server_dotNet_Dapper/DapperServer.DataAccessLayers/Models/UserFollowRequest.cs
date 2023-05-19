using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace DapperServer.DataAccessLayer.Models
{
    public class UserFollowRequest
    {
        [Required]
        public int Friend_id { get; set; }
    }
}
