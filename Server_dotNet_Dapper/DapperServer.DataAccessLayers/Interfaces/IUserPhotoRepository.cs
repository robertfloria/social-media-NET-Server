using DapperServer.DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperServer.DataAccessLayer.Interfaces
{
    public interface IUserPhotoRepository
    {
        Task UpdateUserCoverPhoto(int id_utilizator, string request);
        Task UpdateUserProfilePhoto(int id_utilizator, string request);
        Task InsertUserProfileCoverEmptyPicture(int id_utilizator);
        Task<UserPhotoResponse> SelectUserPhotos(int id_utilizator);
        Task<IEnumerable<UsersPhotoResponse>> SelectUsersPhotos();
    }
}
