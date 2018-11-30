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
        public async Task<UserModel[]> Update(params UserModel[] userModels)
        {
            Task<bool>[] tasks = userModels.Select(x => _UserDb.Update(x)).ToArray();

            var file = await Task.WhenAll<bool>(tasks);

            return userModels;
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
        /// <param name="id">User Id</param>
        /// <returns>Get User</returns>
        public async Task<UserModel> GetUser(Guid id)
        {
            return await _UserDb.GetSingle(id);
        }
        /// <summary>
        /// Gets all the user of one subscriber
        /// </summary>
        /// <param name="id">Subscriber Id</param>
        /// <returns>User information</returns>
        public async Task<UserModel> GetUserBySubscriber(Guid id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Verify if user or a list of users do exists
        /// </summary>
        /// <param name="userIds">List of ids</param>
        /// <returns>If exists</returns>
        public bool VerifyUserExistance(params Guid[] userIds)
        {
            if (userIds == null || userIds.Length == 0)
                return true;
            Task<UserModel>[] userModels = userIds.Select(guid =>
                    this.GetUser(guid)).ToArray();
            Task.WaitAll(userModels);
            return (userModels.Count(x => x.Result == null) == 0);
        }
    }
}
