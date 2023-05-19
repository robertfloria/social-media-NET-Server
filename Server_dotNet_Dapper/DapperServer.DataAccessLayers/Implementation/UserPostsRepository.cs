using Dapper;
using DapperServer.DataAccessLayer.Implementation.BaseRepository;
using DapperServer.DataAccessLayer.Interfaces;
using DapperServer.DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperServer.DataAccessLayer.Implementation
{
    public class UserPostsRepository : RepositoryBase, IUserPostsRepository
    {
        public UserPostsRepository(IDbTransaction transaction, IDbConnection connection) : base(transaction, connection) { }

        private const string SELECT_USERS_POSTS = "SelectUsersPosts";
        private const string SELECT_POST_LIKES = "SelectPostLikes";
        private const string SELECT_POST_COMMENTS = "SelectPostComments";

        public async Task InsertUserPost(int id_utilizator, string photo, string text, string date)
        {
            var query = $"INSERT INTO UserPosts(user_id, photo_post, text_post, inserted_date) VALUES({id_utilizator}, '{photo}', '{text}', '{date}')";

            await Connection.QueryAsync(query, transaction: Transaction);
        }

        public async Task<IEnumerable<UserPosts>> SelectUsersPosts()
        {
            return await Connection.QueryAsync<UserPosts>(
                sql: SELECT_USERS_POSTS,
                commandType: CommandType.StoredProcedure,
                commandTimeout: 60,
                transaction: Transaction
                );
        }

        public async Task<IEnumerable<UserPosts>> SelectUserPosts(int user_id)
        {
            var query = $"SELECT * FROM UserPosts WHERE user_id = {user_id} ORDER BY inserted_date";

            return await Connection.QueryAsync<UserPosts>(query, transaction: Transaction);
        }

        public async Task DeleteUserPosts(int user_id, int post_id)
        {
            var query = $"DELETE FROM UserPostComments WHERE post_id = {post_id} " +
                $"DELETE FROM UserPostLikes WHERE post_id = {post_id} " +
                $"DELETE FROM UserPosts WHERE user_id = {user_id} AND id = {post_id} ";

            await Connection.QueryAsync(query, transaction: Transaction);
        }

        public async Task InsertComment(int user_id, InsertCommentRequest request, string date)
        {
            var query = $"INSERT INTO UserPostComments(" +
                $"user_id, " +
                $"friend_id, " +
                $"post_id, " +
                $"comment_post, " +
                $"inserted_date) " +
                $"VALUES(" +
                $"{user_id}, " +
                $"{request.Friend_id}, " +
                $"{request.Post_id}, " +
                $"'{request.Comment_post}', " +
                $"'{date}')";

            await Connection.QueryAsync(query, transaction: Transaction);
        }

        public async Task InsertLike(int user_id, InsertLikeRequest request)
        {
            var query = $"INSERT INTO UserPostLikes(" +
                $"user_id, " +
                $"friend_id, " +
                $"post_id, " +
                $"is_liked) " +
                $"VALUES(" +
                $"{user_id}, " +
                $"{request.Friend_id}, " +
                $"{request.Post_id}, " +
                $"{request.Is_liked})";

            await Connection.QueryAsync(query, transaction: Transaction);
        }

        public async Task DeleteLike(int id)
        {
            var query = $"DELETE FROM UserPostLikes WHERE id = {id}";

            await Connection.QueryAsync(query, transaction: Transaction);
        }

        public async Task DeleteComment(int id)
        {
            var query = $"DELETE FROM UserPostComments WHERE id = {id}";

            await Connection.QueryAsync(query, transaction: Transaction);
        }

        public async Task<IEnumerable<LikePostResponse>> SelectPostLikes()
        {
            return await Connection.QueryAsync<LikePostResponse>(
                sql: SELECT_POST_LIKES,
                commandType: CommandType.StoredProcedure,
                commandTimeout: 60,
                transaction: Transaction
                );
        }

        public async Task<IEnumerable<CommentPostResponse>> SelectPostComments()
        {
            return await Connection.QueryAsync<CommentPostResponse>(
                sql: SELECT_POST_COMMENTS,
                commandType: CommandType.StoredProcedure,
                commandTimeout: 60,
                transaction: Transaction
                );
        }
    }
}
