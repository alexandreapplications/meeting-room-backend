using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;

namespace AlexandreApps.Meeting_Room.Scheduling.Db.Mongo.Settings
{
    public class SettingsModel : ISettingsModel
    {
        public string MainConnectionString { get; set; }
        public string DatabaseName { get; set; }

        private MongoClientSettings _clientSettings;

        private List<string> ValidatedCollections = new List<string>();

        public IMongoCollection<T> GetCollection<T>(string collectionName)
        {
            if (this._clientSettings == null)
            {
                this._clientSettings = MongoClientSettings.FromUrl(new MongoUrl(this.MainConnectionString));

                //SslProtocols sslProtocols = SslProtocols.None;

                //if (!string.IsNullOrWhiteSpace(this._settingsAppService.Settings.SecurityToken.MainSslProtocol) && Enum.TryParse<SslProtocols>(this._settingsAppService.Settings.SecurityToken.MainSslProtocol, out sslProtocols))
                //{
                //    this._clientSettings.SslSettings = new SslSettings() { EnabledSslProtocols = sslProtocols };
                //}
            }
            var mongoClient = new MongoClient(this._clientSettings);

            var database = mongoClient.GetDatabase(this.DatabaseName);

            return database.GetCollection<T>(collectionName);
        }
    }
}
