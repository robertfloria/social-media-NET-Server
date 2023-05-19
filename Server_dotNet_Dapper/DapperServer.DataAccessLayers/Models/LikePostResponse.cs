using System.ComponentModel.DataAnnotations;

namespace DapperServer.DataAccessLayer.Models
{
    public class LikePostResponse
    {
        [Required]
        public int Post_id { get; set; }
        [Required]
        public int User_id { get; set; }
        [Required]
        public int Id { get; set; }
        [Required]
        public string Profile_photo { get; set; }
    }
}
