using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;

namespace AlexandreApps.Meeting_Room.Scheduling.Db.Mongo.Settings
{
    public interface ISettingsModel
    {
        string MainConnectionString { get; set; }
        string DatabaseName { get; set; }

        IMongoCollection<T> GetCollection<T>(string collectionName);
    }
}
