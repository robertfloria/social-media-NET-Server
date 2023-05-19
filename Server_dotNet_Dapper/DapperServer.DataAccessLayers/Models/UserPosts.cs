using System.ComponentModel.DataAnnotations;

namespace DapperServer.DataAccessLayer.Models
{
    public class UserPosts
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public int Post_id { get; set; }

        [Required]
        public string Username { get; set; }

        [Required]
        public string Profile_photo { get; set; }
        [Required]
        public string Photo_post { get; set; }
        [Required]
        public string Text_post { get; set; }
        [Required]
        public DateTime Inserted_date { get; set; }
    }
}
