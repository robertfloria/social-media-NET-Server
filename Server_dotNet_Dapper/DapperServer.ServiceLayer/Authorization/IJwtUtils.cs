
namespace DapperServer.ServiceLayer.Authorization
{
    public interface IJwtUtils
    {
        public string GenerateToken(int id);
        public int? ValidateToken(string token);
    }
}
