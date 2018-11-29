using AlexandreApps.Meeting_Room.Core.Models.Security;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AlexandreApps.Meeting_Room.Security.Interface
{
    public interface IUserAppService
    {
        /// <summary>
        /// Creates one or more users
        /// </summary>
        /// <param name="userModels">User models</param>
        /// <returns>Information of the created users</returns>
        Task<UserModel[]> Create(UserModel[] userModels);

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
        /// <param name="key">User Key</param>
        /// <returns>Get User</returns>
        Task<UserModel> GetUser(int key);
        /// <summary>
        /// Gets all the user of one subscriber
        /// </summary>
        /// <param name="key">Subscriber key</param>
        /// <returns>User information</returns>
        Task<UserModel> GetUserBySubscriber(int key);
    }
}
