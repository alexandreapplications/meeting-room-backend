using AlexandreApps.Meeting_Room.Core.Models.Places;
using AlexandreApps.Meeting_Room.Places.Interfaces;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlexandreApps.Meeting_Room.Places.Db.Mongo.DbServices
{
    public class PlaceGroupDbService : IPlaceGroupDbService
    {
        private readonly Settings.ISettingsModel _SettingsModel;
        private const string collectionName = "PlaceGroup";
        public PlaceGroupDbService(Settings.ISettingsModel settingsModel)
        {
            _SettingsModel = settingsModel;
        }

        public Task Create(PlaceGroupModel[] models)
        {
            var collection = _SettingsModel.GetCollection<PlaceGroupModel>(collectionName);
            
            return collection.InsertManyAsync(models);
        }

        public async Task<PlaceGroupModel[]> Update(PlaceGroupModel[] models)
        {
            var collection = _SettingsModel.GetCollection<PlaceGroupModel>(collectionName);

            var tasks = models.Select(x => collection.ReplaceOneAsync(GetFilterDefinitionById(x.Id), x)).ToArray();

            await Task.WhenAll(tasks);

            return tasks.Count(x => !x.IsCompletedSuccessfully) > 0 ? null : models;
        }

        public async Task<long> Delete(Guid[] ids)
        {
            var collection = _SettingsModel.GetCollection<PlaceGroupModel>(collectionName);

            var filter = new MongoDB.Driver.FilterDefinitionBuilder<PlaceGroupModel>().In(x => x.Id, ids);

            var tasks = await collection.DeleteManyAsync(filter);

            return tasks.DeletedCount;
        }

        public Task<PlaceGroupModel> Get(Guid id)
        {
            var collection = _SettingsModel.GetCollection<PlaceGroupModel>(collectionName);

            return collection.Find(GetFilterDefinitionById(id)).FirstOrDefaultAsync();
        }

        private FilterDefinition<PlaceGroupModel> GetFilterDefinitionById(Guid id)
        {
            return new FilterDefinitionBuilder<PlaceGroupModel>().Eq(x => x.Id, id);
        }

        public Task<List<PlaceGroupModel>> GetListBySubscriber(Guid id)
        {
            var collection = _SettingsModel.GetCollection<PlaceGroupModel>(collectionName);

            var filter = new MongoDB.Driver.FilterDefinitionBuilder<PlaceGroupModel>().Eq(x => x.SubscriberId, id);

            return collection.Find(filter).ToListAsync();
        }

    }
}
