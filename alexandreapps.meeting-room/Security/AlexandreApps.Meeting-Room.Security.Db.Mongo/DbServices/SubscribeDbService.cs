using AlexandreApps.Meeting_Room.Core.Models.Security;
using AlexandreApps.Meeting_Room.Security.Interfaces;
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
    }
}
