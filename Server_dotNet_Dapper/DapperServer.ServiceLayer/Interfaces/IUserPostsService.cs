using DapperServer.DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperServer.ServiceLayer.Interfaces
{
    public interface IUserPostsService
    {
        Task InsertUserPost(int id_utilizator, string photo, string text);
        Task<IEnumerable<UserPosts>> SelectUsersPosts();
        Task<IEnumerable<UserPosts>> SelectUserPosts(int user_id);
        Task DeleteUserPosts(int user_id, int post_id);
        Task InsertComment(int user_id, InsertCommentRequest request);
        Task InsertLike(int user_id, InsertLikeRequest request);
        Task<IEnumerable<LikePostResponse>> SelectPostLikes();
        Task<IEnumerable<CommentPostResponse>> SelectPostComments();
        Task DeleteLike(int id);
        Task DeleteComment(int id);
    }
}
