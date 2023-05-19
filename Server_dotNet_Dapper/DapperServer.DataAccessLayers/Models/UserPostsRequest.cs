using System.ComponentModel.DataAnnotations;

namespace DapperServer.DataAccessLayer.Models
{
    public class UserPostsRequest
    {
        public string Photo_post { get; set; }
        public string Text_post { get; set; }
    }
}
