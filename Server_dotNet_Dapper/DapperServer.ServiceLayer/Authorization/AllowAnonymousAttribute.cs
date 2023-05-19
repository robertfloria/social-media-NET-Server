namespace DapperServer.ServiceLayer.Authorization
{
    [AttributeUsage(AttributeTargets.Method)]   
    public class AllowAnonymousAttribute : Attribute { }
}
