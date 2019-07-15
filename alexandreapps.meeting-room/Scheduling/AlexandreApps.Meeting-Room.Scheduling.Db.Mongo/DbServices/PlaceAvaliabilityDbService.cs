using AlexandreApps.Meeting_Room.Core.Models.Scheduling;
using AlexandreApps.Meeting_Room.Scheduling.Interfaces;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlexandreApps.Meeting_Room.Scheduling.Db.Mongo.DbServices
{
    public class PlaceAvaliabilityDbService : IPlaceAvailabilityDbService
    {
        private readonly Settings.ISettingsModel _SettingsModel;
        private const string collectionName = "PlaceAvaliability";
        public PlaceAvaliabilityDbService(Settings.ISettingsModel settingsModel)
        {
            _SettingsModel = settingsModel;
        }
        public Task Create(PlaceAvailabilityModel[] models)
        {
            var collection = _SettingsModel.GetCollection<PlaceAvailabilityModel>(collectionName);

            return collection.InsertManyAsync(models);
        }

        public async Task<PlaceAvailabilityModel[]> Update(PlaceAvailabilityModel[] models)
        {
            var collection = _SettingsModel.GetCollection<PlaceAvailabilityModel>(collectionName);

            var tasks = models.Select(x => collection.ReplaceOneAsync(GetFilterDefinitionById(x.Id), x)).ToArray();

            await Task.WhenAll(tasks);

            return tasks.Count(x => !x.IsCompletedSuccessfully) > 0 ? null : models;
        }

        public async Task<long> Delete(Guid[] ids)
        {
            var collection = _SettingsModel.GetCollection<PlaceAvailabilityModel>(collectionName);

            var filter = new MongoDB.Driver.FilterDefinitionBuilder<PlaceAvailabilityModel>().In(x => x.Id, ids);

            var tasks = await collection.DeleteManyAsync(filter);

            return tasks.DeletedCount;
        }

        public Task<PlaceAvailabilityModel> Get(Guid id)
        {
            var collection = _SettingsModel.GetCollection<PlaceAvailabilityModel>(collectionName);

            return collection.Find(GetFilterDefinitionById(id)).FirstOrDefaultAsync();
        }

        public Task<List<PlaceAvailabilityModel>> GetByPlace(Guid id)
        {
            var collection = _SettingsModel.GetCollection<PlaceAvailabilityModel>(collectionName);

            return collection.Find(GetFilterDefinitionByPlace(id)).ToListAsync();
        }

        public Task<List<PlaceAvailabilityModel>> GetListBySubscriber(Guid id, DateTime? date)
        {
            var collection = _SettingsModel.GetCollection<PlaceAvailabilityModel>(collectionName);

            return collection.Find(GetFilterDefinitionBySubscriber(id)).ToListAsync();
        }

        private FilterDefinition<PlaceAvailabilityModel> GetFilterDefinitionById(Guid id)
        {
            return new FilterDefinitionBuilder<PlaceAvailabilityModel>().Eq(x => x.Id, id);
        }
        private FilterDefinition<PlaceAvailabilityModel> GetFilterDefinitionByPlace(Guid id)
        {
            return new FilterDefinitionBuilder<PlaceAvailabilityModel>().Eq(x => x.PlaceId, id);
        }
        private FilterDefinition<PlaceAvailabilityModel> GetFilterDefinitionBySubscriber(Guid id)
        {
            return new FilterDefinitionBuilder<PlaceAvailabilityModel>().Eq(x => x.SubscriberId, id);
        }

    }
}
