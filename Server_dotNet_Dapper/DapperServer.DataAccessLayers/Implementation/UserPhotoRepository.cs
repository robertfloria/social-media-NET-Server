﻿using Dapper;
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
    public class UserPhotoRepository : RepositoryBase, IUserPhotoRepository
    {
        public UserPhotoRepository(IDbTransaction transaction, IDbConnection connection) : base(transaction, connection) { }
        public async Task UpdateUserProfilePhoto(int id_utilizator, string path)
        {
            var query = $"UPDATE heroku_4b02a80e7cb1159.userphotos SET profile_photo = '{path}' WHERE user_id = '{id_utilizator}'";

            await Connection.QueryAsync(query, transaction: Transaction);
        }

        public async Task UpdateUserCoverPhoto(int id_utilizator, string path)
        {
            var query = $"UPDATE heroku_4b02a80e7cb1159.userphotos SET cover_photo = '{path}' WHERE user_id = '{id_utilizator}'";

            await Connection.QueryAsync(query, transaction: Transaction);
        }

        public async Task InsertUserProfileCoverEmptyPicture(int id_utilizator)
        {
            var query = $"INSERT INTO heroku_4b02a80e7cb1159.userphotos(user_id, profile_photo, cover_photo) VALUES('{id_utilizator}', ' ', ' ')";

            await Connection.QueryAsync(query, transaction: Transaction);
        }

        public async Task<UserPhotoResponse> SelectUserPhotos(int id_utilizator)
        {
            var query = $"SELECT profile_photo, cover_photo from heroku_4b02a80e7cb1159.userphotos WHERE user_id = '{id_utilizator}'";

            return await Connection.QueryFirstAsync<UserPhotoResponse>(query, transaction: Transaction);
        }

        public async Task<IEnumerable<UsersPhotoResponse>> SelectUsersPhotos()
        {
            var query = $"SELECT id, user_id, profile_photo, cover_photo from userphotos";

            return await Connection.QueryAsync<UsersPhotoResponse>(query, transaction: Transaction);
        }
    }
}
