using AlexandreApps.Meeting_Room.Core.Models.Places;
using AlexandreApps.Meeting_Room.Places.Interfaces;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlexandreApps.Meeting_Room.Places.Db.Mongo.DbServices
{
    public class PlaceDbService : IPlaceDbService
    {
        private readonly Settings.ISettingsModel _SettingsModel;
        private const string collectionName = "Place";
        public PlaceDbService(Settings.ISettingsModel settingsModel)
        {
            _SettingsModel = settingsModel;
        }
        public Task Create(PlaceModel[] models)
        {
            var collection = _SettingsModel.GetCollection<PlaceModel>(collectionName);

            return collection.InsertManyAsync(models);
        }

        public async Task<PlaceModel[]> Update(PlaceModel[] models)
        {
            var collection = _SettingsModel.GetCollection<PlaceModel>(collectionName);

            var tasks = models.Select(x => collection.ReplaceOneAsync(GetFilterDefinitionById(x.Id), x)).ToArray();

            await Task.WhenAll(tasks);

            return tasks.Count(x => !x.IsCompletedSuccessfully) > 0 ? null : models;
        }

        public async Task<long> Delete(Guid[] ids)
        {
            var collection = _SettingsModel.GetCollection<PlaceModel>(collectionName);

            var filter = new MongoDB.Driver.FilterDefinitionBuilder<PlaceModel>().In(x => x.Id, ids);

            var tasks = await collection.DeleteManyAsync(filter);

            return tasks.DeletedCount;
        }

        public Task<PlaceModel> Get(Guid id)
        {
            var collection = _SettingsModel.GetCollection<PlaceModel>(collectionName);

            return collection.Find(GetFilterDefinitionById(id)).FirstOrDefaultAsync();
        }

        private FilterDefinition<PlaceModel> GetFilterDefinitionById(Guid id)
        {
            return new FilterDefinitionBuilder<PlaceModel>().Eq(x => x.Id, id);
        }

        public Task<List<PlaceModel>> GetListBySubscriber(Guid id)
        {
            var collection = _SettingsModel.GetCollection<PlaceModel>(collectionName);

            var filter = new MongoDB.Driver.FilterDefinitionBuilder<PlaceModel>().Eq(x => x.SubscriberId, id);

            return collection.Find(filter).ToListAsync();
        }
    }
}
