using AlexandreApps.Meeting_Room.Core.Models.Security;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AlexandreApps.Meeting_Room.Security.Interfaces
{
    public interface IUserAppService
    {
        /// <summary>
        /// Creates one or more users
        /// </summary>
        /// <param name="userModels">User models</param>
        /// <returns>Information of the created users</returns>
        Task<UserModel[]> Create(params UserModel[] userModels);

        /// <summary>
        /// Changes user password
        /// </summary>
        /// <param name="userId">User Id</param>
        /// <param name="currentPassword">CurrentPassword</param>
        /// <param name="newPassword">Newpassword</param>
        /// <param name="remarks">List of erros</param>
        /// <returns>If the operation succeded</returns>
        Task<bool> ChangePassword(Guid userId, string currentPassword, string newPassword, Dictionary<string, string> remarks);
        /// <summary>
        /// Updates one or more users
        /// </summary>
        /// <param name="userModels">User models</param>
        /// <returns>Information of the created users</returns>
        Task<UserModel[]> Update(UserModel[] userModels);

        /// <summary>
        /// Delete
        /// </summary>
        /// <param name="userModels">User models</param>
        /// <returns>Information of the created users</returns>
        Task<UserModel[]> Delete(int[] keys);
        /// <summary>
        /// Gets a specific user
        /// </summary>
        /// <param name="id">User Id</param>
        /// <returns>Get User</returns>
        Task<UserModel> GetUser(Guid id);
        /// <summary>
        /// Gets all the user of one subscriber
        /// </summary>
        /// <param name="id">Subscriber Id</param>
        /// <returns>User information</returns>
        Task<UserModel> GetUserBySubscriber(Guid id);
        /// <summary>
        /// Verify if user or a list of users do exists
        /// </summary>
        /// <param name="userIds">List of ids</param>
        /// <returns>If exists</returns>
        bool VerifyUserExistance(params Guid[] userIds);
    }
}
