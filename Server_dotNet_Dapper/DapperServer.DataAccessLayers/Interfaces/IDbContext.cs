using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperServer.DataAccessLayer.Interfaces
{
    public interface IDbContext : IDisposable
    {
        IUserRepository UserRepository { get; }
        IUserPhotoRepository UserPhotoRepository { get; }
        IUserDetailsRepository UserDetailsRepository { get; }
        IUserFollowRepository UserFollowRepository { get; }
        IChatConversationsRepository ChatConversationsRepository { get; }
        IUserPostsRepository UserPostsRepository { get; }
        void Commit();
    }
}
