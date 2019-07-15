using AlexandreApps.Meeting_Room.Core.Models.Places;
using AlexandreApps.Meeting_Room.Places.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlexandreApps.Meeting_Room.Places.AppServices
{
    /// <summary>
    /// Manages Group places
    /// </summary>
    public class PlaceGroupAppService: IPlaceGroupAppService
    {
        private readonly IPlaceGroupDbService _PlaceGroupDb;

        public PlaceGroupAppService(IPlaceGroupDbService placeGroupDb)
        {
            this._PlaceGroupDb = placeGroupDb;
        }

        /// <summary>
        /// Creates a new Place groups
        /// </summary>
        /// <param name="models">Places to create</param>
        /// <returns>Places information</returns>
        public async Task<PlaceGroupModel[]> Create (params PlaceGroupModel[] models)
        {
            foreach(var item in models)
            {
                item.Id = Guid.NewGuid();
            }

            await _PlaceGroupDb.Create(models);

            return models;
        }

        /// <summary>
        /// Updates a list of place groups
        /// </summary>
        /// <param name="models">Places to Update</param>
        /// <returns>Places information</returns>
        public async Task<PlaceGroupModel[]> Update(params PlaceGroupModel[] models)
        {
            return await _PlaceGroupDb.Update(models);
        }

        /// <summary>
        /// Delete a list of place groups
        /// </summary>
        /// <param name="models">Ids to delete</param>
        /// <returns>Places information</returns>
        public async Task<long> Delete(params Guid[] ids)
        {
            return await _PlaceGroupDb.Delete(ids);
        }

        /// <summary>
        /// Get a place group by key
        /// </summary>
        /// <param name="id">Places to get</param>
        /// <returns>Places information</returns>
        public async Task<PlaceGroupModel> Get(Guid id)
        {
            return await _PlaceGroupDb.Get(id);
        }

        /// <summary>
        /// Get a place group by key
        /// </summary>
        /// <param name="id">Subscriber id</param>
        /// <returns>Places information</returns>
        public async Task<List<PlaceGroupModel>> GetListBySubscriber(Guid id)
        {
            return await _PlaceGroupDb.GetListBySubscriber(id);
        }
    }
}
