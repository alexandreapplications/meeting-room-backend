using AlexandreApps.Meeting_Room.Core.Models.Security;
using AlexandreApps.Meeting_Room.Security.Interfaces;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AlexandreApps.Meeting_Room.Security.Db.Mongo.DbServices
{
    /// <summary>
    /// Manages user subscription
    /// </summary>
    public class UserSubscriptionDbService: IUserSubscriptionDbService
    {
        private readonly Settings.ISettingsModel _SettingsModel;
        private const string collectionName = "UserSubscription";
        /// <summary>
        /// Creates a new UserSubscriptionDbService instance
        /// </summary>
        /// <param name="settingsModel">Settings</param>
        public UserSubscriptionDbService(Settings.ISettingsModel settingsModel)
        {
            _SettingsModel = settingsModel;
        }

        /// <summary>
        /// Creates a new subscription
        /// </summary>
        /// <param name="model">Suscription data</param>
        /// <returns>Updated record</returns>
        public async Task<UserSubscriptionModel> Create(UserSubscriptionModel model)
        {
            var collection = _SettingsModel.GetCollection<UserSubscriptionModel>(collectionName);

            await collection.InsertOneAsync(model);

            return model;
        }

        /// <summary>
        /// Updates a record
        /// </summary>
        /// <param name="model">Record model</param>
        /// <returns>If operation has succeded</returns>
        public async Task<UserSubscriptionModel> Update(UserSubscriptionModel model)
        {
            var collection = _SettingsModel.GetCollection<UserSubscriptionModel>(collectionName);

            var result = await collection.ReplaceOneAsync(GetFilterId(model.Id), model);

            return result.ModifiedCount > 0 ? model : null;
        }

        /// <summary>
        /// Gets a single record by Id
        /// </summary>
        /// <param name="id">Id</param>
        /// <returns>Record if found</returns>
        public async Task<UserSubscriptionModel> GetSingle(Guid id)
        {
            var collection = _SettingsModel.GetCollection<UserSubscriptionModel>(collectionName);

            return await collection.Find(GetFilterId(id)).FirstOrDefaultAsync();
        }

        /// <summary>
        /// Get subscriptions by user id
        /// </summary>
        /// <param name="id">User Id</param>
        /// <returns>List of user's subscriptions</returns>
        public async Task<IList<UserSubscriptionModel>> GetByUser(Guid id)
        {
            var collection = _SettingsModel.GetCollection<UserSubscriptionModel>(collectionName);

            return await collection.Find(GetFilterByUser(id)).ToListAsync();
        }

        /// <summary>
        /// Get subscriptions by subscription id
        /// </summary>
        /// <param name="id">Subscription id</param>
        /// <returns>List of subscriptions</returns>
        public async Task<IList<UserSubscriptionModel>> GetBySubscription(Guid id)
        {
            var collection = _SettingsModel.GetCollection<UserSubscriptionModel>(collectionName);

            return await collection.Find(GetFilterBySubscription(id)).ToListAsync();
        }
        #region Other specific methods
        /// <summary>
        /// Propagates the user information updates
        /// </summary>
        /// <param name="userId">User id</param>
        /// <param name="code">User Code</param>
        /// <param name="name">User Name</param>
        /// <returns>Task to be run</returns>
        public long UpdateUserInformation(Guid userId, string code, string name)
        {
            var collection = _SettingsModel.GetCollection<UserSubscriptionModel>(collectionName);

            var updateFilter = this.GetFilterByUser(userId);

            var updateDefinitionBuilder = new UpdateDefinitionBuilder<UserSubscriptionModel>();

            var updateDefinition = updateDefinitionBuilder.Set(x => x.UserCode, code)
                .Set(x => x.UserName, name);

            var result = collection.UpdateMany(updateFilter, updateDefinition);

            return result.ModifiedCount;
        }
        #endregion

        #region Filter managenemnt
        /// <summary>
        /// Get filter by id
        /// </summary>
        /// <param name="id">Id</param>
        /// <returns>Filter definition</returns>
        private FilterDefinition<UserSubscriptionModel> GetFilterId(Guid id)
        {
            return _filterDefinitionBuilder.Eq(x => x.Id, id);
        }

        /// <summary>
        /// Instances a filter builder
        /// </summary>
        private FilterDefinitionBuilder<UserSubscriptionModel> _filterDefinitionBuilder = new FilterDefinitionBuilder<UserSubscriptionModel>();
        
        /// <summary>
        /// Gets filter by subscription
        /// </summary>
        /// <param name="id">Subscription id</param>
        /// <returns>Filter definition</returns>
        private FilterDefinition<UserSubscriptionModel> GetFilterBySubscription(Guid id)
        {
            return _filterDefinitionBuilder.Eq(x => x.SubscriptionId, id);
            //return _filterDefinitionBuilder.And(_filterDefinitionBuilder.Ne(x => x.DeletionDate, null), _filterDefinitionBuilder.Eq(x => x.SubscriptionId, id));
        }
        /// <summary>
        /// Gets filter by user
        /// </summary>
        /// <param name="id">User id</param>
        /// <returns>Filter definition</returns>
        private FilterDefinition<UserSubscriptionModel> GetFilterByUser(Guid id)
        {
            return _filterDefinitionBuilder.Eq(x => x.UserId, id);
            //return _filterDefinitionBuilder.And(_filterDefinitionBuilder.Ne(x => x.DeletionDate, null), _filterDefinitionBuilder.Eq(x => x.UserId, id));
        }
        #endregion
    }
}
