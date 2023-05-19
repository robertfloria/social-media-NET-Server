using System.ComponentModel.DataAnnotations;

namespace DapperServer.DataAccessLayer.Models
{
    public class UsersPhotoResponse
    {
        [Required]
        public int Id { get; set; }
        public int User_id { get; set; }
        public string Profile_photo { get; set; }
        public string Cover_photo { get; set; }
    }
}
