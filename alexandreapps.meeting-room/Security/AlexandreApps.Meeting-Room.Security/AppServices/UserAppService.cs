using AlexandreApps.Meeting_Room.Core.Models.Security;
using AlexandreApps.Meeting_Room.Security.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AlexandreApps.Meeting_Room.Security.AppServices
{
    /// <summary>
    /// Manage users
    /// </summary>
    public class UserAppService: IUserAppService
    {
        /// <summary>
        /// Creates one or more users
        /// </summary>
        /// <param name="userModels">User models</param>
        /// <returns>Information of the created users</returns>
        public async Task<UserModel[]> Create(UserModel[] userModels)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Updates one or more users
        /// </summary>
        /// <param name="userModels">User models</param>
        /// <returns>Information of the created users</returns>
        public async Task<UserModel[]> Update(UserModel[] userModels)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Delete
        /// </summary>
        /// <param name="userModels">User models</param>
        /// <returns>Information of the created users</returns>
        public async Task<UserModel[]> Delete(int[] keys)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Gets a specific user
        /// </summary>
        /// <param name="key">User Key</param>
        /// <returns>Get User</returns>
        public async Task<UserModel> GetUser(int key)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Gets all the user of one subscriber
        /// </summary>
        /// <param name="key">Subscriber key</param>
        /// <returns>User information</returns>
        public async Task<UserModel> GetUserBySubscriber(int key)
        {
            throw new NotImplementedException();
        }
    }
}
