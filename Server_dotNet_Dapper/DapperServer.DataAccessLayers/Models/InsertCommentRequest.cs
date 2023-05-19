using System.ComponentModel.DataAnnotations;

namespace DapperServer.DataAccessLayer.Models
{
    public class InsertCommentRequest
    {
        [Required]
        public int Friend_id { get; set; }
        [Required]
        public int Post_id { get; set; }
        [Required]
        public string Comment_post { get; set; }
    }
}
