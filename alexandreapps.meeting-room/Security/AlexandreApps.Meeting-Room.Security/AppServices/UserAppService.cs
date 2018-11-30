using AlexandreApps.Meeting_Room.Core.Models.Security;
using AlexandreApps.Meeting_Room.Core.Utils;
using AlexandreApps.Meeting_Room.Security.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlexandreApps.Meeting_Room.Security.AppServices
{
    /// <summary>
    /// Manage users
    /// </summary>
    public class UserAppService : IUserAppService
    {
        private readonly IUserDbService _UserDb;

        public UserAppService(IUserDbService userDb)
        {
            this._UserDb = userDb;
        }

        /// <summary>
        /// Creates one or more users
        /// </summary>
        /// <param name="userModels">User models</param>
        /// <returns>Information of the created users</returns>
        public async Task<UserModel[]> Create(params UserModel[] userModels)
        {
            foreach (var item in userModels)
            {
                item.Id = Guid.NewGuid();
                item.Emails.ForEach(x => x.Id = Guid.NewGuid());
                item.Telephones.ForEach(x => x.Id = Guid.NewGuid());
                await _UserDb.Create(item);
            }
            return userModels;
        }

        /// <summary>
        /// Changes user password
        /// </summary>
        /// <param name="id">User Id</param>
        /// <param name="currentPassword">CurrentPassword</param>
        /// <param name="newPassword">Newpassword</param>
        /// <param name="remarks">List of erros</param>
        /// <returns>If the operation succeded</returns>
        public async Task<bool> ChangePassword(Guid id, string currentPassword, string newPassword, Dictionary<string, string> remarks)
        {
            var userModel = await _UserDb.GetSingle(id);

            if (userModel == null || !ValidatePassword(userModel, currentPassword))
            {
                remarks.Add("UserDoesntExistsOrInvalidPws", "User doesn't exists or the password is invalid");
                return false;
            }

            var now = DateTime.Now;
            UserPasswordHistory userPassword = new UserPasswordHistory
            {
                Id = Guid.NewGuid(),
                InitialDate = now,
                Password = EncriptionHelper.EncriptPassword(newPassword, now)
            };
            if (userModel.PasswordHistory == null)
                userModel.PasswordHistory = new List<UserPasswordHistory> { userPassword };
            else userModel.PasswordHistory.Add(userPassword);
            return await _UserDb.Update(userModel);
        }

        private bool ValidatePassword(UserModel userModel, string password)
        {
            if (userModel.PasswordHistory == null || userModel.PasswordHistory.Count == 0)
                return true;
            var lastPassword = userModel.PasswordHistory.OrderByDescending(x => x.InitialDate).First();
            var convertedPwd = EncriptionHelper.EncriptPassword(password, lastPassword.InitialDate);
            return lastPassword.Password.SequenceEqual(convertedPwd);
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
