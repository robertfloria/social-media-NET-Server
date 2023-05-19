using DapperServer.DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperServer.DataAccessLayer.Interfaces
{
    public interface IUserPostsRepository
    {
        Task InsertUserPost(int id_utilizator, string photo, string text, string date);
        Task<IEnumerable<UserPosts>> SelectUsersPosts();
        Task<IEnumerable<UserPosts>> SelectUserPosts(int user_id);
        Task DeleteUserPosts(int user_id, int post_id);
        Task InsertComment(int user_id, InsertCommentRequest request, string date);
        Task InsertLike(int user_id, InsertLikeRequest request);
        Task<IEnumerable<LikePostResponse>> SelectPostLikes();
        Task<IEnumerable<CommentPostResponse>> SelectPostComments();
        Task DeleteComment(int id);
        Task DeleteLike(int id);
    }
}
