using System.ComponentModel.DataAnnotations;

namespace DapperServer.DataAccessLayer.Models
{
    public class CommentPostResponse
    {
        [Required]
        public string Comment_post { get; set; }
        [Required]
        public string Inserted_date { get; set; }
        [Required]
        public int Id { get; set; }
        [Required]
        public string Profile_photo { get; set; }
        [Required]
        public string Username { get; set; }
        [Required]
        public int User_id { get; set; }
        [Required]
        public int Post_id { get; set; }
    }
}
