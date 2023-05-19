using System.ComponentModel.DataAnnotations;

namespace DapperServer.DataAccessLayer.Models
{
    public class InsertLikeRequest
    {
        [Required]
        public int Friend_id { get; set; }
        [Required]
        public int Post_id { get; set; }
        [Required]
        public Byte Is_liked { get; set; }
    }
}
