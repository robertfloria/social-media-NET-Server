using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace DapperServer.DataAccessLayer.Models
{
    public class UserFollowResponse
    {
        public string Username { get; set; }
        public int Id { get; set; }
    }
}
