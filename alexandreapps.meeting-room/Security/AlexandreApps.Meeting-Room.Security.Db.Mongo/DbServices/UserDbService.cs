using AlexandreApps.Meeting_Room.Core.Models.Security;
using AlexandreApps.Meeting_Room.Security.Interfaces;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AlexandreApps.Meeting_Room.Security.Db.Mongo.DbServices
{
    public class UserDbService: IUserDbService
    {
        private readonly Settings.ISettingsModel _SettingsModel;
        private const string collectionName = "User";
        public UserDbService(Settings.ISettingsModel settingsModel)
        {
            _SettingsModel = settingsModel;
        }
        /// <summary>
        /// Creates a new subscription
        /// </summary>
        /// <param name="model">Suscription data</param>
        /// <returns>Updated record</returns>
        public async Task<UserModel> Create(UserModel model)
        {
            var collection = _SettingsModel.GetCollection<UserModel>(collectionName);

            await collection.InsertOneAsync(model);

            return model;
        }

        /// <summary>
        /// Updates a record
        /// </summary>
        /// <param name="model">Record model</param>
        /// <returns>If operation has succeded</returns>
        public async Task<bool> Update(UserModel model)
        {
            var collection = _SettingsModel.GetCollection<UserModel>(collectionName);

            await collection.ReplaceOneAsync(GetFilterUniqueId(model.Id), model);

            return true;
        }

        public async Task<UserModel> GetSingle(Guid id)
        {
            var collection = _SettingsModel.GetCollection<UserModel>(collectionName);

            return await collection.Find(GetFilterUniqueId(id)).FirstOrDefaultAsync();
        }

        public async Task<IList<UserModel>> GetAll()
        {
            var collection = _SettingsModel.GetCollection<UserModel>(collectionName);

            return await collection.AsQueryable().ToListAsync();
        }

        private FilterDefinition<UserModel> GetFilterUniqueId(Guid uniqueId)
        {
            return new FilterDefinitionBuilder<UserModel>().Eq(x => x.Id, uniqueId);
        }
    }
}
