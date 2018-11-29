using AlexandreApps.Meeting_Room.Core.Models.Places;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AlexandreApps.Meeting_Room.Places.Interfaces
{
    /// <summary>
    /// Interface places
    /// </summary>
    public interface IPlaceAppService
    {
        /// <summary>
        /// Creates a new Place groups
        /// </summary>
        /// <param name="models">Places to create</param>
        /// <returns>Places information</returns>
        Task<PlaceModel[]> Create(PlaceModel[] models);

        /// <summary>
        /// Updates a list of place groups
        /// </summary>
        /// <param name="models">Places to Update</param>
        /// <returns>Places information</returns>
        Task<PlaceModel[]> Update(PlaceModel[] models);

        /// <summary>
        /// Delete a list of place groups
        /// </summary>
        /// <param name="models">Ids to delete</param>
        /// <returns>Places information</returns>
        Task<PlaceModel[]> Delete(int[] ids);

        /// <summary>
        /// Get a place group by key
        /// </summary>
        /// <param name="id">Places to get</param>
        /// <returns>Places information</returns>
        Task<PlaceModel> Get(int id);

        /// <summary>
        /// Get a place group by key
        /// </summary>
        /// <param name="id">Subscriber id</param>
        /// <returns>Places information</returns>
        Task<PlaceModel[]> GetListBySubscriber(int id);
    }
}
