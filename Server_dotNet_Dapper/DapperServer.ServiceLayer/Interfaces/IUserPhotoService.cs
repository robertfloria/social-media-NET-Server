using DapperServer.DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperServer.ServiceLayer.Interfaces
{
    public interface IUserPhotoService
    {
        Task ChangeUserProfilePicture(int user_id, string path);
        Task ChangeUserCoverPicture(int user_id, string path);
        Task<UserPhotoResponse> GetUserPhotos(int user_id);
        Task<IEnumerable<UsersPhotoResponse>> GetUsersPhotos();
    }
}
