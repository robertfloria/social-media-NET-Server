using System.ComponentModel.DataAnnotations;

namespace DapperServer.DataAccessLayer.Models
{
    public class ChatConversationsRequest
    {
        [Required]
        public int Friend_id { get; set; }
        [Required]
        public string Conversation { get; set; }
    }
}
