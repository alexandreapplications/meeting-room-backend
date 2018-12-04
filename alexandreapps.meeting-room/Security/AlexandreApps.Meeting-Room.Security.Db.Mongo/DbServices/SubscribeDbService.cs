using AlexandreApps.Meeting_Room.Core.Models.Security;
using AlexandreApps.Meeting_Room.Security.Interfaces;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AlexandreApps.Meeting_Room.Security.Db.Mongo.DbServices
{
    public class SubscribeDbService: ISubscribeDbService
    {
        private readonly Settings.ISettingsModel _SettingsModel;
        private const string collectionName = "Subscriber";
        public SubscribeDbService(Settings.ISettingsModel settingsModel)
        {
            _SettingsModel = settingsModel;
        }
        /// <summary>
        /// Creates a new subscription
        /// </summary>
        /// <param name="model">Suscription data</param>
        /// <returns>Updated record</returns>
        public async Task<SubscriberModel> Create(SubscriberModel model)
        {
            var collection = _SettingsModel.GetCollection<SubscriberModel>(collectionName);

            await collection.InsertOneAsync(model);

            return model;
        }
        public async Task<SubscriberModel> GetSingle(Guid id)
        {
            var collection = _SettingsModel.GetCollection<SubscriberModel>(collectionName);

            return await collection.Find(GetFilterUniqueId(id)).FirstOrDefaultAsync();
        }

        public async Task<SubscriberModel> GetByCode(string code)
        {
            var collection = _SettingsModel.GetCollection<SubscriberModel>(collectionName);

            return await collection.Find(GetFilterByCode(code)).FirstOrDefaultAsync();
        }

        private FilterDefinition<SubscriberModel> GetFilterUniqueId(Guid uniqueId)
        {
            return new FilterDefinitionBuilder<SubscriberModel>().Eq(x => x.Id, uniqueId);
        }
        private FilterDefinition<SubscriberModel> GetFilterByCode(string code)
        {
            return new FilterDefinitionBuilder<SubscriberModel>().Eq(x => x.Code, code);
        }
    }
}
