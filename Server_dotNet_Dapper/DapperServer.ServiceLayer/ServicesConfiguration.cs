using DapperServer.ServiceLayer.Implementation;
using DapperServer.ServiceLayer.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace DapperServer.ServiceLayer
{
    public static class ServicesConfiguration
    {
        public static void ServicesDependencies(IServiceCollection services)
        {
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IUserPhotoService, UserPhotoService>();
            services.AddScoped<IUserDetailsService, UserDetailsService>();
            services.AddScoped<IUserFollowService, UserFollowService>();
            services.AddScoped<IChatConversationsService, ChatConversationsService>();
            services.AddScoped<IUserPostsService, UserPostsService>();
        }
    }
}