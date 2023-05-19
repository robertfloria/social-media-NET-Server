using System.ComponentModel.DataAnnotations;

namespace DapperServer.DataAccessLayer.Models
{
    public class ChatConversationsResponse
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public int User_id { get; set; }
        [Required]
        public string Conversation { get; set; }
        [Required]
        public string Inserted_date { get; set; }
    }
}
