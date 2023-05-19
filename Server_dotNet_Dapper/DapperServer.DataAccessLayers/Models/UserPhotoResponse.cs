using System.ComponentModel.DataAnnotations;

namespace DapperServer.DataAccessLayer.Models
{
    public class UserPhotoResponse
    {
        [Required]
        public string Profile_photo { get; set; }
        public string Cover_photo { get; set; }
    }
}
