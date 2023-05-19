namespace DapperServer.DataAccessLayer.Models
{
    public class AuthenticateResponse
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Authority { get; set; }
        public string Token { get; set; }
    }
}
