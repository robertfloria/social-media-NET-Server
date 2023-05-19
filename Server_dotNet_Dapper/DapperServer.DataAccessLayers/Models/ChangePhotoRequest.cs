using System.ComponentModel.DataAnnotations;

namespace DapperServer.DataAccessLayer.Models
{
    public class ChangePhotoRequest
    {
        [Required]
        public string Path { get; set; }
    }
}
