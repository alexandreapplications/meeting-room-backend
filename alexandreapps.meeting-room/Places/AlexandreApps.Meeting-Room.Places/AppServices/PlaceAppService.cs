using AlexandreApps.Meeting_Room.Core.Models.Places;
using AlexandreApps.Meeting_Room.Places.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AlexandreApps.Meeting_Room.Places.AppServices
{
    public class PlaceAppService: IPlaceAppService
    {
        private readonly IPlaceDbService _PlaceDB;

        public PlaceAppService(IPlaceDbService placeDb)
        {
            this._PlaceDB = placeDb;
        }

        /// <summary>
        /// Creates a new Place groups
        /// </summary>
        /// <param name="models">Places to create</param>
        /// <returns>Places information</returns>
        public async Task<PlaceModel[]> Create(params PlaceModel[] models)
        {
            await this._PlaceDB.Create(models);

            return models;
        }

        /// <summary>
        /// Updates a list of place groups
        /// </summary>
        /// <param name="models">Places to Update</param>
        /// <returns>Places information</returns>
        public async Task<PlaceModel[]> Update(params PlaceModel[] models)
        {
            return await this._PlaceDB.Update(models);
        }

        /// <summary>
        /// Delete a list of place groups
        /// </summary>
        /// <param name="models">Ids to delete</param>
        /// <returns>Places information</returns>
        public async Task<long> Delete(params Guid[] ids)
        {
            return await this._PlaceDB.Delete(ids);
        }

        /// <summary>
        /// Get a place group by key
        /// </summary>
        /// <param name="id">Places to get</param>
        /// <returns>Places information</returns>
        public async Task<PlaceModel> Get(Guid id)
        {
            return await this._PlaceDB.Get(id);

        }

        /// <summary>
        /// Get a place group by key
        /// </summary>
        /// <param name="id">Subscriber id</param>
        /// <returns>Places information</returns>
        public async Task<List<PlaceModel>> GetListBySubscriber(Guid id)
        {
            return await this._PlaceDB.GetListBySubscriber(id);
        }
    }
}
